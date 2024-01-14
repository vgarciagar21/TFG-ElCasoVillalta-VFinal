  using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*public enum TypeCollection
{
    ArtFigures,
    PoolBalls,
    Tools,
    ChessPieces
}*/

public class CollectionObject : MonoBehaviour
{
    [SerializeField] public string objectName;
    public TypeCollection objectType;

    public string ObjectName {
        set { 
            objectName = value; 
        }
        get { 
            return objectName; 
        }
    }

    public TypeCollection getTypeCollection() {
        
        int objectLayer = gameObject.layer;
        switch (objectLayer) {
            case 8:         //Art figures
                objectType = TypeCollection.ArtFigures;
                return objectType;
            case 9:        //Pool balls
                objectType = TypeCollection.PoolBalls;
                return objectType;
            case 10:        //Chess pieces
                objectType = TypeCollection.ChessPieces;
                return objectType;
            case 11:        //Tools
                objectType = TypeCollection.Tools;
                return objectType;
            default:
                return 0;
        }
    }
}
