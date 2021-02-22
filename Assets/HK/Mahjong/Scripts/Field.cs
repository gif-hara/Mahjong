using System.Collections.Generic;
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
        /// プレイヤーがツモれる<see cref="Tile"/>のリスト
        /// </summary>
        public ReactiveCollection<Tile> Tiles { get; private set; }

        public Field(Rule rule)
        {
            Tiles = new ReactiveCollection<Tile>(rule.AvailableTiles);
        }
    }
}
