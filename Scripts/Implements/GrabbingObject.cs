using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabbingObject : MonoBehaviour, InterfaceInteractable
{
    [SerializeField] private Transform handTarget;
    [SerializeField] private GameObject CanvasToShow1;
    [SerializeField] private GameObject CanvasToShow2;
    [SerializeField] private GameObject CanvasToShow3;
    public int flag; //For the Canvas {1,2,3}
    public GameObject detective;
    private Animator detectiveAnimator;
    public float velocidadMovimiento = 2.0f;
    private bool isGrabbing = false;
    private DetectiveMovement movement;
    private DetectiveView rotation;

    private void Awake() {
        detectiveAnimator = detective.GetComponent<Animator>();
        movement = detective.GetComponent<DetectiveMovement>();
        rotation = detective.GetComponent<DetectiveView>();
        flag = 1;
        CanvasToShow1.SetActive(false);
        CanvasToShow2.SetActive(false);
        CanvasToShow3.SetActive(false);
    }

    public string GetDescription(){
        return "Ver";
    }

    public void Interact()
    {
        if (!isGrabbing)
        {
            handTarget.position = gameObject.transform.position;
            detectiveAnimator.SetTrigger("GrabbingObject");
            isGrabbing = true;
            movement.enabled = false;
            rotation.enabled = false;
            CanvasToShow1.SetActive(true);
            /*if (flag == 1)
                CanvasToShow1.SetActive(true);
            if (flag == 2)
                CanvasToShow2.SetActive(true);
            if (flag == 3)
                CanvasToShow3.SetActive(true);
            */
            }
        else
        {
            detectiveAnimator.Rebind();
            CanvasToShow1.SetActive(false);
            isGrabbing = false;
            movement.enabled = true;
            rotation.enabled = true;
        }

    }

    public GameObject CanvasToShow(int flag) {
        if (flag == 1)
        {
            return CanvasToShow1;
        }
        else if (flag == 2)
        {
            return CanvasToShow2;
        }
        else if (flag == 3)
        {
            return CanvasToShow3;
        }
        else return null;
    }

}
