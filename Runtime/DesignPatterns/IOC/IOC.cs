using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class IOCContainer
{
    private class IOCItem
    {
        public object Instance;

        public IOCItem(object instance)
        {
            Instance = instance;
        }
    }

    private Dictionary<Type, IOCItem> m_registered = new();
    private Dictionary<Type, Queue<TaskCompletionSource<object>>> m_waitingQueueMap = new();

    public void Register<T>(T instance)
    {
        m_registered.TryAdd(typeof(T), new IOCItem(instance));
        OnRegister(instance);
    }

    public void Register(object instance)
    {
        m_registered.TryAdd(instance.GetType(), new IOCItem(instance));
        
        OnRegister(instance);
    }

    public async Task<T> Resolve<T>()
    {
        if (m_registered.TryGetValue(typeof(T), out var item))
        {
            return (T)item.Instance;
        }

        TaskCompletionSource<object> tcs = new TaskCompletionSource<object>();

        Queue<TaskCompletionSource<object>> waitQueue = null;
        if (!m_waitingQueueMap.TryGetValue(typeof(T), out waitQueue))
        {
            waitQueue = new Queue<TaskCompletionSource<object>>();
            m_waitingQueueMap.Add(typeof(T), waitQueue);
        }

        waitQueue.Enqueue(tcs);

        var result = await tcs.Task;
        
        return (T)result;
    }

    private void OnRegister<T>(T instance)
    {
        if (!m_waitingQueueMap.TryGetValue(typeof(T), out var waitQueue)) return;

        while (waitQueue.Count != 0)
        {
            var tcs = waitQueue.Dequeue();
            tcs.TrySetResult(instance);
        }
    }
}

public static class IOC
{
    private static IOCContainer m_container;
    
    public static void Register<T>(T instance)
    {
        m_container.Register(instance);
    }

    public static void Register(object instance)
    {
        m_container.Register(instance);
    }

    public static async Task<T> Resolve<T>()
    {
        return await m_container.Resolve<T>();
    }

    static IOC()
    {
        m_container = new IOCContainer();
    }
}