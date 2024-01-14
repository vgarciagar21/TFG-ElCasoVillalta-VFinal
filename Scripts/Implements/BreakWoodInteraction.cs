using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakWoodInteraction : MonoBehaviour, InterfaceInteractable
{
    [SerializeField] private GameObject AxeUI;

    public string GetDescription()
    {
        return "Romper";
    }

    public void Interact()
    {
        if (AxeUI.activeSelf) {
            Destroy(gameObject);
        }
    }

}
