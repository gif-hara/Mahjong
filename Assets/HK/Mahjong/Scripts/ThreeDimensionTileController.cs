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

        private Tile tile;

        public void OnClicked()
        {
            Debug.Log(tile);
        }

        public ThreeDimensionTileController Rent(Tile tile)
        {
            var pool = poolBundle.Get(this);
            var instance = pool.Rent();
            instance.pool = pool;
            instance.tile = tile;

            return instance;
        }

        public void Return()
        {
            pool.Return(this);
        }
    }
}
