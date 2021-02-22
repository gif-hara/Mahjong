using HK.Mahjong.StateControllers;
using System.Collections.Generic;
using UnityEngine;

namespace HK.Mahjong
{
    public sealed partial class GamePresenter
    {
        /// <summary>
        /// プレイヤーが牌をツモる<see cref="StateBase"/>
        /// </summary>
        public sealed class DrawState : StateBase
        {
            public override State StateName => State.Draw;

            public DrawState(GamePresenter presenter)
                : base(presenter)
            {
            }

            public override void Enter(StateController<State> owner, IStateArgument argument = null)
            {
                presenter.gameModel.CurrentPlayer.Draw(presenter.gameModel.Field.Pop());
            }

            public override void Exit()
            {
            }
        }
    }
}
