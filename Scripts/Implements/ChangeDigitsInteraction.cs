using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ChangeDigitsInteraction : MonoBehaviour, InterfaceInteractable
{
    [SerializeField] private TextMeshPro digit;
    public int actualValue;
    // Start is called before the first frame update
    void Start()
    {
        actualValue = 0;
        digit.text = actualValue.ToString();
    }

    public string GetDescription()
    {
        return "Aumentar";
    }

    public void Interact()
    {
        actualValue++;
        if (actualValue == 10)
            actualValue = 0;
        digit.text = actualValue.ToString();
    }
}
