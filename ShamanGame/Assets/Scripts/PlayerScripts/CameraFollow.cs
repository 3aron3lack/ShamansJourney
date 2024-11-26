using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    //Use this script until you have figured out Cinemachine.

    public Transform target;
    public float smoothTime = 0.3f;
    public Vector3 offset;
    
    private Vector3 velocity = Vector3.zero;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(target != null)
        {
            Vector3 targetPosition = target.position + offset;

            transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
        }
    }
}