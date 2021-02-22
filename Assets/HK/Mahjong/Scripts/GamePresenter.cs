using UnityEngine;
using UnityEngine.Assertions;

namespace HK.Mahjong
{
    /// <summary>
    /// <see cref="GameModel"/>のデータを編集して<see cref="IGameView"/>へ流し込むクラス
    /// </summary>
    public sealed class GamePresenter : MonoBehaviour
    {
        [SerializeField]
        private Rule rule = default;

        private GameModel gameModel;

        private IGameView gameView;

        private void Start()
        {
            gameModel = new GameModel(rule);
        }
    }
}
