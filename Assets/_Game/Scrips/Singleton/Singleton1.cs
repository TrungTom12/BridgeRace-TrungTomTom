using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton1<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T instance; 

    public static T Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindAnyObjectByType<T>();
                if (instance == null)
                {
                    instance = new GameObject().AddComponent<T>();
                }
            }
            return instance;
        }
    }

}
