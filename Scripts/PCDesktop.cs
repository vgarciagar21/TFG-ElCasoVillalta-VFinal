using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PCDesktop : MonoBehaviour, InterfaceInteractable
{
    [SerializeField] private GameObject PCCanvas;
    bool isOpen = false;
    [SerializeField] private DetectiveMovement movement;
    [SerializeField] private DetectiveView rotation;

    // Start is called before the first frame update
    void Start()
    {
        PCCanvas.SetActive(false);
        //movement = detective.GetComponent<DetectiveMovement>();
        //rotation = detective.GetComponent<DetectiveView>();
    }
    public string GetDescription()
    {
        return "Ver";
    }

    public void Interact()
    {
        PCCanvas.SetActive(true);
        //movement.SetActive(false);
        //rotation.SetActive(false);

    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            if (isOpen)
            {
                PCCanvas.SetActive(false);
                //movement.SetActive(false);
                //rotation.SetActive(false);
            }
        }
    }
}
