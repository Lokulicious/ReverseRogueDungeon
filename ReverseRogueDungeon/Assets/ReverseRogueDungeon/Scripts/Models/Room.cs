using JetBrains.Annotations;
using ReverseRogueDungeon.Scripts.Managers;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace ReverseRogueDungeon.Scripts.Models
{
    [CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Room", order = 1)]
    public class Room : ScriptableObject
    {

        [SerializeField] public string SceneName;
        public Scene Scene => SceneManager.GetSceneByName(SceneName);

        [Header("Doors")] 
        [CanBeNull] public Door Up;
        [CanBeNull] public Door Down;
        [CanBeNull] public Door Left;
        [CanBeNull] public Door Right;

        [SerializeReference] [Range(0,1)] private float difficulty;
    }
}