using UnityEngine;
using UnityEngine.Assertions;

namespace HK.Mahjong
{
    /// <summary>
    /// <see cref="int"/>に関する拡張関数
    /// </summary>
    public static class IntExtensions
    {
        /// <summary>
        /// 内部IDから<see cref="Constants.TileType"/>に変換する
        /// </summary>
        public static Constants.TileType ConvertToTileType(this int internalIndex)
        {
            if (internalIndex >= 1 && internalIndex <= 9)
            {
                return Constants.TileType.Character;
            }
            if (internalIndex >= 10 && internalIndex <= 18)
            {
                return Constants.TileType.Bamboo;
            }
            if (internalIndex >= 19 && internalIndex <= 27)
            {
                return Constants.TileType.Circle;
            }
            if (internalIndex >= 28 && internalIndex <= 31)
            {
                return Constants.TileType.Wind;
            }
            if (internalIndex >= 32 && internalIndex <= 34)
            {
                return Constants.TileType.Dragon;
            }

            Assert.IsTrue(false, $"{nameof(ConvertToTileType)}で変換に失敗しました. {internalIndex}は未対応です");
            return default;
        }

        /// <summary>
        /// 内部IDから牌の数字に変換する
        /// </summary>
        public static int ConvertToTileNumber(this int internalIndex)
        {
            if (internalIndex >= 1 && internalIndex <= 9)
            {
                return internalIndex;
            }
            if (internalIndex >= 10 && internalIndex <= 18)
            {
                return internalIndex - 9;
            }
            if (internalIndex >= 19 && internalIndex <= 27)
            {
                return internalIndex - 18;
            }
            if (internalIndex >= 28 && internalIndex <= 31)
            {
                return internalIndex - 27;
            }
            if (internalIndex >= 32 && internalIndex <= 34)
            {
                return internalIndex - 31;
            }

            Assert.IsTrue(false, $"{nameof(ConvertToTileNumber)}で変換に失敗しました. {internalIndex}は未対応です");
            return default;
        }
    }
}
