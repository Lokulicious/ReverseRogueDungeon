using System;
using UnityEditor.U2D.Animation;
using UnityEngine;
using UnityEngine.Events;

namespace ReverseRogueDungeon.Scripts.Models
{
    public class Door : MonoBehaviour
    {
        public UnityEvent OnTriggerEnterEvent = new();
        private void OnTriggerEnter(Collider other)
        {
            OnTriggerEnterEvent.Invoke();
        }
    }
}