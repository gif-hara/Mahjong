using System.Collections.Generic;
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
            var players = new List<Player>();
            players.Add(new Player());
            gameModel = new GameModel(rule, field, players);
            gameView = new LogGameView();
            gameView.Setup(gameModel);

            Reset();
        }

        private void Reset()
        {
            gameModel.Field.Reset();
            foreach(var x in gameModel.Players)
            {
                x.Reset(gameModel.Field.Pop(Constants.InitializePopNumber));
            }
        }
    }
}
