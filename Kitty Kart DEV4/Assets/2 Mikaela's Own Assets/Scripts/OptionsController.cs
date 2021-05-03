using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OptionsController : MonoBehaviour
{
    public Button ResumeButton;
    public Button OptionsButton;
    public GameObject HelpHUD;
    public GameObject Hints;
    public GameObject PauseMenu;
    public GameObject OptionsMenu;
    public AudioSource AudioSource;
    public float MusicVolume = 1f;

    void Awake()
    {
        OptionsMenu.SetActive(false);
        PauseMenu.SetActive(false);
    }
    
    void Update()
    {
        Button resumebtn = ResumeButton.GetComponent<Button>();
        resumebtn.onClick.AddListener(ResumeOnClick);

        Button optionsbtn = OptionsButton.GetComponent<Button>();
        optionsbtn.onClick.AddListener(OptionsOnClick);


        AudioSource.volume = MusicVolume;

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("Pause Menu is toggled");
            PauseMenu.SetActive(!PauseMenu.activeInHierarchy); 
            HelpHUD.SetActive(false);    
        }
    }
   
    //////////////
    // On Click //
    //////////////
    public void ResumeOnClick()
    {
        OptionsMenu.SetActive(false);
        Hints.SetActive(true);
    }

    public void OptionsOnClick()
    {
        OptionsMenu.SetActive(true);
        PauseMenu.SetActive(false);        
    }

    ////////////
    // Volume //
    ////////////
    public void SetVolume (float volume) 
    {
        MusicVolume = volume;
    }

    ////////////////
    // Fullscreen //
    ////////////////
    public void ToggleFullscreen (bool isFullScreen)
    {
        Screen.fullScreen = isFullScreen;
        Debug.Log("Toggling Fullscreen");
    }

    ////////////
    // Scenes //
    ////////////
    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");     
    }

    public void SelectTrack()
    {
        SceneManager.LoadScene("TrackSelect");     
    }

    ///////////////
    // Quit Game //
    ///////////////

    public void QuitGame()
    {
        Debug.Log("Quitting game");
        Application.Quit();
    }
}
