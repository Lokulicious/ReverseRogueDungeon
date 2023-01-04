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
        private Vector2Int position = new Vector2Int(1,0);
        private Room[,] world;
        private Room currentRoom => world[position.x, position.y];

        [Header("test")]
        public Room StartRoom;
        public Room EastRoom;

        private void Start()
        {
            // var random = new Random();
            // var seed = random.Next();
            // Debug.Log($"Seed: {seed}");
            // var worldGenerator = new RoomWorldGenerator(seed);
            // world = worldGenerator.newWorld(8, 8);
            world = new Room[2,1];
            world[0, 0] = StartRoom;
            world[1, 0] = EastRoom;
            
            LoadScene();
        }

        public void MoveUp()
        {
            if (position.y == world.GetLength(1)) return ;
            position.y++;
            LoadScene();
        }

        public void MoveDown()
        {
            if (position.y == 0) return;
            position.y--;
            LoadScene();
        }
        
        public void MoveLeft()
        {
            if (position.x == 0) return;
            position.x--;
            LoadScene();
        }
        
        public void MoveRight()
        {
            if (position.x == world.GetLength(0)) ;
            position.x++;
            LoadScene();
        }

        private async UniTask LoadScene()
        {
            Debug.Log($"LoadScene {position.ToString()} {currentRoom.SceneName}");
            Debug.Log($"VALID SCENE: {SceneManager.GetSceneByName($"_Developers/Peter/scene switch/{currentRoom.SceneName}").IsValid()}");
            await SceneManager.LoadSceneAsync($"_Developers/Peter/scene switch/{currentRoom.SceneName}");
        }
    }
}