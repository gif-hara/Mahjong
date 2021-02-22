using UnityEngine;
using UnityEngine.Assertions;

namespace HK.Mahjong
{
    /// <summary>
    /// 共通で利用する定数を定義するクラス
    /// </summary>
    public static class Constants
    {
        /// <summary>
        /// 牌のタイプ
        /// </summary>
        public enum TileType
        {
            /// <summary>
            /// 萬子
            /// </summary>
            Character,

            /// <summary>
            /// 索子
            /// </summary>
            Bamboo,

            /// <summary>
            /// 筒子
            /// </summary>
            Circle,

            /// <summary>
            /// 風牌
            /// </summary>
            /// <remarks>
            /// 1 = 東
            /// 2 = 南
            /// 3 = 西
            /// 4 = 北
            /// </remarks>
            Wind,

            /// <summary>
            /// 三元牌
            /// </summary>
            /// <remarks>
            /// 1 = 白
            /// 2 = 發
            /// 3 = 中
            /// </remarks>
            Dragon,
        }
    }
}
