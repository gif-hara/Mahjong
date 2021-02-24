using HK.Mahjong.StateControllers;
using System.Collections.Generic;
using UnityEngine;

namespace HK.Mahjong
{
    public sealed partial class GamePresenter
    {
        /// <summary>
        /// ゲームシステム初期化を行う<see cref="StateBase"/>
        /// </summary>
        public sealed class InitializeState : StateBase
        {
            public override State StateName => State.Initialize;

            public InitializeState(GamePresenter presenter)
                : base(presenter)
            {
            }

            public override void Enter(StateController<State> owner, IStateArgument argument = null)
            {
                var field = new Field(presenter.rule.AvailableTiles);
                var players = new List<Player>();
                players.Add(new Player());
                presenter.gameModel = new GameModel(presenter.rule, field, players);
                presenter.gameView = presenter.gameViewProvider.Create();
                presenter.gameView.Setup(presenter.gameModel);

                presenter.stateController.Change(State.Reset);
            }

            public override void Exit()
            {
            }
        }
    }
}
