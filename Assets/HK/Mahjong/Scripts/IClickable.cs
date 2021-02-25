using UnityEngine;
using UnityEngine.Assertions;

namespace HK.Mahjong
{
    /// <summary>
    /// クリック可能なインターフェイス
    /// </summary>
    public interface IClickable
    {
        /// <summary>
        /// クリックされた際のイベント
        /// </summary>
        void OnClicked();
    }
}
