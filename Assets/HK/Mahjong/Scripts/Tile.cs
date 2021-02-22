using System;
using UnityEngine;

namespace HK.Mahjong
{
    /// <summary>
    /// �v�̖�����S���N���X
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
        /// ����
        /// </summary>
        [SerializeField]
        private int number = default;
        public int Number => number;

        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        public Tile(Constants.TileType type, int number)
        {
            this.type = type;
            this.number = number;

            Type.CheckRange(Number);
        }
    }
}
