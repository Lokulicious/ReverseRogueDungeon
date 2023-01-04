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

        [SerializeReference] [Range(0,1)] private float difficulty;
    }
}