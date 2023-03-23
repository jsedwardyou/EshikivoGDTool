using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Eshikivo.Demo
{
    public class DemoIOCTestController : MonoBehaviour
    {
        private async void Start()
        {
            var manager = await IOC.Resolve<DemoIOCManager>();
            manager.TestMethod();
        }
    }

}