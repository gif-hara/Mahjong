using UnityEngine;
using UnityEngine.Assertions;

namespace HK.Mahjong
{
    /// <summary>
    /// ���ʂŗ��p����萔���`����N���X
    /// </summary>
    public static class Constants
    {
        /// <summary>
        /// �v�̃^�C�v
        /// </summary>
        public enum TileType
        {
            /// <summary>
            /// �ݎq
            /// </summary>
            Character,

            /// <summary>
            /// ���q
            /// </summary>
            Bamboo,

            /// <summary>
            /// ���q
            /// </summary>
            Circle,

            /// <summary>
            /// ���v
            /// </summary>
            /// <remarks>
            /// 1 = ��
            /// 2 = ��
            /// 3 = ��
            /// 4 = �k
            /// </remarks>
            Wind,

            /// <summary>
            /// �O���v
            /// </summary>
            /// <remarks>
            /// 1 = ��
            /// 2 = �
            /// 3 = ��
            /// </remarks>
            Dragon,
        }
    }
}
