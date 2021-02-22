using UniRx;

namespace HK.StateControllers
{
    /// <summary>
    /// ステートのインターフェイス
    /// </summary>
    public interface IState<TStateName>
    {
        void Enter(StateController<TStateName> owner, IStateArgument argument = null);

        void Exit();

        CompositeDisposable ActiveDisposables { get; }

        TStateName StateName { get; }
    }
}
