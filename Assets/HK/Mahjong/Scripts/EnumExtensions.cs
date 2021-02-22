using System;
using UnityEngine.Assertions;

namespace HK.Mahjong
{
    /// <summary>
    /// <see cref="Enum"/>関連の拡張関数
    /// </summary>
    public static class EnumExtensions
    {
        /// <summary>
        /// <paramref name="self"/>に対応した<paramref name="number"/>であるかチェックする
        /// </summary>
        public static void CheckRange(this Constants.TileType self, int number)
        {
            switch(self)
            {
                case Constants.TileType.Character:
                case Constants.TileType.Bamboo:
                case Constants.TileType.Circle:
                    Assert.IsTrue(number >= 1 && number <= 9, "数牌なのに1から9では無い数字でした");
                    break;
                case Constants.TileType.Wind:
                    Assert.IsTrue(number >= 1 && number <= 4, "風牌なのに1から4では無い数字でした");
                    break;
                case Constants.TileType.Dragon:
                    Assert.IsTrue(number >= 1 && number <= 3, "三元牌なのに1から3では無い数字でした");
                    break;
            }
        }
    }
}
