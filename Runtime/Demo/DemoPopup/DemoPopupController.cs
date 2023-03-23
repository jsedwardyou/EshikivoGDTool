using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Eshikivo.Demo
{
    public class DemoPopupController : MonoBehaviour
    {
        private async void Start()
        {
            var demoParams = new DemoPopupMessageParam()
            {
                Messages = new []{"test1", "test2", "test3"}
            };

            var result = await DemoPopupMessage.OpenPopup(demoParams);
            
            Debug.Log(result.GetMessage());
        }
    }
}
