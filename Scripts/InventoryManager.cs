using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventoryManager : MonoBehaviour
{
    [SerializeField] private GameObject InventoryCanvas = null;
    //public bool isInteracting;
    public bool showInventory;
    public bool inventoryOpened;
    // Start is called before the first frame update
    [SerializeField] public GameObject ArtFiguresUI;
    [SerializeField] public GameObject PoolBallsUI;
    [SerializeField] public GameObject ChessPiecesUI;
    [SerializeField] public GameObject ToolsUI;

    //Art figures pics:
    [SerializeField] private GameObject artFigure1UI;
    [SerializeField] private GameObject artFigure2UI;
    [SerializeField] private GameObject artFigure3UI;

    [SerializeField] public TextMeshProUGUI countArtFigures1;
    public int countArt1;
    [SerializeField] public TextMeshProUGUI countArtFigures2;
    public int countArt2;
    [SerializeField] public TextMeshProUGUI countArtFigures3;
    public int countArt3;

    //Pool balls pics:
    [SerializeField] private GameObject poolBall1UI;
    [SerializeField] private GameObject poolBall5UI;
    [SerializeField] private GameObject poolBall6UI;
    [SerializeField] private GameObject poolBall9UI;

    //Lottery numbers:
    [SerializeField] private GameObject bishopUI;
    [SerializeField] private GameObject rookUI;
    [SerializeField] private GameObject knightUI;

    //Tools pics:
    [SerializeField] private GameObject screwdriverUI;
    [SerializeField] private GameObject axeUI;

    [SerializeField] private MonoBehaviour detectiveMovementScript;
    [SerializeField] private MonoBehaviour detectiveViewScript;

    [SerializeField] public GameObject ArtFigure1;
    [SerializeField] public GameObject ArtFigure2;
    [SerializeField] public GameObject ArtFigure3;
    [SerializeField] GameObject[] locations;
    [SerializeField] public List<GameObject> availableLocations;
    private int rand;
    private int index;

    void Awake()
    {
        InventoryCanvas.SetActive(false);
        ArtFiguresUI.SetActive(false);
        artFigure1UI.SetActive(false);
        artFigure2UI.SetActive(false);
        artFigure3UI.SetActive(false);
        PoolBallsUI.SetActive(false);
        poolBall1UI.SetActive(false);
        poolBall5UI.SetActive(false);
        poolBall6UI.SetActive(false);
        poolBall9UI.SetActive(false);
        ChessPiecesUI.SetActive(false);
        bishopUI.SetActive(false);
        rookUI.SetActive(false);
        knightUI.SetActive(false);
        ToolsUI.SetActive(false);
        screwdriverUI.SetActive(false);
        axeUI.SetActive(false);
        countArt1 = 0;
        countArt2 = 0;
        countArt3 = 0;
        List<GameObject> availableLocations = new List<GameObject>();
        FillAvailableLocations();
    }
  

    void Start() {
        FigureTypeToLocation(ArtFigure1, 4, availableLocations);
        FigureTypeToLocation(ArtFigure2, 4, availableLocations);
        FigureTypeToLocation(ArtFigure3, 4, availableLocations);
        //availableLocations = new List<GameObject>(locations);
    }

    private void FillAvailableLocations() {
        foreach (GameObject location in locations)
        {
            if (location != null)
                availableLocations.Add(location);
        }

    }

    public void FigureTypeToLocation(GameObject artFigureN, int nTimes, List<GameObject> availableLocations) {
        for (int i = 0; i < nTimes; i++) {
            rand = Random.Range(0, availableLocations.Count-1);
            GameObject newLocation = availableLocations[rand];
            GameObject newArtFigure = Instantiate(artFigureN, newLocation.transform.position, Quaternion.identity);
            availableLocations.RemoveAt(rand);
            Debug.Log(rand);
            Debug.Log(availableLocations[rand]);
            Debug.Log(newLocation.transform.position);
            Debug.Log(availableLocations.Count);
        }
    }



    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            //We invert the current Inventory status
            showInventory = !showInventory;
            if (showInventory)
            {
                openInventory();
            }
            else
                closeInventory();
        }
    }

    void openInventory() {
        InventoryCanvas.SetActive(true);
        inventoryOpened = true;
        showInventory = true;
        detectiveMovementScript.enabled = false;
        detectiveViewScript.enabled = false;
    }

    void closeInventory() {
        InventoryCanvas.SetActive(false);
        inventoryOpened = false;
        showInventory = false;
        detectiveMovementScript.enabled = true;
        detectiveViewScript.enabled = true;
    }

    public void addObjectToInventory(TypeCollection objectTypeCollection, string objectName) {
        switch (objectTypeCollection) {
            case TypeCollection.ArtFigures:
                ArtFiguresUI.SetActive(true);
                if (objectName == "Sculpture1")
                {
                    artFigure1UI.SetActive(true);
                    countArt1++;
                    if (countArt1 > 1)
                    {
                        countArtFigures1.text = countArt1.ToString();
                        countArtFigures1.enabled = true;
                    }
                }
                if (objectName == "Sculpture2")
                {
                    artFigure2UI.SetActive(true);
                    countArt2++;
                    if (countArt2 > 1)
                    {
                        countArtFigures2.text = countArt2.ToString();
                        countArtFigures2.enabled = true;
                    }
                }
                if (objectName == "Sculpture3")
                {
                    artFigure3UI.SetActive(true);
                    countArt3++;
                    if (countArt3 > 1)
                    {
                        countArtFigures3.text = countArt3.ToString();
                        countArtFigures3.enabled = true;
                    }
                }
                break;
            case TypeCollection.ChessPieces:
                ChessPiecesUI.SetActive(true);
                if (objectName == "Bishop")
                    bishopUI.SetActive(true);
                if (objectName == "Rook")
                    rookUI.SetActive(true);
                if (objectName == "Knight")
                    knightUI.SetActive(true);
                break;
            case TypeCollection.PoolBalls:
                PoolBallsUI.SetActive(true);
                if (objectName == "PoolBall1")
                    poolBall1UI.SetActive(true);
                if (objectName == "PoolBall5")
                    poolBall5UI.SetActive(true);
                if (objectName == "PoolBall6")
                    poolBall6UI.SetActive(true);
                if (objectName == "PoolBall9")
                    poolBall9UI.SetActive(true);
                break;
            case TypeCollection.Tools:
                ToolsUI.SetActive(true);
                if (objectName == "Screwdriver")
                    screwdriverUI.SetActive(true);
                if (objectName == "Axe")
                    axeUI.SetActive(true);
                break;
            default: 
                break;
        }
       
    } 
}