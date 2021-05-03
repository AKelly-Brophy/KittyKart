using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TrackSelectScreen : MonoBehaviour
{

    void Start() {

    }

    public void PlayTrack1()
    {
        SceneManager.LoadScene("MainGame");
        
    }

    public void PlayTrack2()
    {
        SceneManager.LoadScene("Track2");
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
