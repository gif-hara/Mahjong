using UnityEngine;
using UnityEngine.Assertions;

namespace HK.Mahjong
{
    /// <summary>
    /// <see cref="LogGameView"/>を生成するだけのクラス
    /// </summary>
    [CreateAssetMenu(menuName = "HK/Mahjong/GameView/Log")]
    public sealed class LogGameViewProvider : GameViewProviderBase
    {
        public override IGameView Create()
        {
            return new LogGameView();
        }
    }
}
