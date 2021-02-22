using System;
using UnityEngine.Assertions;

namespace HK.Mahjong
{
    /// <summary>
    /// <see cref="Enum"/>ŠÖ˜A‚ÌŠg’£ŠÖ”
    /// </summary>
    public static class EnumExtensions
    {
        /// <summary>
        /// <paramref name="self"/>‚É‘Î‰‚µ‚½<paramref name="number"/>‚Å‚ ‚é‚©ƒ`ƒFƒbƒN‚·‚é
        /// </summary>
        public static void CheckRange(this Constants.TileType self, int number)
        {
            switch(self)
            {
                case Constants.TileType.Character:
                case Constants.TileType.Bamboo:
                case Constants.TileType.Circle:
                    Assert.IsTrue(number >= 1 && number <= 9, "””v‚È‚Ì‚É1‚©‚ç9‚Å‚Í–³‚¢”š‚Å‚µ‚½");
                    break;
                case Constants.TileType.Wind:
                    Assert.IsTrue(number >= 1 && number <= 4, "•—”v‚È‚Ì‚É1‚©‚ç4‚Å‚Í–³‚¢”š‚Å‚µ‚½");
                    break;
                case Constants.TileType.Dragon:
                    Assert.IsTrue(number >= 1 && number <= 3, "OŒ³”v‚È‚Ì‚É1‚©‚ç3‚Å‚Í–³‚¢”š‚Å‚µ‚½");
                    break;
            }
        }
    }
}
