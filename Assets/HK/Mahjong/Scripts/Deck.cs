using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

namespace HK.Mahjong
{
    /// <summary>
    /// プレイヤーがツモれる<see cref="Tile"/>を保持するクラス
    /// </summary>
    [Serializable]
    public sealed class Deck
    {
        /// <summary>
        /// ゲームに利用可能な<see cref="Tile"/>
        /// </summary>
        [SerializeField]
        private List<Tile> availableTiles = default;
        public List<Tile> AvailableTiles => availableTiles;
    }
}
