using UnityEngine;
using UnityEngine.Assertions;

namespace HK.Mahjong
{
    /// <summary>
    /// プレハブから<see cref="IGameView"/>を生成する<see cref="GameViewProviderBase"/>
    /// </summary>
    [CreateAssetMenu(menuName = "HK/Mahjong/GameView/Prefab")]
    public sealed class PrefabGameViewProvider : GameViewProviderBase
    {
        [SerializeField]
        private GameObject prefab = default;

        public override IGameView Create()
        {
            Assert.IsNotNull(prefab.GetComponent<IGameView>(), $"{prefab}に{typeof(IGameView)}がアタッチされていません");
            var instance = Instantiate(prefab);

            return instance.GetComponent<IGameView>();
        }
    }
}
