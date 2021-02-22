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
            var field = new Field(rule.AvailableTiles);
            gameModel = new GameModel(rule, field);
            gameView = new LogGameView();
            gameView.Setup(gameModel);

            field.Reset();
        }
    }
}
