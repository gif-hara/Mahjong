using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using HK.Framework;
using UniRx;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace HK.Mahjong
{
    /// <summary>
    /// 3次元空間でゲームを表現する<see cref="IGameView"/>
    /// </summary>
    public sealed class ThreeDimensionGameView : MonoBehaviour, IGameView
    {
        /// <summary>
        /// 牌を表すプレハブのリスト
        /// </summary>
        [SerializeField]
        private List<ThreeDimensionTileController> tilePrefabs = default;

        /// <summary>
        /// プレイヤーの牌を格納する<see cref="Transform"/>のリスト
        /// </summary>
        [SerializeField]
        private List<Transform> playerTileRoots = default;

        /// <summary>
        /// 牌を配置する際のオフセット
        /// </summary>
        [SerializeField]
        private float tileOffset = default;

        private readonly CompositeDisposable disposables = new CompositeDisposable();

#if UNITY_EDITOR
        [ContextMenu("SetupTilePrefabs")]
        private void SetupTilePrefabs()
        {
            tilePrefabs.Clear();
            for(var i=1; i<=34; i++)
            {
                var tile = new Tile(i);
                tilePrefabs.Add(AssetDatabase.LoadAssetAtPath<ThreeDimensionTileController>($"Assets/HK/Mahjong/Prefabs/Tile.{tile.Type}{tile.Number}.prefab"));
            }

            EditorUtility.SetDirty(this);
        }
#endif

        public void Dispose()
        {
            throw new System.NotImplementedException();
        }

        public void Setup(GameModel gameModel)
        {
            for(var i=0; i<gameModel.Players.Count; i++)
            {
                var player = gameModel.Players[i];
                var tileRoot = playerTileRoots[i];

                Observable.Merge(
                    player.OnResetedAsObservable().AsUnitObservable(),
                    player.OnDiscardedTileAsObservable().AsUnitObservable()
                    )
                    .Subscribe(_ =>
                    {
                        for(var j=0; j<tileRoot.childCount; j++)
                        {
                            tileRoot.GetChild(j).GetComponent<ThreeDimensionTileController>().Return();
                        }
                        for(var j=0; j<player.Hand.Count; j++)
                        {
                            var hand = player.Hand[j];
                            var tileController = Rent(hand.InternalIndex);
                            tileController.transform.SetParent(tileRoot);
                            tileController.transform.localPosition = new Vector3(j * tileOffset, 0.0f, 0.0f);
                        }
                    })
                    .AddTo(disposables);

                player.OnDrawedAsObservable()
                    .Subscribe(x =>
                    {
                        var tileController = Rent(x.InternalIndex);
                        tileController.transform.SetParent(tileRoot);
                        tileController.transform.localPosition = new Vector3(player.Hand.Count * tileOffset, 0.0f, 0.0f);
                    })
                    .AddTo(disposables);
            }
        }

        private ThreeDimensionTileController Rent(int internalIndex)
        {
            return tilePrefabs[internalIndex - 1].Rent(new Tile(internalIndex));
        }
    }
}
