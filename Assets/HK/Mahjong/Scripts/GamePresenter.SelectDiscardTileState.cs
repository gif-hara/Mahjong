using HK.Mahjong.StateControllers;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

namespace HK.Mahjong
{
    public sealed partial class GamePresenter
    {
        /// <summary>
        /// 捨て牌を選択する<see cref="StateBase"/>
        /// </summary>
        public sealed class SelectDiscardTileState : StateBase
        {
            public override State StateName => State.SelectDiscardTile;

            public SelectDiscardTileState(GamePresenter presenter)
                : base(presenter)
            {
            }

            public override void Enter(StateController<State> owner, IStateArgument argument = null)
            {
                GameInputEvent.SelectTile
                    .Subscribe(x =>
                    {
                        presenter.gameModel.CurrentPlayer.DiscardTile(x);
                        owner.Change(State.NextTurn);
                    })
                    .AddTo(ActiveDisposables);
            }

            public override void Exit()
            {
            }
        }
    }
}
