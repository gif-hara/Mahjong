using HK.Mahjong.StateControllers;
using System.Collections.Generic;
using UnityEngine;

namespace HK.Mahjong
{
    public sealed partial class GamePresenter
    {
        /// <summary>
        /// 次のターンへ進む<see cref="StateBase"/>
        /// </summary>
        public sealed class NextTurnState : StateBase
        {
            public override State StateName => State.NextTurn;

            public NextTurnState(GamePresenter presenter)
                : base(presenter)
            {
            }

            public override void Enter(StateController<State> owner, IStateArgument argument = null)
            {
                presenter.gameModel.Turn.Value++;
                owner.Change(State.Draw);
            }

            public override void Exit()
            {
            }
        }
    }
}
