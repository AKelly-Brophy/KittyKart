using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleHUD : MonoBehaviour
{
    public GameObject MiniMap;
    public GameObject RearCamera;
    public GameObject HelpHUD;
    public GameObject Hints;

    // Start is called before the first frame update
    void Awake()
    {
        HelpHUD.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            Debug.Log("MiniMap toggled");
            // Toggle game object mini map
            MiniMap.SetActive(!MiniMap.activeInHierarchy);
        }

        if (Input.GetKeyDown(KeyCode.V))
        {
            Debug.Log("Rear Camera toggled");
            // Toggle game object rear camera
            RearCamera.SetActive(!RearCamera.activeInHierarchy);            
        }
        
        if (Input.GetKeyDown(KeyCode.H))
        {
            Debug.Log("Helpd HUD toggled");
            // Toggle game object help hud
            HelpHUD.SetActive(!HelpHUD.activeInHierarchy); 
            Hints.SetActive(!Hints.activeInHierarchy); 
        }
    }
}
