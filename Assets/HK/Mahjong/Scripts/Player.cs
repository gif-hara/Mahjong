using System;
using System.Collections.Generic;
using UniRx;
using UnityEngine;
using UnityEngine.Assertions;

namespace HK.Mahjong
{
    /// <summary>
    /// プレイヤーを制御するクラス
    /// </summary>
    public sealed class Player : IDisposable
    {
        /// <summary>
        /// 手牌
        /// </summary>
        public readonly List<Tile> hand = new List<Tile>();
        public IReadOnlyList<Tile> Hand => hand;

        private readonly Subject<Unit> onReset = new Subject<Unit>();

        /// <summary>
        /// ゲームを最初から行える状態になった際のイベント
        /// </summary>
        public IObservable<Unit> OnResetAsObservable() => onReset;

        /// <summary>
        /// ゲームを最初から行える状態にする
        /// </summary>
        /// <param name="hand"></param>
        public void Reset(List<Tile> hand)
        {
            this.hand.Clear();
            this.hand.AddRange(hand);

            onReset.OnNext(Unit.Default);
        }

        public void Dispose()
        {
            onReset.OnCompleted();
            onReset.Dispose();
        }
    }
}
