using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

namespace HK.Mahjong
{
    /// <summary>
    /// �v���C���[���c�����<see cref="Tile"/>��ێ�����N���X
    /// </summary>
    [Serializable]
    public sealed class Deck
    {
        /// <summary>
        /// �Q�[���ɗ��p�\��<see cref="Tile"/>
        /// </summary>
        [SerializeField]
        private List<Tile> availableTiles = default;
        public List<Tile> AvailableTiles => availableTiles;
    }
}
