using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WinLossMenu : MonoBehaviour
{
    Scene scene;
    public string MainGame, Track2;

    void Start() {
        scene = SceneManager.GetActiveScene();
    }

    public void Replay()
    {
        if(scene.name == MainGame ) {
            SceneManager.LoadScene("MainGame");
        } else {
            SceneManager.LoadScene("Track2");
        }
    }


    public void TrackSelect()
    {
        SceneManager.LoadScene("TrackSelect");
    }

    public void ExitToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
