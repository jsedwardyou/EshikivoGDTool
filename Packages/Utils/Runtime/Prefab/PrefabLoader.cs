using System.IO;
using Eshikivo.DesignPatterns;
using UnityEngine;

namespace Eshikivo.Utils.Prefab
{
    public class PrefabLoader: Singleton<PrefabLoader>
    {
        public GameObject LoadPrefab(string path, Transform container=null)
        {
            var prefab = Resources.Load<GameObject>(path);

            if (prefab == null) return null;
            
            var go = Instantiate(prefab, container);
            return go;
        }

        public GameObject LoadPrefab(string prefabDirectory, string prefabName, Transform container = null)
        {
            return LoadPrefab(Path.Combine(prefabDirectory, prefabName), container);
        }

        public T LoadPrefab<T>(Transform container=null)
        {
            string path = PrefabInfoMap.Instance.GetPath<T>();
            GameObject go = LoadPrefab(path, container);

            if (go == null) return default(T);

            return go.GetComponent<T>();
        }
    }
}