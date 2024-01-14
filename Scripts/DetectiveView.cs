using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectiveView : MonoBehaviour
{
    public Camera playerCamera;

    public float lookSpeed = 3f;
    public float lookXLimit = 50f;
    float rotationX = 0;
    
    private bool isLocked = true;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)){
            isLocked = !isLocked;
        }
        if (isLocked){
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        else{
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
        rotationX += -Input.GetAxis("Mouse Y") * lookSpeed;
        rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit);
        playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
        transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * lookSpeed, 0);
    }
}
