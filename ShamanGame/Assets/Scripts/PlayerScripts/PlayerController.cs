using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{

    [SerializeField] private float moveSpeed = 2f;

    [SerializeField] private float drumBoolTimer = 5f;
    private float timer = 0;

    //[SerializeField] private Camera cam =

    //private Vector3 camForward = Camera.main.transform.forward;
    //private Vector3 flattenedCam = Vector3.ProjectOnPlane(camForward, Vector3.up);

    private Vector2 moveDirection;
    private int test;
    //private Vector3 movement;
    public bool drumIsPressed = false;

    public bool isPlayingDrums = false;

    public bool isLeftDrum = false;
    public bool isRightDrum = false;


    //enum DrumInput { One, Two };



    public void OnMove(InputAction.CallbackContext context)
    {
        moveDirection = context.ReadValue<Vector2>();
    }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //DrumInput drumInput;
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
        //PlayDrums();
        DrumBoolTimer();
        //PlayDrumsOne();
    }

    public void MovePlayer()
    {
        Vector3 movement = new Vector3(moveDirection.x, 0f, moveDirection.y);

        Vector3 camForward = Camera.main.transform.forward;
        Vector3 flattenedCam = Vector3.ProjectOnPlane(camForward, Vector3.up);
        Quaternion cameraOrientation = Quaternion.LookRotation(flattenedCam);

        //transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(movement), 0.15f);

        movement = cameraOrientation * movement;
        transform.Translate(movement * moveSpeed * Time.deltaTime, Space.World);      
    }

    public void OnPlayDrumsOne(InputAction.CallbackContext context)
    {
        if(context.performed)
        {
            isLeftDrum = false;
            isRightDrum= false;
            drumIsPressed = true;
            PlayDrumsOne();
        }
    }
    public void OnPlayDrumsTwo(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            isLeftDrum = false;
            isRightDrum = false;
            drumIsPressed = true;
            PlayDrumsTwo();
        }
    }


    public bool PlayDrumsOne()
    {
        if (drumIsPressed)
        {
            isPlayingDrums = true;
            drumIsPressed = false;
            //isRightDrum = true;
            //Debug.Log("Right");
            isRightDrum = true;
            return true;

            //if (!isPlayingDrums)
            //{
            //    isPlayingDrums = true;
            //    Debug.Log("Is Playing Drums");
            //}

            //if (isRightDrum)
            //    isRightDrum = false;
            //return true;
            //Debug.Log("Play Drums Right");
        }
        else
        {
            //isRightDrum = false;
            isPlayingDrums = false;
            return false;
        }
            
        // This model seems to work alright. Replace PlayDrumsTwo with it.
    }

    //public void PlayDrumsTwo(InputAction.CallbackContext context)
    public bool PlayDrumsTwo()
    {
        if(drumIsPressed)
        {
            isPlayingDrums = true;
            drumIsPressed = false;
            //isLeftDrum = true;
            //Debug.Log("Left");
            isLeftDrum = true;
            return true;
        }
        else
        {
            //isLeftDrum = false;
            isPlayingDrums = false;
            return false;
        }

        //if (context.performed)
        //{
        //    //if(!isPlayingDrums)
        //       isPlayingDrums = true;
        //    Debug.Log("Play Drums Left");
        //}
    }



    void DrumBoolTimer()
    {       
        if (isPlayingDrums)
        {
            timer += Time.deltaTime;
            if(timer >= drumBoolTimer)
            {               
                //Debug.Log("Drum Timer is off");
                timer = 0;
                isPlayingDrums = false;
            }
            else if(drumIsPressed)
            {
                //Debug.Log("Drum Timer restarted");
                timer = 0;
            }
        }
    }
}
