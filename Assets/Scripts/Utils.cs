using System.Collections;
using UnityEngine;

class Utils{

    public delegate void Subroutine(); // subroutine

    public static IEnumerator CreateLoopCoroutine(Subroutine method, float deltaTime)
    {
        while (true)
        {
            method.DynamicInvoke();
            yield return new WaitForSeconds(deltaTime);
        }
    }
}
