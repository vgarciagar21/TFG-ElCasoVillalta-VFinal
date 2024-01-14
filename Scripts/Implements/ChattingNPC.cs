using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Ink.Runtime;
using UnityEngine.EventSystems;

public class ChattingNPC : MonoBehaviour, InterfaceInteractable
{
    [SerializeField] private GameObject chatBubble;
    [SerializeField] private TextMeshProUGUI narrator;
    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] private Animator imageSwitch;

    [SerializeField] private Sprite DetectivePic;
    [SerializeField] private Sprite ForensePic;
    [SerializeField] private Sprite CatalinaPic;
    [SerializeField] private Sprite ChengPic;

    [SerializeField] private GameObject[] options;
    private TextMeshProUGUI[] optionText;

    [SerializeField] private GameObject HUD;
    [SerializeField] private GameObject InteractionUI;
    [SerializeField] private GameObject ProgressUI;
    [SerializeField] private GameObject EscKeyMenuUI;

    public GameObject detective;
    private DetectiveMovement movement;
    private DetectiveView rotation;
    private float speed = 0.04f;
    private Story actualStory;
    [SerializeField] private TextAsset inkJSON;
    private bool isActive;
    private bool waitForSubmit;
    public int viaHistoria;
    public Code4Digits codeDigits;

    private const string narratorReference = "narrator";
    private const string imageReference = "image";

    /*public enum CharacterNarrators
    {
        Detective,
        Forense,
        Cayetana,
        Cheng,
    }*/

    private void Awake() {
        movement = detective.GetComponent<DetectiveMovement>();
        rotation = detective.GetComponent<DetectiveView>();
    }

    private void Start()
    {
        codeDigits = GetComponent<Code4Digits>();
        chatBubble.SetActive(false);
        HUD.SetActive(false);
        ProgressUI.SetActive(false);
        isActive = false;
        actualStory = new Story(inkJSON.text);
        optionText = new TextMeshProUGUI[options.Length];
        waitForSubmit = false;
        int aux = 0;
        foreach (GameObject option in options)
        {
            optionText[aux] = option.GetComponentInChildren<TextMeshProUGUI>();
            aux++;
        }
    }

    private void Update() {
        if (waitForSubmit) {
            ProgressUI.SetActive(true);
            if (Input.GetKey(KeyCode.Alpha1))
            {
                actualStory.ChooseChoiceIndex(0);
            }
            else if (Input.GetKey(KeyCode.Alpha2)) 
            { 
                actualStory.ChooseChoiceIndex(1);
            }
            else if (Input.GetKey(KeyCode.Alpha3)) 
            {
                actualStory.ChooseChoiceIndex(2);
            }
        }
        int via = (int)actualStory.variablesState["viaHistoria"];
        codeDigits.GetViaHistoria(via);
    }


    public string GetDescription()
    {
        return "Hablar";
    }

    public void Interact()
    {
        chatBubble.SetActive(true);
        movement.enabled = false;
        rotation.enabled = false;
        EscKeyMenuUI.SetActive(false);
        if (actualStory.canContinue)
        {
            InteractionUI.SetActive(false);
            Continue();
        }
        else
        {
            InteractionUI.SetActive(true);
            EscKeyMenuUI.SetActive(true);
            End();
        }
    }
    
    private void Continue()
    {
        if (actualStory.canContinue)
        {
            HUD.SetActive(false);
            string newText = actualStory.Continue();
            this.text.text = newText;
            DisplayOptionsChat();
            references(actualStory.currentTags);
        }
        else
            End();
    }

    private void references(List<string> currentTags)
    {
        foreach (string reference in currentTags)
        {
            string[] refSplit = reference.Split(":");
            string referenceKey = refSplit[0].Trim();
            string referenceValue = refSplit[1].Trim();

            switch (referenceKey) {
                case narratorReference:
                    narrator.text = referenceValue;
                    break;
                case imageReference:
                    imageSwitch.Play(referenceValue);
                    break;
                default:
                    break;
            }
        }
    }

    private void DisplayOptionsChat() {
        List<Choice> currentOptions = actualStory.currentChoices;
        int aux = 0;
        foreach (Choice option in currentOptions)
        {
            options[aux].gameObject.SetActive(true);
            optionText[aux].text = option.text;
            aux++;
        }
        for (int i = aux; i < options.Length; i++)
        {
            options[i].gameObject.SetActive(false);
        }
        HUD.SetActive(true);

        waitForSubmit = true;
    }

    private void End()
    {
            chatBubble.SetActive(false);
            HUD.SetActive(false);
            isActive = false;
            text.text = "";
            movement.enabled = true;
            rotation.enabled = true;

    }

/*
    private void GetNarrator(string speaker)
    {
        switch (speaker)
        {
            case "Detective":
                shortImage = DetectivePic;
                narrator.text = "Detective";
                break;
            case "Cayetana":
                shortImage = CatalinaPic;
                narrator.text = "Cayetana Villalta";
                break;
            case "Forense":
                shortImage = ForensePic;
                narrator.text = "Forense";
                break;
            case "Cheng":
                shortImage = ChengPic;
                narrator.text = "Sr.Cheng";
                break;
            default:
                break;
        }
    }
*/
}
