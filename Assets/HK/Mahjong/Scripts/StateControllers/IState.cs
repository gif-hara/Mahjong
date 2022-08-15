using UniRx;

namespace HK.Mahjong.StateControllers
{
    /// <summary>
    /// ステートのインターフェイス
    /// </summary>
    public interface IState<TStateName>
    {
        void Enter(StateController<TStateName> owner, CompositeDisposable disposable, IStateArgument argument = null);

        void Exit();
        
        TStateName StateName { get; }
    }
}
