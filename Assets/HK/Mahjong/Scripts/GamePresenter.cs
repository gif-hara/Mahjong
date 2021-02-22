using HK.Mahjong.StateControllers;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

namespace HK.Mahjong
{
    /// <summary>
    /// <see cref="GameModel"/>のデータを編集して<see cref="IGameView"/>へ流し込むクラス
    /// </summary>
    public sealed partial class GamePresenter : MonoBehaviour
    {
        [SerializeField]
        private Rule rule = default;

        private GameModel gameModel;

        private IGameView gameView;

        private StateController<State> stateController;

        public enum State
        {
            Initialize,
            Reset,
        }

        private void Start()
        {
            stateController = new StateController<State>(
                new List<IState<State>>
                {
                    new InitializeState(this),
                    new ResetState(this),
                });
            stateController.Change(State.Initialize);
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
