using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class EyeRotation : MonoBehaviour
{
    public float rightLimit, leftLimit, upLimit, downLimit;//left limit should be negative
    public GameObject rightEye, leftEye;
    public float sensitivity;
    public bool joyStickDown;
    public float joyStickValueX, joyStickValueY;

    [Tooltip("Actions to check")]
    public InputAction rotateLeftRightAction = null;

    public InputAction rotateUpDownAction = null;

    // Start is called before the first frame update
    void Start()
    {
        //set the things to defaults if left empty after you know what good defaults are
    }

    public void Update()
    {
        if (joyStickDown)
        {   
            //look left/right
            rightEye.transform.Rotate(new Vector3(0.0f, sensitivity * joyStickValueX, 0.0f), Space.Self);
            leftEye.transform.Rotate(new Vector3(0.0f, sensitivity * joyStickValueX, 0.0f), Space.Self);

            //look up/down
            rightEye.transform.Rotate(new Vector3(sensitivity * joyStickValueY, 0.0f, 0.0f), Space.Self);
            leftEye.transform.Rotate(new Vector3(sensitivity * joyStickValueY, 0.0f, 0.0f), Space.Self);
        }
    }

    //This section is a little confusing for you.
    private void Awake()
    {
        rotateLeftRightAction.performed += PressedLR;
        rotateLeftRightAction.canceled += ReleasedLR;

        rotateUpDownAction.performed += PressedUD;
        rotateUpDownAction.canceled += ReleasedUD;
    }

    private void OnDestroy()
    {
        rotateLeftRightAction.started -= PressedLR;
        rotateLeftRightAction.canceled -= ReleasedLR;

        rotateUpDownAction.started -= PressedUD;
        rotateUpDownAction.canceled -= ReleasedUD;
    }

    private void OnEnable()
    {
        rotateLeftRightAction.Enable();

        rotateUpDownAction.Enable();

    }

    private void OnDisable()
    {
        rotateLeftRightAction.Disable();

        rotateUpDownAction.Enable();

    }

    private void PressedLR(InputAction.CallbackContext context)
    {
        joyStickDown = true;
        Debug.Log("and perhaps this gives us a value? " + context.ReadValueAsObject());//THIS DOES IT
        joyStickValueX = (float) context.ReadValueAsObject();
    }

    private void ReleasedLR(InputAction.CallbackContext context)
    {
        joyStickDown = false;
    }

    private void PressedUD(InputAction.CallbackContext context)
    {
        joyStickDown = true;
        Debug.Log("and perhaps this gives us a value? " + context.ReadValueAsObject());//THIS DOES IT
        joyStickValueY = (float)context.ReadValueAsObject();
    }

    private void ReleasedUD(InputAction.CallbackContext context)
    {
        joyStickDown = false;
    }

    //these two functions would be useful if joystick input were set up a little differently
    //no right and left. transform.rotate value * speed
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
