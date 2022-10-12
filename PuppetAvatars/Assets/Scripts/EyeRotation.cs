using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeRotation : MonoBehaviour
{
    public float rightLimit, leftLimit, upLimit, downLimit;//left limit should be negative
    public GameObject rightEye, leftEye;
    public float sensitivity;

    // Start is called before the first frame update
    void Start()
    {
        //set the things to defaults if left empty after you know what good defaults are
    }

    //limits aren't working yet
    public void RotateRight()
    {
        if(rightEye.transform.localEulerAngles.y < rightLimit)
        {
            rightEye.transform.Rotate(new Vector3(0.0f, sensitivity, 0.0f), Space.Self);
            leftEye.transform.Rotate(new Vector3(0.0f, sensitivity, 0.0f), Space.Self);
        }
    }
    public void RotateLeft()
    {
        if (rightEye.transform.localEulerAngles.y > leftLimit)
        {
            rightEye.transform.Rotate(new Vector3(0.0f, -sensitivity, 0.0f), Space.Self);
            leftEye.transform.Rotate(new Vector3(0.0f, -sensitivity, 0.0f), Space.Self);
        }
    }
}
