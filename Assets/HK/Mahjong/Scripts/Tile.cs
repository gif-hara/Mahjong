using System;
using UnityEngine;

namespace HK.Mahjong
{
    /// <summary>
    /// 牌の役割を担うクラス
    /// </summary>
    [Serializable]
    public sealed class Tile
    {
        /// <summary>
        /// <inheritdoc cref="Constants.TileType"/>
        /// </summary>
        [SerializeField]
        private Constants.TileType type = default;
        public Constants.TileType Type => type;

        /// <summary>
        /// 数字
        /// </summary>
        [SerializeField]
        private int number = default;
        public int Number => number;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public Tile(Constants.TileType type, int number)
        {
            this.type = type;
            this.number = number;

            Type.CheckRange(Number);
        }

        public override string ToString() => $"Type = {type}, Number = {Number}";
    }
}
