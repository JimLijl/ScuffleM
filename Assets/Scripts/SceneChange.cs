using UnityEngine;
using System.Collections;

public class SceneChange : MonoBehaviour {

    public void OnStartGame(string SceneName)
    {
        Application.LoadLevel(SceneName);
    }
}
