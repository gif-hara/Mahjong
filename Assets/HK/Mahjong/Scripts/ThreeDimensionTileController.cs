using HK.Framework;
using UnityEngine;
using UnityEngine.Assertions;

namespace HK.Mahjong
{
    /// <summary>
    /// 3次元空間上の1個単位の牌を制御するクラス
    /// </summary>
    public sealed class ThreeDimensionTileController : MonoBehaviour
    {
        private readonly static ObjectPoolBundle<ThreeDimensionTileController> poolBundle = new ObjectPoolBundle<ThreeDimensionTileController>();

        private ObjectPool<ThreeDimensionTileController> pool;

        public ThreeDimensionTileController Rent()
        {
            var pool = poolBundle.Get(this);
            var instance = pool.Rent();
            instance.pool = pool;

            return instance;
        }

        public void Return()
        {
            pool.Return(this);
        }
    }
}
