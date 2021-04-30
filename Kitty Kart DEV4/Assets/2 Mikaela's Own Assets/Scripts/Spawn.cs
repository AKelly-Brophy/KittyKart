using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject[] KartPrefabs;
    public Transform[] SpawnPoints;

    // Start is called before the first frame update
    void Start()
    {

        foreach(Transform t in SpawnPoints)
        {
            GameObject kart = Instantiate(KartPrefabs[Random.Range(0, KartPrefabs.Length)]);
            kart.transform.position = t.position;
            kart.transform.rotation = t.rotation;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
