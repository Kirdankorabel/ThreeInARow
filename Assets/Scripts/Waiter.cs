using System;
using System.Collections;
using UnityEngine;

public static class Waiter
{
    public delegate bool BoolDel();
    public static IEnumerator WaitCorutine(float time, Action funk)
    {
        yield return new WaitForSeconds(time);
        funk?.Invoke();
        yield break;
    }

    public static IEnumerator WaitCorutine(float time)
    {
        Debug.Log(3);
        yield return new WaitForSeconds(time);
        Debug.Log(5);
        yield return null;
    }

    public static IEnumerator WaitFunkCorutine<T>(float time, Func<T> funk)
    {
        yield return new WaitForSeconds(time);
        T result = funk.Invoke();
        yield return result;
    }

    public static IEnumerator WaitCorutine(BoolDel predicate, Action funk)
    {
        while (predicate.Invoke())
        {
            yield return null;
        }
        funk?.Invoke();
        yield return null;
    }
}