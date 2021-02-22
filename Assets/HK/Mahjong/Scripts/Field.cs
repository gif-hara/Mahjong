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
        public IObservable<Unit> OnReset => onReset;

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
    }
}
