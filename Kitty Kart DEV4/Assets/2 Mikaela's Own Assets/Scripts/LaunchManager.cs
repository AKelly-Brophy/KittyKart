using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LaunchManager : MonoBehaviour
{
    public InputField PlayerName;

    //////////////////////////////
    //////// NAME MANAGER ////////
    //////////////////////////////

    // Start is called before the first frame update
    void Start()
    {   
        // Get player's name that was entered in the input field and save it in PlayerPrefs
        if (PlayerPrefs.HasKey("PlayerName"))
        PlayerName.text = PlayerPrefs.GetString("PlayerName");        
    }


    // Set the name
    public void SetName(string name)
    {
        PlayerPrefs.SetString("PlayerName", name);
    }


    ///////////////////////////////
    //////// SCENE MANAGER ////////
    ///////////////////////////////

    public void QuitGame()
    {
        Application.Quit();
    }

    public void SingleplayerGame()
    {   
        // If singleplayer button is pressed load the track for singleplayer
        SceneManager.LoadScene("MainGame");
    }

    public void MultiplayerGame()
    {   
        // If multiplayer button is pressed load the track for multiplayer
        SceneManager.LoadScene("MultiplayerTrack");
    }


    // Update is called once per frame
    void Update()
    {
        
    }

}
