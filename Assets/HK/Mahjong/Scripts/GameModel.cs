using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

namespace HK.Mahjong
{
    /// <summary>
    /// ゲームモデルクラス
    /// </summary>
    public sealed class GameModel
    {
        public Rule Rule { get; }

        public Field Field { get; }

        public List<Player> Players { get; }

        public GameModel(Rule rule, Field field, List<Player> players)
        {
            Rule = rule;
            Field = field;
            Players = players;
        }
    }
}
