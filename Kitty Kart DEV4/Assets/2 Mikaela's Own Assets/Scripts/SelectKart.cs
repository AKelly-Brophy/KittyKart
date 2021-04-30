using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SelectKart : MonoBehaviour
{
    public GameObject[] karts;
    int currentKart = 0;

    public Button SelectButton;    

    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey("PlayerKart"))
        currentKart = PlayerPrefs.GetInt("PlayerKart");

        this.transform.LookAt(karts[currentKart].transform.position);    
    }

    // Update is called once per frame
    void Update()
    {
        // This creates a button component slot in Unity
        // if the button is clicked run the method SelectClick
        Button btn = SelectButton.GetComponent<Button>();
        btn.onClick.AddListener(SelectClick);

        // Set the kart index to the chosen kart
        // PlayerPrefs.SetInt("PlayerKart", currentKart);

    // To make the camera rotate and loop through the kart array
    Quaternion lookDir = Quaternion.LookRotation(karts[currentKart].transform.position - this.transform.position);
    this.transform.rotation = Quaternion.Slerp(transform.rotation, lookDir, Time.deltaTime);    
    }

    ///////////////////////////////////
    //////// BUTTONS ON CLICK /////////
    ///////////////////////////////////

    // This method turns off the Main Menu and activates the Options Menu
    public void SelectClick()
    {
        currentKart++;
        if (currentKart > karts.Length - 1)
        currentKart = 0;

        PlayerPrefs.SetInt("PlayerKart", currentKart);
        Debug.Log("Kart Selected:" + currentKart);
    }

}

