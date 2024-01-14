using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TypeCollection
{
    ArtFigures,
    PoolBalls,
    Tools,
    ChessPieces
}


public class CollectingObject : MonoBehaviour, InterfaceInteractable
{
    public GameObject detective;
    private Animator detectiveAnimator;
    private bool isMoving = false;
    public InventoryManager inventory;
    [SerializeField] public string objectName;


    private void Start() {
        detectiveAnimator = detective.GetComponent<Animator>();
    }

    public string GetDescription() {
        return "Coger";
    }

    public void Interact() {
        if (gameObject != null) {
            //CollectionType newObj = new CollectionType();
            inventory.addObjectToInventory(getTypeCollection(), ObjectName);
            Destroy(gameObject);
        }
    }

    public string ObjectName
    {
        set
        {
            objectName = value;
        }
        get
        {
            return objectName;
        }
    }

    public TypeCollection getTypeCollection()
    {

        int objectLayer = gameObject.layer;
        switch (objectLayer)
        {
            case 8:         //Art figures
                //objectType = TypeCollection.ArtFigures;
                return TypeCollection.ArtFigures;
            case 9:        //Pool balls
                return TypeCollection.PoolBalls;
            case 10:        //Chess pieces
                return TypeCollection.ChessPieces;
            case 11:        //Tools
                return TypeCollection.Tools;
            default:
                return 0;
        }
    }
}