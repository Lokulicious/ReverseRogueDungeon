using System;
using JetBrains.Annotations;
using ReverseRogueDungeon.Scripts.Managers;
using UnityEditor.U2D.Animation;
using UnityEngine;
using UnityEngine.Events;

namespace ReverseRogueDungeon.Scripts.Models
{
    public class Door : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            switch (gameObject.tag)
            {
                case "UpDoor":
                    RoomsManager.Instance.MoveUp();
                    break;
                case "DownDoor":
                    RoomsManager.Instance.MoveDown();
                    break;
                case "LeftDoor":
                    RoomsManager.Instance.MoveLeft();
                    break;
                case "RightDoor":
                    RoomsManager.Instance.MoveRight();
                    break;
            }
        }

        private void Test()
        {
            OnTriggerEnter(null);
        }

        
    }
}