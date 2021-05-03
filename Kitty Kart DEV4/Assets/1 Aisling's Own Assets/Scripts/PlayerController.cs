using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Drive ds;
    float lastTimeMoving = 0;
    Vector3 lastPosition;
    Quaternion lastRotation;

    CheckpointManager cpm;
    float finishSteer;

    void ResetLayer()
    {
        ds.rb.gameObject.layer = 0;
    }
    // Start is called before the first frame update
    void Start()
    {
        ds = this.GetComponent<Drive>();
        lastPosition = ds.rb.gameObject.transform.position;
        lastRotation = ds.rb.gameObject.transform.rotation;
        finishSteer = Random.Range(-1.0f, 1.0f);
    }

    // Update is called once per frame
    void Update()
    {
        if (cpm == null)
            cpm = ds.rb.GetComponent<CheckpointManager>();

        if (cpm.lap == RaceMonitor.totalLaps + 1)
        {

            ds.Go(0, finishSteer, 0);
            return;
        }

        float a = Input.GetAxis("Vertical");
        float s = Input.GetAxis("Horizontal");
        float b = Input.GetAxis("Jump");

        if (ds.rb.velocity.magnitude > 1 || !RaceMonitor.racing)
            lastTimeMoving = Time.time;

        RaycastHit hit;
        if (Physics.Raycast(ds.rb.gameObject.transform.position, -Vector3.up, out hit, 10))
        {
            if (hit.collider.gameObject.tag == "road")
            {
                lastPosition = ds.rb.gameObject.transform.position;
                lastRotation = ds.rb.gameObject.transform.rotation;
            }
        }

        if (Time.time > lastTimeMoving + 4)
        {
            ds.rb.gameObject.transform.position = cpm.lastCP.transform.position + Vector3.up * 2;
            ds.rb.gameObject.transform.rotation = cpm.lastCP.transform.rotation;
            ds.rb.gameObject.layer = 8;

            Invoke("ResetLayer", 3);
        }

        if (!RaceMonitor.racing) a = 0;

        ds.Go(a, s, b);
    }
}