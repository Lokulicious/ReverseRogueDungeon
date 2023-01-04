using System;
using JetBrains.Annotations;
using UnityEngine;
using Object = System.Object;

namespace ReverseRogueDungeon.Scripts.Managers
{
    public abstract class Manager<T> : MonoBehaviour where T : Manager<T>
    {
        public static T Instance { get; private set;}

        private void Awake() 
        {
            if (Instance != null) return;
            Instance = this as T;
            DontDestroyOnLoad(this);
        }
    }
}