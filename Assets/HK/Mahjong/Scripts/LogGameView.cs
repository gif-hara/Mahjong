using UnityEngine;
using UnityEngine.Assertions;

namespace HK.Mahjong
{
    /// <summary>
    /// <see cref="GameModel"/>のデータをログで表示するだけの<see cref="IGameView"/>
    /// </summary>
    public sealed class LogGameView : IGameView
    {
        public void Dispose()
        {
            throw new System.NotImplementedException();
        }

        public void Setup(GameModel gameModel)
        {
            foreach(var t in gameModel.Field.Tiles)
            {
                Debug.Log(t.ToString());
            }
        }
    }
}
