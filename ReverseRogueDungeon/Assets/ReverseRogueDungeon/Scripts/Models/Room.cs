using ReverseRogueDungeon.Scripts.Managers;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace ReverseRogueDungeon.Scripts.Models
{
    public class Room : ScriptableObject
    {
        [Required] public Scene Scene;

        [Header("Doors")]
        public Door Up;
        public Door Down;
        public Door Left;
        public Door Right;

        [SerializeReference] [Range(0,1)] private float difficulty;
    }
}