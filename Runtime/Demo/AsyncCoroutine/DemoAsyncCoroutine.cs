using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Eshikivo.Utils;
using UnityEngine;

namespace Eshikivo.Demo
{
    public class DemoAsyncCoroutine : MonoBehaviour
    {
        async void Start()
        {
            var asyncCoroutine = new AsyncCoroutine(this, CountThree());

            await asyncCoroutine.Task;
            
            Debug.Log("Task Complete");

            var stoppingAsyncCoroutine = new AsyncCoroutine(this, CountThree());
            StartCoroutine(StopAsyncCoroutine(stoppingAsyncCoroutine));

            await stoppingAsyncCoroutine.Task;
            
            Debug.Log(stoppingAsyncCoroutine.Task.IsCanceled);
            Debug.Log("Done!");
        }

        private IEnumerator CountThree()
        {
            for (int i = 1; i <= 3; i++)
            {
                Debug.Log(i);
                yield return new WaitForSeconds(1);
            }
        }

        private IEnumerator StopAsyncCoroutine(AsyncCoroutine asyncCo)
        {
            yield return new WaitForSeconds(2);
            asyncCo.Stop();
        }
    }
}
