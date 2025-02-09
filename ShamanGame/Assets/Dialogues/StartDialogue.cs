using cherrydev;
using UnityEngine;

public class StartDialogue : MonoBehaviour
{
    [SerializeField] private DialogBehaviour dialogBehaviour;
    [SerializeField] private DialogNodeGraph dialogGraph;

    [SerializeField] private CameraDialogueFocus cameraDialogueFocus;
    [SerializeField] private PlayerDialogueEndCamera playerEndCamera;

    [SerializeField] private PlayerController player;

    bool playerInVicinity = false;
    bool isDialogue = false;

    private void Start()
    {
        dialogBehaviour.BindExternalFunction("SwitchToPlayer", CameraToPlayer);
        dialogBehaviour.BindExternalFunction("SwitchToTarget", CameraToTarget);

        playerEndCamera.newDialogue = cameraDialogueFocus;
    }

    private void Update()
    {
        if (playerInVicinity && player.isInteracting && !playerEndCamera.inDialogue)
        {
            DialogInteraction();
            //isDialogue = true;
        }
        
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player") && !playerInVicinity)
        {
            playerInVicinity = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && playerInVicinity)
        {
            playerInVicinity = false;
        }
    }

    private void DialogInteraction()
    {
        dialogBehaviour.StartDialog(dialogGraph);
    }

    private void CameraToTarget()
    {
        cameraDialogueFocus.SwitchToTarget();
    }
    private void CameraToPlayer()
    {
        cameraDialogueFocus.SwitchToPlayer();
    }
}
