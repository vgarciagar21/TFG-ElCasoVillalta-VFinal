using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnscrewInteraction : MonoBehaviour, InterfaceInteractable
{
    [SerializeField] private GameObject screw;
    [SerializeField] private GameObject screwdriverUI;


    public string GetDescription()
    {
        return "Desatornillar";
    }

    public void Interact()
    {
        if (screwdriverUI.activeSelf)
           Destroy(screw);
    }


}