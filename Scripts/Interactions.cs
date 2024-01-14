using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Interactions : MonoBehaviour {

    [SerializeField] public float interactRange = 3.0f;
    [SerializeField] public Camera mainCamera;
    [SerializeField] public GameObject interactionUI;
    [SerializeField] public TextMeshProUGUI interactionText;
    //private Animator detectiveAnimator;


    private void Awake(){
        //detectiveAnimator = GetComponent<Animator>();
    }

    void Start() {

    }

    private void Update() {
        Ray r = mainCamera.ViewportPointToRay(Vector3.one / 2f);
        RaycastHit hit;
        bool objectFound = false;
        if (Physics.Raycast(r, out hit, interactRange)) {
            InterfaceInteractable iInteractable = hit.collider.GetComponent<InterfaceInteractable>();
            if (iInteractable != null) {
                objectFound = true;
                interactionText.text = iInteractable.GetDescription();
                if (Input.GetKeyDown(KeyCode.E)) {
                    //detectiveAnimator.SetTrigger("GrabbingObject");
                    //if (iInteractable)
                    iInteractable.Interact();
                }
            }
        }
        interactionUI.SetActive(objectFound);
    }
}