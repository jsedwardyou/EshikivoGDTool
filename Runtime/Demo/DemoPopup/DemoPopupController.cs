using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Eshikivo.Demo
{
    /// <summary>
    /// In order to use popup:
    /// 1. Place PrefabInfoMap in the scene
    /// 2. Update PrefabInfoMap by Eshikivo/Prefab/Rebuild Resources
    /// 3. Implement DemoPopup..., DemoPopupParam, DemoPopupResult
    /// 4. Use
    /// </summary>
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
