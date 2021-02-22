using UniRx;
using UnityEngine;
using UnityEngine.Assertions;

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
            gameModel.Field.OnReset
                .Subscribe(_ =>
                {
                    foreach (var t in gameModel.Field.Tiles)
                    {
                        Debug.Log(t.ToString());
                    }
                })
                .AddTo(disposables);
        }
    }
}
