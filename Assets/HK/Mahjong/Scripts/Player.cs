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
        /// <inheritdoc cref="Reset(List{Tile})"/>が実行された際のイベント
        /// </summary>
        public IObservable<Unit> OnResetAsObservable() => onReset;

        private readonly Subject<Tile> onDraw = new Subject<Tile>();

        /// <summary>
        /// <inheritdoc cref="Draw(Tile)"/>が実行された際のイベント
        /// </summary>
        /// <returns></returns>
        public IObservable<Tile> OnDrawAsObservable() => onDraw;

        private readonly Subject<Tile> onDiscardTile = new Subject<Tile>();

        /// <summary>
        /// <inheritdoc cref="DiscardTile(int)"/>が実行された際のイベント
        /// </summary>
        public IObservable<Tile> OnDiscardTileAsObservable() => onDiscardTile;

        /// <summary>
        /// <paramref name="tile"/>を<see cref="hand"/>に加える
        /// </summary>
        public void Draw(Tile tile)
        {
            hand.Add(tile);
            onDraw.OnNext(tile);
        }

        /// <summary>
        /// <paramref name="index"/>に紐づく<see cref="hand"/>の牌を捨てる
        /// </summary>
        public void DiscardTile(int index)
        {
            var target = hand[index];
            hand.RemoveAt(index);
            onDiscardTile.OnNext(target);
        }

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
