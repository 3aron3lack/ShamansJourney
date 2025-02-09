using UnityEngine;

public class ManagePlayerMovement : MonoBehaviour
{
    public PlayerController player;

    public void DisableMovement()
    {
        player.canMove = false;
    }

    public void EnableMovement()
    {
        player.canMove = true;
    }
}
