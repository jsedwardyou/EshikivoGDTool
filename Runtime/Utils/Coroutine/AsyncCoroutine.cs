using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

namespace Eshikivo.Utils
{
    public class AsyncCoroutine
    {
        private TaskCompletionSource<object> m_tcs;
        private Coroutine m_coroutine;
        private MonoBehaviour m_mono;
        
        public Task Task => m_tcs?.Task;
        
        public AsyncCoroutine(MonoBehaviour mono, IEnumerator coroutine)
        {
            m_mono = mono;
            m_tcs = new TaskCompletionSource<object>();
            m_coroutine = mono.StartCoroutine(AsyncCoroutineWrapper(coroutine));
        }

        public bool Stop()
        {
            if (m_tcs == null || m_coroutine == null) return false;

            if (m_tcs.Task.IsCompleted) return false;
            
            m_mono.StopCoroutine(m_coroutine);
            m_tcs.TrySetResult(null);

            return true;
        }

        private IEnumerator AsyncCoroutineWrapper(IEnumerator coroutine)
        {
            yield return coroutine;

            m_tcs.TrySetResult(null);
        }
    }
}
