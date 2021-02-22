using HK.Mahjong.StateControllers;
using System.Collections.Generic;
using UnityEngine;

namespace HK.Mahjong
{
    public sealed partial class GamePresenter
    {
        /// <summary>
        /// ゲームを最初から行える状態にする<see cref="StateBase"/>
        /// </summary>
        public sealed class ResetState : StateBase
        {
            public override State StateName => State.Reset;

            public ResetState(GamePresenter presenter)
                : base(presenter)
            {
            }

            public override void Enter(StateController<State> owner, IStateArgument argument = null)
            {
                presenter.Reset();
            }

            public override void Exit()
            {
            }
        }
    }
}
