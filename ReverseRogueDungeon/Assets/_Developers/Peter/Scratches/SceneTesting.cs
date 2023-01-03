using ReverseRogueDungeon.Scripts.Managers;

using UnityEngine;
using UnityEngine.SceneManagement;

namespace _Developers.Peter.Scratches
{
    public class SceneTesting : Manager<SceneTesting>
    {
        [SerializeField] private string sceneOne;
        [SerializeField] private string sceneTwo;
        
        public void PreloadSceneOne()
        {
            PreloadSceneManager.Instance.PreloadSceneAsync(sceneOne,LoadSceneMode.Single);
        }

        public void LoadSceneOne()
        {
            PreloadSceneManager.Instance.LoadSceneAsyncAndClear(sceneOne, LoadSceneMode.Single);
        }
        public void PreloadSceneTwo()
        {
            PreloadSceneManager.Instance.PreloadSceneAsync(sceneTwo,LoadSceneMode.Single);
        }

        public void LoadSceneTwo()
        {
            PreloadSceneManager.Instance.LoadSceneAsyncAndClear(sceneTwo, LoadSceneMode.Single);
        }
    }
}