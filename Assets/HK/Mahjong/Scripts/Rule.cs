using UnityEngine;
using UnityEngine.Assertions;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace HK.Mahjong
{
    /// <summary>
    /// ÉQÅ[ÉÄÇÃÉãÅ[Éã
    /// </summary>
    [CreateAssetMenu(menuName = "HK/Mahjong/Rule")]
    public sealed class Rule : ScriptableObject
    {
        /// <summary>
        /// <inheritdoc cref="Mahjong.Deck"/>
        /// </summary>
        [SerializeField]
        private Deck deck = default;
        public Deck Deck => deck;

#if UNITY_EDITOR
        [ContextMenu("Setup As Default")]
        private void SetupAsDefault()
        {
            deck.AvailableTiles.Clear();

            for(var i=1; i<=9; i++)
            {
                deck.AvailableTiles.Add(new Tile(Constants.TileType.Character, i));
                deck.AvailableTiles.Add(new Tile(Constants.TileType.Bamboo, i));
                deck.AvailableTiles.Add(new Tile(Constants.TileType.Circle, i));
            }

            for (var i = 1; i <= 4; i++)
            {
                deck.AvailableTiles.Add(new Tile(Constants.TileType.Wind, i));
            }

            for (var i = 1; i <= 3; i++)
            {
                deck.AvailableTiles.Add(new Tile(Constants.TileType.Dragon, i));
            }

            EditorUtility.SetDirty(this);
        }
#endif
    }
}
