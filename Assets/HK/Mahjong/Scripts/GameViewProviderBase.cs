using UnityEngine;
using UnityEngine.Assertions;

namespace HK.Mahjong
{
    /// <summary>
    /// <see cref="IGameView"/>を生成するだけの抽象クラス
    /// </summary>
    public abstract class GameViewProviderBase : ScriptableObject
    {
        /// <summary>
        /// <see cref="IGameView"/>を生成する
        /// </summary>
        public abstract IGameView Create();
    }
}
