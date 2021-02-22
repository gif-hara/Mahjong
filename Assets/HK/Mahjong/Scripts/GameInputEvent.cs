using UniRx;
using UnityEngine;
using UnityEngine.Assertions;

namespace HK.Mahjong
{
    /// <summary>
    /// ゲーム中のキー入力に関するイベントを持つクラス
    /// </summary>
    public static class GameInputEvent
    {
        public static Subject<int> SelectTile = new Subject<int>();
    }
}
