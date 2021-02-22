using UnityEngine;
using UnityEngine.Assertions;
using System.Collections.Generic;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace HK.Mahjong
{
    /// <summary>
    /// ゲームのルール
    /// </summary>
    [CreateAssetMenu(menuName = "HK/Mahjong/Rule")]
    public sealed class Rule : ScriptableObject
    {
        /// <summary>
        /// ゲームに利用可能な<see cref="Tile"/>
        /// </summary>
        [SerializeField]
        private List<Tile> availableTiles = default;
        public List<Tile> AvailableTiles => availableTiles;

#if UNITY_EDITOR
        [ContextMenu("Setup As Default")]
        private void SetupAsDefault()
        {
            availableTiles.Clear();

            for(var i=1; i<=9; i++)
            {
                availableTiles.Add(new Tile(Constants.TileType.Character, i));
                availableTiles.Add(new Tile(Constants.TileType.Bamboo, i));
                availableTiles.Add(new Tile(Constants.TileType.Circle, i));
            }

            for (var i = 1; i <= 4; i++)
            {
                availableTiles.Add(new Tile(Constants.TileType.Wind, i));
            }

            for (var i = 1; i <= 3; i++)
            {
                availableTiles.Add(new Tile(Constants.TileType.Dragon, i));
            }

            EditorUtility.SetDirty(this);
        }
#endif
    }
}
