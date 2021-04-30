using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class Drive : MonoBehaviour
{
    public WheelCollider [] WCs;
    public GameObject [] Wheels;

    public float torque = 200;
    public float maxSteerAngle = 30;

    public float maxBrakeTorque = 500;

    // public AudioSource skidSound;
    // public AudioSource highAccel;

    // public Transform SkidTrailPrefab;
    // Transform[] skidTrails = new Transform[4];

    // public ParticleSystem smokePrefab;
    // ParticleSystem[] skidSmoke = new ParticleSystem[4];

    // public GameObject brakeLight;

    //engine noise gear change
    public Rigidbody rb;
    public float gearLength = 3;
    public float currentSpeed { get {return rb.velocity.magnitude * gearLength;}}
    // public float lowPitch = 1f;
    // public float highPitch = 6f;
    public int numGears = 5;
    public float maxSpeed = 200;

    float rpm;
    int currentGear = 1;
    float currentGearPerc;

    // Mikaela's Code //
    public GameObject PlayerNamePrefab;
    string[] aiNames = { "Peter", "Lisa", "Jake", "Mary" };
    /////

    // Start is called before the first frame update
    void Start()
    {
        // WC = this.GetComponent<WheelCollider>();

        // for (int i=0; i<4; i++) {
        //     skidSmoke[i] = Instantiate(smokePrefab);
        //     skidSmoke[i].Stop();
        // }

        // brakeLight.SetActive(false);


        // Mikaela's Code //
        GameObject PlayerName = Instantiate(PlayerNamePrefab);
        PlayerName.GetComponent<NameUIController>().target = rb.gameObject.transform;
        PlayerName.GetComponent<Text>().text = "Player Name";
        /////////

    }

    public void Go(float accel, float steer, float brake)
    {
        accel = Mathf.Clamp(accel, -1, 1);
        steer = Mathf.Clamp(steer, -1, 1) * maxSteerAngle;
        brake = Mathf.Clamp(brake, 0, 1) * maxBrakeTorque;

        // if (brake != 0) {
        //     brakeLight.SetActive(true);
        // } else {
        //     brakeLight.SetActive(false);
        // }

        float thrustTorque = accel * torque;

        for(int i=0; i<4; i++) {
            WCs[i].motorTorque = thrustTorque;

            //only steer with front 2 wheels
            if(i < 2) {
                WCs[i].steerAngle = steer;
            } else {
                //brake on back wheels only
                WCs[i].brakeTorque = brake;
            }

            //aligns mesh with WheelCollider
            Quaternion quat;
            Vector3 position;
            WCs[i].GetWorldPose(out position, out quat);
            Wheels[i].transform.position = position;
            Wheels[i].transform.rotation = quat;
        }
    }

    // void CheckForSkid() {
    //     int numSkidding = 0;

    //     for(int i=0; i<4; i++) {
    //         WheelHit wheelHit;
    //         WCs[i].GetGroundHit(out wheelHit);

    //         if(Mathf.Abs(wheelHit.forwardSlip) >= 0.6f || Mathf.Abs(wheelHit.sidewaysSlip) >= 0.6f) {
                
    //             numSkidding++;
    //             if(!skidSound.isPlaying) {
    //                 skidSound.Play();
    //             }

    //             //particle systems
    //             skidSmoke[i].transform.position = WCs[i].transform.position - WCs[i].transform.up
    //             * WCs[i].radius;
    //             skidSmoke[i].Emit(1);
    //         }

    //         if(numSkidding == 0 && skidSound.isPlaying) {
    //             skidSound.Stop();
    //         }
    //     }
    // }

    //v6 Calculate EngineSound
    // void calculateEngineSound() {

    //     float gearPercentage = (1/(float)numGears);
    //     float targetGearFactor = Mathf.InverseLerp(gearPercentage * currentGear, gearPercentage * (currentGear + 1 ), Mathf.Abs(currentSpeed / maxSpeed));
    //     currentGearPerc = Mathf.Lerp(currentGearPerc, targetGearFactor, Time.deltaTime * 5f);

    //     var gearNumFactor = currentGear/ (float) numGears;
    //     rpm = Mathf.Lerp(gearNumFactor, 1, currentGearPerc);

    //     float speedPercentage = Mathf.Abs(currentSpeed/maxSpeed);
    //     float upperGearMax = ( 1 / (float)numGears) * (currentGear + 1 );
    //     float downGearMax = ( 1 / (float)numGears) * currentGear;

    //     if (currentGear >0  && speedPercentage < downGearMax)
    //         currentGear--;
    //     if (speedPercentage > upperGearMax && (currentGear < (numGears -1)))
    //         currentGear++;
            
    //         //pitch gets calculated here
    //         float pitch = Mathf.Lerp(lowPitch, highPitch, rpm);
    //         //bending the pitch of the audio source 
    //         highAccel.pitch = Mathf.Min(highPitch, pitch) * 0.25f;
            
    // }   

    // Update is called once per frame
    void Update() {
        float a = Input.GetAxis("Vertical");
        float s = Input.GetAxis("Horizontal");
        float b = Input.GetAxis("Jump");
        Go(a, s, b);

        // CheckForSkid();
        // calculateEngineSound();
    }
}