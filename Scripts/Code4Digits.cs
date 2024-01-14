using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Code4Digits : MonoBehaviour
{
    [SerializeField] TextMeshPro[] digitsTexts;
    [SerializeField] private Animator wallAnimation;
    [SerializeField] private Animator mirrorAnimation;
    [SerializeField] private AudioSource open;
    [SerializeField] private GameObject NoteCanvas1;
    [SerializeField] private GameObject NoteCanvas2;
    [SerializeField] private Transform NoteLocation;
    [SerializeField] private TextMeshProUGUI nArtFigures1;
    [SerializeField] private TextMeshProUGUI nArtFigures2;
    [SerializeField] private TextMeshProUGUI nArtFigures3;

    public int viaHistoria; //1 for Forense, 2 for Cheng or 3 for Cayetana

    void Start() {
        viaHistoria = 3; //Cayetana is the murderer by default
    }

    void Update()
    {
        if (digitsTexts[0].text == "1" && digitsTexts[1].text == "9" && digitsTexts[2].text == "5" && digitsTexts[3].text == "6") //Murder: Cheng or Cayetana
        {
            ResetDigits();
            isPassword1();
            if (viaHistoria == 2 || (nArtFigures1.text == "4" && nArtFigures2.text == "4" && nArtFigures3.text == "4")) { //Murder: Cheng
                NoteCanvas1.transform.position = NoteLocation.position;
            } else
            {
                NoteCanvas2.transform.position = NoteLocation.position;  //Murder: Cayetana
            }
            return;
        }

        if (digitsTexts[0].text == "9" && digitsTexts[1].text == "5" && digitsTexts[2].text == "6" && digitsTexts[3].text == "1") //Murder: Forense
        {
            ResetDigits();
            isPassword1();
            return;
        }
        
    }

    public void GetViaHistoria(int via)
    {
        viaHistoria = via;
    }

    private void isPassword1() {
        open.Play();
        mirrorAnimation.Play("BRGlassDoorOpen");
    }

    private void isPassword2() {
        open.Play();
        wallAnimation.Play("BRGlassDoorOpen");
    }

    private void ResetDigits() {
        digitsTexts[0].text = "0";
        digitsTexts[1].text = "0";
        digitsTexts[2].text = "0";
        digitsTexts[3].text = "0";
    }
}

