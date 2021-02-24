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

        private readonly Subject<Unit> onReseted = new Subject<Unit>();

        /// <summary>
        /// <see cref="Reset(List{Tile})"/>が実行された際のイベント
        /// </summary>
        public IObservable<Unit> OnResetedAsObservable() => onReseted;

        private readonly Subject<Tile> onDrawed = new Subject<Tile>();

        /// <summary>
        /// <see cref="Draw(Tile)"/>が実行された際のイベント
        /// </summary>
        /// <returns></returns>
        public IObservable<Tile> OnDrawedAsObservable() => onDrawed;

        private readonly Subject<Tile> onDiscardedTile = new Subject<Tile>();

        /// <summary>
        /// <see cref="DiscardTile(int)"/>が実行された際のイベント
        /// </summary>
        public IObservable<Tile> OnDiscardedTileAsObservable() => onDiscardedTile;

        /// <summary>
        /// <paramref name="tile"/>を<see cref="hand"/>に加える
        /// </summary>
        public void Draw(Tile tile)
        {
            hand.Add(tile);
            onDrawed.OnNext(tile);
        }

        /// <summary>
        /// <paramref name="index"/>に紐づく<see cref="hand"/>の牌を捨てる
        /// </summary>
        public void DiscardTile(int index)
        {
            var target = hand[index];
            hand.RemoveAt(index);
            this.hand.Sort((x, y) => x.InternalIndex - y.InternalIndex);

            onDiscardedTile.OnNext(target);
        }

        /// <summary>
        /// ゲームを最初から行える状態にする
        /// </summary>
        /// <param name="hand"></param>
        public void Reset(List<Tile> hand)
        {
            this.hand.Clear();
            this.hand.AddRange(hand);
            this.hand.Sort((x, y) => x.InternalIndex - y.InternalIndex);

            onReseted.OnNext(Unit.Default);
        }

        public void Dispose()
        {
            onReseted.OnCompleted();
            onReseted.Dispose();
        }
    }
}
