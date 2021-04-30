using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothFollow : MonoBehaviour
{
    public Transform[] target;
    public static Transform playerKart;
    public float distance = 8.0f;
    public float height = 1.5f;
    public float heightOffset = 1.0f;
    public float heightDamping = 4.0f;
    public float rotationDamping = 2.0f;
    int index = 0;

    int FP = -1;

    void Start()
    {
        if (PlayerPrefs.HasKey("FP"))
        {
            FP = PlayerPrefs.GetInt("FP");
        }
    }

    void LateUpdate()
    {
        if (target == null)
        {
            GameObject[] karts = GameObject.FindGameObjectsWithTag("kart");
            target = new Transform[karts.Length];
            for (int i = 0; i < karts.Length; i++)
            {
                target[i] = karts[i].transform;
                if (target[i] == playerKart) index = i;
            }

            return;
        }

        if (FP == 1)
        {
            transform.position = target[index].position + target[index].forward * 0.4f + target[index].up;
            transform.LookAt(target[index].position + target[index].forward * 3f);
        }
        else
        {
            float wantedRotationAngle = target[index].eulerAngles.y;
            float wantedHeight = target[index].position.y + height;

            float currentRotationAngle = transform.eulerAngles.y;
            float currentHeight = transform.position.y;

            currentRotationAngle = Mathf.LerpAngle(currentRotationAngle, wantedRotationAngle, rotationDamping * Time.deltaTime);
            currentHeight = Mathf.Lerp(currentHeight, wantedHeight, heightDamping * Time.deltaTime);

            Quaternion currentRotation = Quaternion.Euler(0, currentRotationAngle, 0);

            transform.position = target[index].position;
            transform.position -= currentRotation * Vector3.forward * distance;

            transform.position = new Vector3(transform.position.x,
                                    currentHeight + heightOffset,
                                    transform.position.z);

            transform.LookAt(target[index]);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {

            FP *= -1;
            PlayerPrefs.SetInt("FP", FP);
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            index++;
            if (index > target.Length-1) index = 0;
        }
    }
}
