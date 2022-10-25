//Part of Puppets VR edition, 
//a series of experiments in low-fidelity avatars with faces controlled via controller input.
//Long live some modicum of privacy and anonymity on the internet I guess?
//Right now eyelids only move at one speed and you can't lower them. You can only blink.
//This particular script controls a basic blink behavior by making an eyelid rotate over the eye.
//Put the script on the eyelid itself.

//...in order to progress, you may need to actually understand how quaternions work
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blink : MonoBehaviour
{
    public float closedAngle;//closed angle is 0
    public float openAngle;//open angle is 180
    private float currentAngle;
    public float rotationPerFrame;
    bool closing;
    bool opening;


    private void Start()
    {
        currentAngle = openAngle;
        Debug.Log("The x angle of this eye when it is open is " + gameObject.transform.localEulerAngles.x);
    }

    //you may want to amend these to take an amount to close the eye by, eventually
    public void CloseEye()
    {
        Debug.Log("Closing eyes now");
        closing = true;
        opening = false;
    }

    public void OpenEye()
    {
        Debug.Log("Opening eyes now");
        opening = true;
        closing = false;
    }

    private void Update()
    {
        if (closing)
        {
            if(currentAngle > closedAngle)//if eye not full closed
            {
                Debug.Log("Current angle is less than closed angle");
                gameObject.transform.Rotate(0.0f, -rotationPerFrame, 0.0f, Space.Self);
                currentAngle -= rotationPerFrame;
                Debug.Log("Current angle now " + currentAngle);
            }
            else
            {
                closing = false;
            }
        }
        //opening is the same but everything is backwards
        if (opening)
        {
            if (currentAngle < openAngle)//if eye not fully open
            {
                gameObject.transform.Rotate(0.0f, rotationPerFrame, 0.0f, Space.Self);
                currentAngle += rotationPerFrame;
            }
            else
            {
                opening = false;
            }
        }
    }
}
