using JetBrains.Annotations;
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

    public bool isInteracting = false;

    public bool canMove = true;

    // - CharacterController Values
    private CharacterController characterController;



    //private Rigidbody rb;
    //enum DrumInput { One, Two };

    float interactionTimer = 0;

    public void OnMove(InputAction.CallbackContext context)
    {
        moveDirection = context.ReadValue<Vector2>();
    }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //DrumInput drumInput;
        //rb = GetComponent<Rigidbody>();
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {

        if(canMove)
        {
            MovePlayer();
        }       
        Interacting();

        //DrumBoolTimer();
        //PlayDrumsOne();
    }

    void FixedUpdate()
    {
    }

    public void MovePlayer()
    {


        Vector3 movement = new Vector3(moveDirection.x, 0f, moveDirection.y);

        Vector3 camForward = Camera.main.transform.forward;

        Vector3 flattenedCam = Vector3.ProjectOnPlane(camForward, Vector3.up);
        Quaternion cameraOrientation = Quaternion.LookRotation(flattenedCam);

        Vector3 fallVector = Vector3.zero;


        //transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(movement), 0.15f);

        //Debug.Log(Camera.main.transform.forward);
        movement = cameraOrientation * movement;
        
        //transform.Translate(movement * moveSpeed * Time.deltaTime, Space.World);   
        characterController.Move(movement * moveSpeed * Time.deltaTime);
        // Still needs gravity
        if(characterController.isGrounded == false)
        {
            fallVector += Physics.gravity;
        }
        characterController.Move(fallVector * Time.deltaTime);


        //rb.MovePosition(movement * moveSpeed * Time.deltaTime);
        //rb.transform.Translate(movement * moveSpeed * Time.deltaTime, Space.World);
    }

    public void OnInteract(InputAction.CallbackContext context)
    {
        if(context.performed)
        {
            isInteracting = true;
            //Interacting();
        }
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


    // --- NEW DRUM MECHANIC ---

    // No Idea why it works now. It might just work for the dialog, so keep the old code up. It migth be necessary for later.
    public void Interacting()
    {
        if(isInteracting)
        {
            isInteracting = false;

            //interactionTimer += Time.deltaTime;
            //Debug.Log("Interaction Timer: " + interactionTimer);

            //if (interactionTimer >= 1f)
            //{
            //    Debug.Log("Interaction Finished");
            //    isInteracting = false;
            //    interactionTimer = 0;
            //}
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
