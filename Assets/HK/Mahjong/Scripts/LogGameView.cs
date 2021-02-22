using UniRx;
using UnityEngine;
using UnityEngine.Assertions;
using System.Linq;

namespace HK.Mahjong
{
    /// <summary>
    /// <see cref="GameModel"/>のデータをログで表示するだけの<see cref="IGameView"/>
    /// </summary>
    public sealed class LogGameView : IGameView
    {
        private CompositeDisposable disposables = new CompositeDisposable();

        public void Dispose()
        {
            disposables.Dispose();
        }

        public void Setup(GameModel gameModel)
        {
            gameModel.Field.OnResetAsObservable()
                .Subscribe(_ =>
                {
                    Debug.Log($"Field.Tiles{System.Environment.NewLine}{string.Join(System.Environment.NewLine, gameModel.Field.Tiles.Select(x => x.ToString()))}");
                })
                .AddTo(disposables);
            foreach(var player in gameModel.Players)
            {
                player.OnResetAsObservable()
                    .Subscribe(_ =>
                    {
                        Debug.Log($"OnReset Player.Hand{System.Environment.NewLine}{string.Join(System.Environment.NewLine, player.Hand.Select(x => x.ToString()))}");
                    })
                    .AddTo(disposables);

                player.OnDrawAsObservable()
                    .Subscribe(_ =>
                    {
                        Debug.Log($"OnDraw Player.Hand{System.Environment.NewLine}{string.Join(System.Environment.NewLine, player.Hand.Select(x => x.ToString()))}");
                    })
                    .AddTo(disposables);
            }
        }
    }
}
