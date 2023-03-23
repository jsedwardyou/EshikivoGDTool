using UnityEngine;
using UnityEngine.Pool;

namespace Eshikivo.DesignPatterns
{
    public class UnityObjectPoolItem<T>: MonoBehaviour where T: UnityObjectPoolItem<T>
    {
        public IObjectPool<T> pool;
    }
}