using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

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
        }
    }
}
