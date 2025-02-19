using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform objetivo;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.LookAt(objetivo);
    }
}