using UnityEngine;
using UnityEngine.SceneManagement;

public class CallMainScene : MonoBehaviour
{
    public void CallScene()
    {
        var sceneMan = SceneManager.LoadSceneAsync(1, LoadSceneMode.Single);
        sceneMan.allowSceneActivation = true;
    }
}
