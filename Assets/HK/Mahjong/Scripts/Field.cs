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

        private Subject<Unit> onReset = new Subject<Unit>();

        /// <summary>
        /// ゲームを最初から行える状態になった際のイベント
        /// </summary>
        public IObservable<Unit> OnResetAsObservable() => onReset;

        public Field(IEnumerable<Tile> tiles)
        {
            AvailableTiles = new List<Tile>(tiles);
        }

        /// <summary>
        /// ゲームを最初から行える状態にする
        /// </summary>
        public void Reset()
        {
            Tiles = AvailableTiles.OrderBy(x => Guid.NewGuid()).ToList();
            onReset.OnNext(Unit.Default);
        }

        /// <summary>
        /// <see cref="Tiles"/>から<see cref="Tile"/>を抜き出す
        /// </summary>
        public List<Tile> Pop(int count)
        {
            var result = new List<Tile>();
            for(var i=0; i<count; i++)
            {
                result.Add(Tiles[i]);
            }

            Tiles.RemoveRange(0, count);

            return result;
        }
    }
}
