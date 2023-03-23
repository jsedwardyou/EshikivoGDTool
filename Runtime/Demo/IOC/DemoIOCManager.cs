using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Eshikivo.Demo
{
    public class DemoIOCManager : MonoBehaviour
    {
        private void Awake()
        {
            IOC.Register(this as object); // register as object to use overloaded method
        }

        public void TestMethod()
        {
            Debug.Log("DemoIOCManager Loaded!");
        }
    }

}