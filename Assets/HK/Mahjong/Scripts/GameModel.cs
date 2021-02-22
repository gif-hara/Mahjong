using System.Collections.Generic;
using UniRx;
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

        /// <summary>
        /// ターン数
        /// </summary>
        public ReactiveProperty<int> Turn { get; }

        /// <summary>
        /// 現在行動中の<see cref="Player"/>を返す
        /// </summary>
        public Player CurrentPlayer => Players[Turn.Value % Players.Count];

        public GameModel(Rule rule, Field field, List<Player> players)
        {
            Rule = rule;
            Field = field;
            Players = players;
            Turn = new ReactiveProperty<int>(0);
        }
    }
}
