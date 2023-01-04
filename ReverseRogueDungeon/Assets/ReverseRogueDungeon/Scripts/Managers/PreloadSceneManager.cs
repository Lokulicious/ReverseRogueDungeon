using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace ReverseRogueDungeon.Scripts.Managers
{
    public class PreloadSceneManager : Manager<PreloadSceneManager>
    {
        private readonly Dictionary<string, AsyncOperation> sceneLoadAsyncOperations = new();

        public AsyncOperation PreloadSceneAsync(string sceneName, LoadSceneMode loadSceneMode)
        {
            if (sceneLoadAsyncOperations.TryGetValue(key: sceneName, value: out AsyncOperation loadSceneAsyncOperation))
                return loadSceneAsyncOperation;

            loadSceneAsyncOperation = SceneManager.LoadSceneAsync(
                sceneName: sceneName,
                mode: loadSceneMode
            );


            loadSceneAsyncOperation.allowSceneActivation = false;

            sceneLoadAsyncOperations.Add(
                key: sceneName,
                value: loadSceneAsyncOperation
            );
        
            return loadSceneAsyncOperation;
        }

        public AsyncOperation LoadSceneAsync(string sceneName, LoadSceneMode loadSceneMode)
        {
            if (sceneLoadAsyncOperations.TryGetValue(key: sceneName, value: out AsyncOperation loadSceneAsyncOperation))
            {
                loadSceneAsyncOperation.allowSceneActivation = true;

                return loadSceneAsyncOperation;
            }
        
            loadSceneAsyncOperation = SceneManager.LoadSceneAsync(
                sceneName: sceneName,
                mode: loadSceneMode
            );
        
            return loadSceneAsyncOperation;
        }

        public AsyncOperation LoadSceneAsyncAndClear(string sceneName, LoadSceneMode loadSceneMode)
        {
            foreach (var sceneLoadAsyncOperationPair in sceneLoadAsyncOperations)
            {
                if (sceneLoadAsyncOperationPair.Key == sceneName) continue; 
                sceneLoadAsyncOperationPair.Value.allowSceneActivation = true;
            }

            return LoadSceneAsync(sceneName, loadSceneMode);
        }
    }
}