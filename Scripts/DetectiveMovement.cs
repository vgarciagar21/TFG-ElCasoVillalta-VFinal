using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class DetectiveMovement : MonoBehaviour
{
    public float speedMovement = 1.0f;
    public float speedRotation = 30.0f;
    private Animator animation;
    public AudioSource footstepsSound;
    public float x, y;

    void Start()
    {
        animation = GetComponent<Animator>();
    }

    void Update()
    {
        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");

        transform.Translate(0, 0, y * Time.deltaTime * speedMovement);
        transform.Rotate(0, x * Time.deltaTime * speedRotation, 0);

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
            footstepsSound.enabled = true;
        else
            footstepsSound.enabled = false;

        animation.SetFloat("SpeedX", x);
        animation.SetFloat("SpeedY", y);

    }
}
