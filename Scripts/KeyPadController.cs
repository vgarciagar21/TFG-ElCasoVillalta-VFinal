using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyPadController : MonoBehaviour, InterfaceInteractable
{
    [SerializeField] private GameObject KeypadCanvas;
    [SerializeField] public string password1;
    [SerializeField] public string password2;
    [SerializeField] public string password3;
    [SerializeField] public AudioClip bipSound;
    public GameObject detective;
    public string passwordSelected;
    public Text passwordSelectedUI;
    private int passwordIndex;
    private bool isOpen;
    private bool waitForSelection;   
    private bool exit;
    private DetectiveMovement movement;
    private DetectiveView rotation;


    void Start()
    {
        isOpen = false;
        waitForSelection = false;
        exit = false;
        KeypadCanvas.SetActive(false);
        passwordSelected = null;
        passwordIndex = 1;
        AudioSource audio = gameObject.AddComponent<AudioSource>();
        audio.clip = bipSound;
        movement = detective.GetComponent<DetectiveMovement>();
        rotation = detective.GetComponent<DetectiveView>();

    }

    public string GetDescription()
    {
            return "Marcar";
    }

    public void Interact()
    {
        if (isOpen == false)
        {
            isOpen = true;
            KeypadCanvas.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            waitForSelection = true;
            movement.enabled = false;
            rotation.enabled = false;
        }
        else
            KeypadCanvas.SetActive(false);
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            isOpen = false;
            KeypadCanvas.SetActive(false);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = false;
            waitForSelection = false;
            movement.enabled = true;
            rotation.enabled = true;
        }
    
    }

    public void reproduceSound() {
        GetComponent<AudioSource>().Play();
    }

    public void CodingPassword(string number)
    {
        passwordSelected = number;
        passwordSelectedUI.text = passwordSelected;
        passwordIndex++;
    }

    public void erasePassword() {
        passwordSelected = null;
        passwordSelectedUI.text = passwordSelected;
        passwordIndex = 1;

    }



    public void CheckPassword()
    {
        if (passwordSelected == password1) {
            exit = true;
        }
        if(passwordSelected == password2){
            exit = true;
        }
        if(passwordSelected == password2){
            exit = true;
        }
        if (exit) {
            KeypadCanvas.SetActive(false);
            isOpen = false;
            movement.enabled = true;
            rotation.enabled = true;
        }

    }

}









