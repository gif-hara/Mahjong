using System;

namespace HK.Mahjong
{
    /// <summary>
    /// ゲームの状態を表示するインターフェイス
    /// </summary>
    public interface IGameView : IDisposable
    {
        /// <summary>
        /// <paramref name="gameModel"/>をもとにビューをセットアップする
        /// </summary>
        void Setup(GameModel gameModel);
    }
}
