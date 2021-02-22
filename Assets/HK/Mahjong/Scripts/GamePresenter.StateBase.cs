using HK.Mahjong.StateControllers;
using UniRx;
using UnityEngine;
using UnityEngine.Assertions;

namespace HK.Mahjong
{
    public sealed partial class GamePresenter
    {
        /// <summary>
        /// <see cref="GamePresenter"/>のステート処理を行う抽象クラス
        /// </summary>
        public abstract class StateBase : IState<State>
        {
            private readonly CompositeDisposable activeDisposables = new CompositeDisposable();
            public CompositeDisposable ActiveDisposables => activeDisposables;

            public abstract State StateName { get; }

            protected GamePresenter presenter;

            public StateBase(GamePresenter presenter)
            {
                this.presenter = presenter;
            }

            public virtual void Enter(StateController<State> owner, IStateArgument argument = null)
            {
            }

            public virtual void Exit()
            {
            }
        }
    }
}
