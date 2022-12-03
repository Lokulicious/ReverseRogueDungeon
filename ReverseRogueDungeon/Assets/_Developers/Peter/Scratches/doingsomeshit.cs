using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;


public class doingsomeshit : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    async UniTask Test()
    {
        await UniTask.Delay(500);
        SceneManager.SetActiveScene(SceneManager.GetSceneByName("Main"));
    }

}
