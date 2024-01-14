using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject MainMenuCanvas;
    [SerializeField] private GameObject ControlsCanvas;
    [SerializeField] private GameObject PauseMenu;

    void Start() {
        ControlsCanvas.SetActive(false);
        MainMenuCanvas.SetActive(false);
        PauseMenu.SetActive(false);
        Debug.Log("CORRECTO1");

    }

    public void ChangingScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }

    public void ShowControls() {
        Debug.Log("CORRECTO2");
        MainMenuCanvas.SetActive(false);
        ControlsCanvas.SetActive(true);
    }

    public void ReturnMenu() {
        MainMenuCanvas.SetActive(true);
        ControlsCanvas.SetActive(false);
    }

    public void ContinuePlaying() {
        //MainMenuCanvas.SetActive(false);
    }

    public void Exit() {

        Debug.Log("You are exitting the game.");
        Application.Quit();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            ControlsCanvas.SetActive(false);
            PauseMenu.SetActive(false);
        }
    }

}
