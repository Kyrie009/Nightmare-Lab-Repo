using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBehaviour:MonoBehaviour
{
    // Managers
    protected static Player        _PLAYER { get { return Player.INSTANCE; } }
    protected static Enemy         _ENEMY { get { return Enemy.INSTANCE; } }
    protected static CombatManager _CM { get { return CombatManager.INSTANCE; } }

    protected static Navigation     _NAV { get { return Navigation.INSTANCE; } }
}

public class Singleton <T>:GameBehaviour where T:MonoBehaviour
{
    private static T instance_;
    public static T INSTANCE
    {
        get
        {
            if (instance_ == null)
            {
                instance_ = GameObject.FindObjectOfType<T>();
                if (instance_ == null)
                {
                    GameObject singleton = new GameObject(typeof(T).Name);
                    singleton.AddComponent<T>(); // Awake gets gets called called inside AddComponent
                }
            }
            return instance_;
        }
    }
    protected virtual void Awake ()
    { if (instance_ == null )
        {
            instance_ =this as T;
            //DontDestroyOnLoad (gameObject );
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
