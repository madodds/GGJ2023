using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public float panSpeed = 10.0f;
    public float zoomSpeed = 2.0f;
    public float maxFov = 70.0f;
    public float minFov = 15.0f;
    public float maxZ = 30.0f;
    public float minZ = -30.0f;
    public float maxX = 30.0f;
    public float minX = -30.0f;

    Camera camera;

    void Awake()
    {
        camera = GetComponent<Camera>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetAxis("Horizontal") != 0.0f){
            transform.position += Vector3.right * panSpeed * Input.GetAxis("Horizontal") * Time.deltaTime;
            if(transform.position.x < minX){
                transform.position = new Vector3(minX, transform.position.y, transform.position.z);
            }
            if(transform.position.x > maxX){
                transform.position = new Vector3(maxX, transform.position.y, transform.position.z);
            }
        }

        if(Input.GetAxis("Vertical") != 0.0f){
            transform.position += Vector3.forward * panSpeed * Input.GetAxis("Vertical") * Time.deltaTime;
            if(transform.position.z < minZ){
                transform.position = new Vector3(transform.position.x, transform.position.y, minZ);
            }
            if(transform.position.z > maxZ){
                transform.position = new Vector3(transform.position.x, transform.position.y, maxZ);
            }
        }

        if(Input.mouseScrollDelta.y != 0.0f){
            if(camera){
                camera.fieldOfView -= Input.mouseScrollDelta.y * zoomSpeed;
                // Debug.Log("fov "+ camera.fieldOfView);
                // if(camera.fieldOfView < minFov){
                //     camera.fieldOfView = minFov;
                // }
                // if(camera.fieldOfView > maxFov){
                //     camera.fieldOfView = maxFov;
                // }
                // Debug.Log("fov after " + camera.fieldOfView);
            } else{
                Debug.Log("No camera");
            }
        }

    }
}
