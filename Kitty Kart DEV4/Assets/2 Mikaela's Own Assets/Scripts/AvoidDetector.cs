using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvoidDetector : MonoBehaviour
{
    public float avoidPath = 0;
    public float avoidTime = 0;
    public float wanderDistance = 4; //avoiding distance
    public float avoidLength = 1;   //1 sec

    void OnCollisionExit(Collision col)
    {
        if (col.gameObject.tag != "kart") return;
        avoidTime = 0;
    }

    void OnCollisionStay(Collision col)
    {
        if (col.gameObject.tag != "kart") return;

        Rigidbody otherkart = col.rigidbody;
        avoidTime = Time.time + avoidLength;

        Vector3 otherkartLocalTarget = transform.InverseTransformPoint(otherkart.gameObject.transform.position);
        float otherkartAngle = Mathf.Atan2(otherkartLocalTarget.x, otherkartLocalTarget.z);
        avoidPath = wanderDistance * -Mathf.Sign(otherkartAngle);
    }
}
