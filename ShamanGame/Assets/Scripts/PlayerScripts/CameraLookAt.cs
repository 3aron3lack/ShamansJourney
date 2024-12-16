using UnityEngine;

public class CameraLookAt : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public PlayerController player;
    public Vector3 playerYPos;

    private Vector3 vector;

    void Start()
    {
        playerYPos.y = player.transform.position.y;
        //vector.y
        //vector = new Vector3(0, playerYPos.y, 0);
    }

    // Update is called once per frame
    void Update()
    {
        vector.y = playerYPos.y;
        
    }
}
