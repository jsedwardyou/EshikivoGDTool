using UnityEngine;
using UnityEngine.Pool;

namespace Eshikivo.DesignPatterns
{
    public abstract class UnityObjectPool<T>: MonoBehaviour where T: UnityObjectPoolItem<T>
    {
        [SerializeField] private int poolSize;
        [SerializeField] private int maxPoolSize = 10000;
        [SerializeField] private GameObject poolItemPrefab;
        [SerializeField] private Transform poolItemContainer;

        private bool m_collectionChecks = true;
        private IObjectPool<T> m_pool;

        public IObjectPool<T> Pool
        {
            get
            {
                if (m_pool == null)
                {
                    m_pool = new ObjectPool<T>(
                        CreatePooledItem,
                        OnTakeFromPool,
                        OnReturnedToPool,
                        OnDestroyPoolObject,
                        m_collectionChecks,
                        poolSize,
                        maxPoolSize
                    );
                }

                return m_pool;
            }
        }

        protected virtual T CreatePooledItem()
        {
            var go = Instantiate(poolItemPrefab, poolItemContainer);
            var t = go.GetComponent<T>();

            t.pool = Pool;
            return t;
        }

        protected abstract void OnReturnedToPool(T source);

        protected abstract void OnTakeFromPool(T source);

        protected abstract void OnDestroyPoolObject(T source);


    }
}