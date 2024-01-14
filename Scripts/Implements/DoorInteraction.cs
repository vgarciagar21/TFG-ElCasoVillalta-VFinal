using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class DoorInteraction : MonoBehaviour, InterfaceInteractable
{
    [SerializeField] private Animator openCloseAnimation;
    [SerializeField] private AudioSource openDoorSound;
    [SerializeField] private AudioSource closeDoorSound;
    public bool isOpen;

    void Awake()
    {
        //openCloseAnimation.Play("Closing");
        isOpen = false;
    }

    public string GetDescription()
    {
        if (!isOpen) {
            return "Abrir";
        } else return "Cerrar";
    }

    public void Interact()
    {
        if (isOpen == false) {
            openingDoor();
        } else
            closingDoor();
    }

    private void openingDoor()
    {
        openDoorSound.Play();
        openCloseAnimation.Play("Opening");
        isOpen = true;
    }

    private void closingDoor()
    {
        closeDoorSound.Play();
        openCloseAnimation.Play("Closing");
        isOpen = false;
    }
}
