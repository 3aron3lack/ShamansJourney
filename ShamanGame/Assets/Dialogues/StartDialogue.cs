using cherrydev;
using UnityEngine;

public class StartDialogue : MonoBehaviour
{
    [SerializeField] private DialogBehaviour dialogBehaviour;
    [SerializeField] private DialogNodeGraph dialogGraph;

    [SerializeField] private PlayerController player;

    bool playerInVicinity = false;

    private ManagePlayerMovement playerMovement;

    private void Start()
    {
        dialogBehaviour.BindExternalFunction("Disable", DisableMovement);
        dialogBehaviour.BindExternalFunction("Enable", EnableMovement);
    }

    private void Update()
    {
        if (playerInVicinity && player.isInteracting)
        {
            DialogInteraction();
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player") && !playerInVicinity)
        {
            playerInVicinity = true;
            //if(player.isInteracting)
            //{
            //    DialogInteraction();
            //}
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

    private void DisableMovement()
    {
        player.canMove = false;
    }
    private void EnableMovement()
    {
        player.canMove = true;
    }
}
