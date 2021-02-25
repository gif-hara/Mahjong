using System;
using System.Collections.Generic;
using System.Linq;
using UniRx;
using UnityEngine;
using UnityEngine.Assertions;

namespace HK.Mahjong
{
    /// <summary>
    /// 麻雀卓を担うクラス
    /// </summary>
    public sealed class Field
    {
        /// <summary>
        /// 利用可能な<see cref="Tile"/>のリスト
        /// </summary>
        public List<Tile> AvailableTiles { get; }

        /// <summary>
        /// プレイヤーがツモれる<see cref="Tile"/>のリスト
        /// </summary>
        public List<Tile> Tiles { get; private set; }

        private Subject<Unit> onReseted = new Subject<Unit>();

        /// <summary>
        /// <see cref="Reset"/>が実行された際のイベント
        /// </summary>
        public IObservable<Unit> OnResetedAsObservable() => onReseted;

        public Field(IEnumerable<Tile> tiles)
        {
            AvailableTiles = new List<Tile>(tiles);
        }

        /// <summary>
        /// ゲームを最初から行える状態にする
        /// </summary>
        public void Reset()
        {
            Tiles = new List<Tile>();
            for(var i=0; i<4; i++)
            {
                Tiles.AddRange(AvailableTiles);
            }
            Tiles = Tiles.OrderBy(x => Guid.NewGuid()).ToList();
            onReseted.OnNext(Unit.Default);
        }

        /// <summary>
        /// <see cref="Tiles"/>から<see cref="Tile"/>を抜き出す
        /// </summary>
        public List<Tile> Pop(int count)
        {
            var result = new List<Tile>();
            for (var i = 0; i < count; i++)
            {
                result.Add(Tiles[i]);
            }

            Tiles.RemoveRange(0, count);

            return result;
        }

        /// <summary>
        /// <see cref="Tiles"/>から1つだけ<see cref="Tile"/>を抜き出す
        /// </summary>
        public Tile Pop()
        {
            var result = Tiles[0];
            Tiles.RemoveAt(0);

            return result;
        }
    }
}
