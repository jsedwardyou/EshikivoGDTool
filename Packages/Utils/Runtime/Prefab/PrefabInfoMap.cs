using System;
using System.Collections.Generic;
using Eshikivo.DesignPatterns;
using UnityEngine;

namespace Eshikivo.Utils.Prefab
{
    public class PrefabInfoMap: Singleton<PrefabInfoMap>
    {
        [SerializeField] private string[] components;
        [SerializeField] private string[] prefabPaths;
        
        private Dictionary<string, PrefabInfo> m_pathDict = new();
        
        protected override void Awake()
        {
            base.Awake();

            for (int i = 0; i < components.Length; i++)
            {
                m_pathDict.TryAdd(components[i], new PrefabInfo(components[i], prefabPaths[i]));
            }
        }

        public string GetPath<T>()
        {
            m_pathDict.TryGetValue(typeof(T).ToString(), out var info);

            if (info == null)
            {
                Debug.LogError($"Could not find {typeof(T)}");
                return null;
            }
            
            return info.prefabPath;
        }
    }

    [Serializable]
    public class PrefabInfo
    {
        [SerializeField] public string component;
        [SerializeField] public string prefabPath;

        public PrefabInfo(string component, string prefabPath)
        {
            this.component = component;
            this.prefabPath = prefabPath;
        }
    }
}