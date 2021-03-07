using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : Component
{
    private static T instance;
    
    public static T Instance { get{ return returnInstance(); } }

    private static T returnInstance()
    {
        instance = FindObjectOfType<T>();

        if( instance == null )
        {
            GameObject g = new GameObject();
            g.AddComponent<T>();
            g.name = typeof(T).Name;
        }

        return instance;
    }

    public virtual void Awake()
    {
        if( instance == null )
        {
            instance = this as T;
            DontDestroyOnLoad( gameObject );
        }else{
            Destroy( gameObject );
        }
    }
}
