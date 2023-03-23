using System;
using System.Collections;
using UnityEngine;

namespace Packages.Utils
{
    public class Playable: MonoBehaviour
    {
        private Coroutine m_playCo = null;
        
        public Action OnComplete;
        public bool IsPlaying => m_playCo != null;

        public void Play()
        {
            m_playCo = StartCoroutine(PlayCo());
        }

        public void Stop()
        {
            if (m_playCo != null)
            {
                StopCoroutine(m_playCo);
            }

            m_playCo = null;
        }

        private IEnumerator PlayCo()
        {
            yield return MainCo();

            OnComplete?.Invoke();
            Stop();
        }

        protected virtual IEnumerator MainCo()
        {
            yield return null;
        }
    }
}