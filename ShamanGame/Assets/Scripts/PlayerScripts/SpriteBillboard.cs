using UnityEngine;

public class SpriteBillboard : MonoBehaviour
{
    private Transform cameraTransform;
    private Vector3 cameraRotation;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        cameraTransform = Camera.main.transform;
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(cameraTransform);
        //transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, 0);
        cameraRotation = cameraTransform.rotation.eulerAngles;
        transform.rotation = Quaternion.Euler(cameraRotation.x, cameraRotation.y, cameraRotation.z);

    }
}
