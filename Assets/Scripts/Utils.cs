using System.Collections;
using UnityEngine;

class Utils{

    public delegate void Subroutine();

    public static IEnumerator CreateLoopCoroutine(Subroutine method, float deltaTime)
    {
        while (true)
        {
            yield return new WaitForSeconds(deltaTime);
            method.DynamicInvoke();
        }
    }

    public static IEnumerator ExecuteAfterTime(Subroutine method, float deltaTime)
    {
        yield return new WaitForSeconds(deltaTime);
        method.DynamicInvoke();
    }
}
