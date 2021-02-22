using System;
using UnityEngine.Assertions;

namespace HK.Mahjong
{
    /// <summary>
    /// <see cref="Enum"/>�֘A�̊g���֐�
    /// </summary>
    public static class EnumExtensions
    {
        /// <summary>
        /// <paramref name="self"/>�ɑΉ�����<paramref name="number"/>�ł��邩�`�F�b�N����
        /// </summary>
        public static void CheckRange(this Constants.TileType self, int number)
        {
            switch(self)
            {
                case Constants.TileType.Character:
                case Constants.TileType.Bamboo:
                case Constants.TileType.Circle:
                    Assert.IsTrue(number >= 1 && number <= 9, "���v�Ȃ̂�1����9�ł͖��������ł���");
                    break;
                case Constants.TileType.Wind:
                    Assert.IsTrue(number >= 1 && number <= 4, "���v�Ȃ̂�1����4�ł͖��������ł���");
                    break;
                case Constants.TileType.Dragon:
                    Assert.IsTrue(number >= 1 && number <= 3, "�O���v�Ȃ̂�1����3�ł͖��������ł���");
                    break;
            }
        }
    }
}
