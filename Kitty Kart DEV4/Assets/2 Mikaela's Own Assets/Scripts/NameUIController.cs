using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NameUIController : MonoBehaviour
{
    public Text PlayerName;
    public Transform target;

    // Start is called before the first frame update
    void Start()
    {
        this.transform.SetParent(GameObject.Find("Canvas").GetComponent<Transform>(), false);  
        PlayerName = this.GetComponent<Text>(); 
    }

    // Update later
    void LateUpdate()
    {
        this.transform.position = Camera.main.WorldToScreenPoint(target.position + Vector3.up);
    }
}
