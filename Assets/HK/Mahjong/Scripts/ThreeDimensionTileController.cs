using HK.Framework;
using UnityEngine;
using UnityEngine.Assertions;

namespace HK.Mahjong
{
    /// <summary>
    /// 3次元空間上の1個単位の牌を制御するクラス
    /// </summary>
    public sealed class ThreeDimensionTileController : MonoBehaviour, IClickable
    {
        private readonly static ObjectPoolBundle<ThreeDimensionTileController> poolBundle = new ObjectPoolBundle<ThreeDimensionTileController>();

        private ObjectPool<ThreeDimensionTileController> pool;

        /// <summary>
        /// 手牌のID
        /// </summary>
        /// <remarks>
        /// ウンコードの匂いがする
        /// </remarks>
        private int handIndex;

        private Tile tile;

        public void OnClicked()
        {
            GameInputEvent.SelectTile.OnNext(handIndex);
        }

        /// <summary>
        /// 手牌として生成する
        /// </summary>
        public ThreeDimensionTileController RentAsHandTile(int handIndex, Tile tile)
        {
            var pool = poolBundle.Get(this);
            var instance = pool.Rent();
            instance.pool = pool;
            instance.handIndex = handIndex;
            instance.tile = tile;

            return instance;
        }

        public void Return()
        {
            pool.Return(this);
        }
    }
}
