using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightOnInteraction : MonoBehaviour, InterfaceInteractable
{
    [SerializeField] private GameObject bishopUI;
    [SerializeField] private GameObject rookUI;
    [SerializeField] private GameObject knightUI;
    [SerializeField] private GameObject[] light2Floor;

    void Start() {
        for (int i = 0; i < light2Floor.Length; i++)
            light2Floor[i].SetActive(false);
    }
    public string GetDescription()
    {
        return "Colocar pieza";
    }

    public void Interact()
    {
        if (bishopUI.activeSelf && rookUI.activeSelf && knightUI.activeSelf) {
            for(int i = 0; i < light2Floor.Length; i++)
                light2Floor[i].SetActive(true);
        }
    }
}
