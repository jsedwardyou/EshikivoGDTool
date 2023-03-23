using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Eshikivo.DesignPatterns
{
    public class Singleton<T> : MonoBehaviour where T : Component
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
                        var obj = new GameObject(typeof(T).ToString());
                        s_instance = obj.AddComponent<T>();
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