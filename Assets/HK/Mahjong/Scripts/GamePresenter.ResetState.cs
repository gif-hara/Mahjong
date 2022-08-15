using HK.Mahjong.StateControllers;
using System.Collections.Generic;
using UniRx;
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

            public override void Enter(StateController<State> owner, CompositeDisposable disposable, IStateArgument argument = null)
            {
                presenter.Reset();
                owner.Change(State.Draw);
            }

            public override void Exit()
            {
            }
        }
    }
}
