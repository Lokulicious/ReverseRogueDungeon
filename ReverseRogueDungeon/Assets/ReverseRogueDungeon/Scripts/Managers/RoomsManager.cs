using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.Triggers;
using ReverseRogueDungeon.Scripts.Models;
using Sirenix.OdinInspector;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
using Random = System.Random;

namespace ReverseRogueDungeon.Scripts.Managers
{
    public class RoomsManager : Manager<RoomsManager>
    {
        private Vector2Int position = new Vector2Int(4,4);
        private Room[,] world;
        private Room currentRoom => world[position.x, position.y];

        private void Start()
        {
            var random = new Random();
            var seed = random.Next();
            Debug.Log($"Seed: {seed}");
            var worldGenerator = new RoomWorldGenerator(seed);
            world = worldGenerator.newWorld(8, 8);

        }

        public void MoveUp()
        {
            UnloadScene();
            position.y++;
            LoadScene();
        }

        public void  MoveDown()
        {
            UnloadScene();
            position.y--;
            LoadScene();
        }
        
        public void MoveLeft()
        {
            UnloadScene();
            position.x--;
            LoadScene();
        }
        
        public void MoveRight()
        {
            UnloadScene();
            position.x++;
            LoadScene();
        }

        private void LoadScene()
        {
            currentRoom.Down.OnTriggerEnterEvent.AddListener(MoveDown);
            currentRoom.Up.OnTriggerEnterEvent.AddListener(MoveUp);
            currentRoom.Left.OnTriggerEnterEvent.AddListener(MoveLeft);
            currentRoom.Right.OnTriggerEnterEvent.AddListener(MoveRight);
            SceneManager.LoadScene(currentRoom.Scene.handle);
        }
        
        private void UnloadScene()
        {
            currentRoom.Down.OnTriggerEnterEvent.RemoveListener(MoveDown);
            currentRoom.Up.OnTriggerEnterEvent.RemoveListener(MoveUp);
            currentRoom.Left.OnTriggerEnterEvent.RemoveListener(MoveLeft);
            currentRoom.Right.OnTriggerEnterEvent.RemoveListener(MoveRight);
        }
    }
}