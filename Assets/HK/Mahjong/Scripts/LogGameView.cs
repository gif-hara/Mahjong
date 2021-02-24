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
            gameModel.Field.OnResetedAsObservable()
                .Subscribe(_ =>
                {
                    var i = 0;
                    Debug.Log($"Field.Tiles{System.Environment.NewLine}{string.Join(System.Environment.NewLine, gameModel.Field.Tiles.Select(x => $"[{i++}]{x}"))}");
                })
                .AddTo(disposables);
            foreach(var player in gameModel.Players)
            {
                player.OnResetedAsObservable()
                    .Subscribe(_ =>
                    {
                        var i = 0;
                        Debug.Log($"OnReset Player.Hand{System.Environment.NewLine}{string.Join(System.Environment.NewLine, player.Hand.Select(x => $"[{i++}]{x}"))}");
                    })
                    .AddTo(disposables);

                player.OnDrawedAsObservable()
                    .Subscribe(_ =>
                    {
                        var i = 0;
                        Debug.Log($"OnDraw Player.Hand{System.Environment.NewLine}{string.Join(System.Environment.NewLine, player.Hand.Select(x => $"[{i++}]{x}"))}");
                    })
                    .AddTo(disposables);

                player.OnDiscardedTileAsObservable()
                    .Subscribe(_ =>
                    {
                        var i = 0;
                        Debug.Log($"OnDiscardTile Player.Hand{System.Environment.NewLine}{string.Join(System.Environment.NewLine, player.Hand.Select(x => $"[{i++}]{x}"))}");
                    })
                    .AddTo(disposables);
            }
        }
    }
}
