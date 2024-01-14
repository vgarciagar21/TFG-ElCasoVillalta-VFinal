using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnboxInteraction : MonoBehaviour, InterfaceInteractable
{
    [SerializeField] private GameObject cover;
    [SerializeField] private GameObject screw1;
    [SerializeField] private GameObject screw2;

    public string GetDescription()
    {
        return "Destapar";
    }

    public void Interact()
    {
        if (gameObject.layer == 13)    //CoverSingle layer
            Destroy(gameObject);
        if (gameObject.layer == 14)     //CoverWithScrew layer
            if (screw1 == null && screw2 == null)
            {
                Destroy(gameObject);
            }
            else
                return;
    }
}