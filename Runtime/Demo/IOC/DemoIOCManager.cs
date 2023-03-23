using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
