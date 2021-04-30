using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIController : MonoBehaviour
{
    Drive ds;
    public Circuit circuit;    
    public float steeringSensitivity = 0.01f;
    Vector3 target;
    Vector3 nextTarget;
    int currentWP = 0;
    float totalDistanceToTarget;


    // Start is called before the first frame update
    void Start()
    {
        if (circuit == null)
            circuit = GameObject.FindGameObjectWithTag("circuit").GetComponent<Circuit>();
            
        ds = this.GetComponent<Drive>();
        target = circuit.Waypoints[currentWP].transform.position;
        nextTarget = circuit.Waypoints[currentWP + 1].transform.position;
        totalDistanceToTarget = Vector3.Distance(target, ds.rb.gameObject.transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 localTarget = ds.rb.gameObject.transform.InverseTransformPoint(target);
        float distanceToTarget = Vector3.Distance(target, ds.rb.gameObject.transform.position);

        float targetAngle = Mathf.Atan2(localTarget.x, localTarget.z) * Mathf.Rad2Deg;

        float steer = Mathf.Clamp(targetAngle * steeringSensitivity, -1, 1) * Mathf.Sign(ds.currentSpeed);
        float distanceFactor = distanceToTarget / totalDistanceToTarget;

        float accel = 0.3f;
        float brake = Mathf.Lerp(-1, 1, 1 - distanceFactor);

        // if (distanceToTarget < 8) { brake = 0.08f; accel = 0.01f; }

        ds.Go(accel, steer, brake);

        if (distanceToTarget < 20)
        {
            currentWP++;
            if (currentWP >= circuit.Waypoints.Length)
                currentWP = 0;
            target = circuit.Waypoints[currentWP].transform.position;
            totalDistanceToTarget = Vector3.Distance(target, ds.rb.gameObject.transform.position);
        } 
    }
}
