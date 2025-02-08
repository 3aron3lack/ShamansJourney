using UnityEngine;

public class ManagePlayerMovement : MonoBehaviour
{
    public PlayerController player;

    void DisableMovement()
    {
        player.canMove = false;
    }

    void EnableMovement()
    {
        player.canMove = true;
    }
}
