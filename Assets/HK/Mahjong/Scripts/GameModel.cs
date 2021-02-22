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

        public GameModel(Rule rule, Field field)
        {
            Rule = rule;
            Field = field;
        }
    }
}