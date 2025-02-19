using cherrydev;
using System.Collections;
using System.Xml.Serialization;
using UnityEngine;

public class StartDialogue : MonoBehaviour
{
    [SerializeField] private DialogBehaviour dialogBehaviour;
    //[SerializeField] private DialogNodeGraph dialogGraph;
    //[SerializeField] private Transform cameraFocusObject;
    [SerializeField] private CameraDialogueFocus cameraDialogueFocus;
    [SerializeField] private PlayerDialogueEndCamera playerEndCamera;
    [SerializeField] private LocalDialogueCheck localDialogueCheck;
    [SerializeField] private PlayerController player;

    [SerializeField] private DialogNodeGraph[] dialogGraphs;

    [HideInInspector] public int currentGraph = 0;

    bool playerInVicinity = false;
    bool isDialogue = false;

    bool switchToNew = true;


    private void Start()
    {
        //playerEndCamera.newDialogue = cameraDialogueFocus;

        //cameraFocusObject = cameraDialogueFocus.transform;
        //cameraDialogueFocus.NoTarget();

        //dialogBehaviour.BindExternalFunction("SwitchToPlayer", CameraToPlayer);
        //dialogBehaviour.BindExternalFunction("SwitchToTarget", CameraToTarget);

        //playerEndCamera.newDialogue = cameraDialogueFocus;
        
    }

    private void Update()
    {
        if (playerInVicinity && player.isInteracting && !playerEndCamera.inDialogue)
        {
            DialogInteraction();
            dialogBehaviour.StartDialog(dialogGraphs[currentGraph]);
            //isDialogue = true;
        }
        
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player") && !playerInVicinity)
        {
            playerInVicinity = true;
            //playerEndCamera.newDialogue = cameraDialogueFocus;
            //cameraDialogueFocus.NewTarget();

            //cameraDialogueFocus = playerEndCamera.newDialogue;
            //cameraDialogueFocus.NoTarget();
            
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && playerInVicinity)
        {
            playerInVicinity = false;
            playerEndCamera.newDialogue = null;
            //cameraDialogueFocus = null;

        }
    }

    public void DialogInteraction()
    {
        //dialogBehaviour.StartDialog(dialogGraph);

        playerEndCamera.newDialogue = cameraDialogueFocus;
        cameraDialogueFocus.NewTarget();

        dialogBehaviour.StartDialog(dialogGraphs[currentGraph]);

        Cursor.visible = true;
        //ChangeDialogGraph();


        Debug.Log("THE DIALOG BEHAVIOR NAME IS: " + dialogBehaviour.name);

        dialogBehaviour.BindExternalFunction("SwitchToPlayer", CameraToPlayer);
        //dialogBehaviour.BindExternalFunction("SwitchToTarget", cameraDialogueFocus.SwitchToTarget);
        dialogBehaviour.BindExternalFunction("SwitchToTarget", CameraToTarget);

        dialogBehaviour.BindExternalFunction("SwitchToPlayer1", CameraToPlayer);
        //dialogBehaviour.BindExternalFunction("SwitchToTarget1", cameraDialogueFocus.SwitchToTarget);
        dialogBehaviour.BindExternalFunction("SwitchToTarget1", CameraToTarget);

        dialogBehaviour.BindExternalFunction("Scold", ScoldKinsi);
        dialogBehaviour.BindExternalFunction("Hug", HugKinsi);

        localDialogueCheck.InLocalDialogue();
    }

    //private void CameraToTarget1()
    //{
    //    //cameraDialogueFocus.SwitchToTarget();
    //    playerEndCamera.newDialogue.SwitchToTarget();
    //    Debug.Log("Current dialogGraph 2 is: " + dialogGraph.name);
    //    Debug.Log("Current CameraDialogueFocus 2 is: " + cameraDialogueFocus.name);

    //}

    public void SwitchToLastDialogue()
    {
        if(switchToNew)
        {
            PlaySoundclip playSoundclip = GetComponent<PlaySoundclip>();
            playSoundclip.PlayAudio();

            StartCoroutine(dramaticPause());
            
            switchToNew = false;
        }
    }

    IEnumerator dramaticPause()
    {
        yield return new WaitForSeconds(4);
        DialogInteraction();
    }
    private void ScoldKinsi()
    {
        currentGraph = 1;

    }
    private void HugKinsi()
    {
        currentGraph = 2;
    }

    private void CameraToTarget()
    {
        //dialogBehaviour.BindExternalFunction("SwitchToTarget", CameraToTarget);
        //cameraDialogueFocus.SwitchToTarget();

        

        playerEndCamera.newDialogue.SwitchToTarget();

        //Debug.Log("Current dialogGraph is: " + dialogGraph.name);
        Debug.Log("Current dialogGraph is: " + dialogGraphs[currentGraph].name);

        Debug.Log("Current CameraDialogueFocus 1 is: " + cameraDialogueFocus.name);
        //cameraDialogueFocus.SwitchToTarget();
    }
    private void CameraToPlayer()
    {
        //dialogBehaviour.BindExternalFunction("SwitchToPlayer", CameraToPlayer);     
        //cameraDialogueFocus.SwitchToPlayer();
        playerEndCamera.newDialogue.SwitchToPlayer();
    }

    public void ChangeDialogGraph()
    {
        if(currentGraph <=  dialogGraphs.Length-1)
        {
            Debug.Log("DialogGraph length is: " + (dialogGraphs.Length-1));
            currentGraph++;
            Debug.Log("Current DialogGraph: " + dialogGraphs[currentGraph].name);
        }
        else
        {
            currentGraph = 0;
        }
    }
}
