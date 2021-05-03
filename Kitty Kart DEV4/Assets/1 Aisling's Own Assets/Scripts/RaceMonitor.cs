using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RaceMonitor : MonoBehaviour    
{
    Scene scene;
    public string MainGame, Track2;
    CheckpointManager[] kartCPM;

    public GameObject[] kartPrefabs;
    public Transform[] spawnPos;
    //boolean to start the race
    public static bool racing = true;
    public static int totalLaps = 1;
    // public GameObject gameOverPanel;
    public GameObject HUD;

    bool win;
    bool lose;

    int playerKart;

    // Start is called before the first frame update
    void Start()
    {
        scene = SceneManager.GetActiveScene();

        //gets the Int of the car the player selected. 
        playerKart = PlayerPrefs.GetInt("PlayerKart");

        //asign a random index to retriev start pos
        int randomStartPos = Random.Range(0, spawnPos.Length);
        //asign random startPos and startRot for singlePlayer
        Vector3 startPos = spawnPos[randomStartPos].position;
        Quaternion startRot = spawnPos[randomStartPos].rotation;
        
        GameObject pKart = null;

        SmoothFollow.playerKart = pKart.gameObject.GetComponent<Drive>().rb.transform;
        pKart.GetComponent<AIController>().enabled = false;
        pKart.GetComponent<Drive>().enabled = true;
        pKart.GetComponent<PlayerController>().enabled = true;

    }
    
    public void StartGame() {

        //moved from Start -> cars need to be found first
        GameObject[] karts = GameObject.FindGameObjectsWithTag("kart");
        kartCPM = new CheckpointManager[karts.Length];
        for (int i = 0; i < karts.Length; i++)
            kartCPM[i] = karts[i].GetComponent<CheckpointManager>();
    }

    public void RestartLevel()
    {
        racing = false;

        if(scene.name == "Track1") {
            SceneManager.LoadScene("Track1");
        } else if (scene.name == "Track2") {
            SceneManager.LoadScene("Track2");
        }
    }


    void LateUpdate()
    {   
        //exit LateUpdate if NOT racing as CPM only exists after StartGame method
        if(!racing)  return;
        int finishedCount = 0;
        foreach (CheckpointManager cpm in kartCPM)
        {
            if (cpm.lap == totalLaps + 1)
                finishedCount++;
        }
        if (finishedCount == kartCPM.Length)
        {
            HUD.SetActive(false);
            
            if(win = true) {
                SceneManager.LoadScene("Win Scene");
            } else {
                SceneManager.LoadScene("Lose Scene");
            }
        }
    }
}
