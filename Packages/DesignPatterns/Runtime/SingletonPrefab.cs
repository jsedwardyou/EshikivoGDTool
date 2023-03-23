using System;
using System.IO;
using Eshikivo.Utils.Prefab;
using UnityEngine;

namespace Eshikivo.DesignPatterns
{
    public class SingletonPrefab<T>: PrefabResource where T : Component
    {
        protected static T s_instance;

        public static T Instance
        {
            get
            {
                if (s_instance == null)
                {
                    s_instance = FindObjectOfType<T>();
                    if (s_instance == null)
                    {
                        var obj = Instantiate(PrefabLoader.Instance.LoadPrefab<T>());
                        s_instance = obj.GetComponent<T>();
                    }
                }

                return s_instance;
            }
        }

        protected virtual void Awake()
        {
            if (!Application.isPlaying) return;

            s_instance = this as T;
        }
    }
}