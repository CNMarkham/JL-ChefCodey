using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact : MonoBehaviour
{
    public Stove stove;

    public string triggerName = "";

    public GameObject BurgerTopPrefab;
    public GameObject BurgerBottomPrefab;
    public GameObject BurgerGreensPrefab;
    public GameObject BurgerPattiesPrefab;
    public GameObject CookedPattiesPrefab;

    public GameObject heldItem;
    public string heldItemName;

    [Header("Serving")]
    public int burgerComplete;
    public GameObject BurgerPrefab;
    // Start is called before the first frame update
    void Start()
    {
        burgerComplete = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("space"))
        {
            if(triggerName == "Burger_Top" && heldItemName == "")
            {
                PickUpItem(BurgerTopPrefab, "BurgerTop", new Vector3(0, 2, 2));
            }
            if(triggerName == "Burger_Bottom" && heldItemName == "")
            {
                PickUpItem(BurgerBottomPrefab, "BurgerBottom", new Vector3(0, 3, 2));
            }
            if (triggerName == "Burger_Greens" && heldItemName == "")
            {
                PickUpItem(BurgerGreensPrefab, "BurgerGreens", new Vector3(0, 2, 2));
            }
            if (triggerName == "Burger_Patties" && heldItemName == "")
            {
                PickUpItem(BurgerPattiesPrefab, "BurgerPatties", new Vector3(0, 2, 2));
            }

            if (triggerName == "Stove")
            {
                if(heldItemName == "BurgerTop")
                {
                    stove.ToastBurgerTop();
                    PlaceHeldItem();
                }
                else if (heldItemName == "BurgerBottom")
                {
                    stove.ToastBurgerBottom();
                    PlaceHeldItem();
                }
                else if (heldItemName == "BurgerPatties")
                {
                    stove.CookPatty();
                    PlaceHeldItem();
                }
                else
                {
                    if(stove.cookedFood == "ToastedTop" && stove.isCooking == false)
                    {
                        PickUpItem(BurgerTopPrefab, "ToastedBurgerTop", new Vector3(0, 2, 2));
                        stove.CleanStove();
                    }
                    if (stove.cookedFood == "ToastedBottom" && stove.isCooking == false)
                    {
                        PickUpItem(BurgerBottomPrefab, "ToastedBurgerBottom", new Vector3(0, 3, 2));
                        stove.CleanStove();
                    }
                    if (stove.cookedFood == "CookedPatty" && stove.isCooking == false)
                    {
                        PickUpItem(CookedPattiesPrefab, "CookedPatties", new Vector3(0, 2, 2));
                        stove.CleanStove();
                    }
                }
            }

            if(triggerName == "Receivers")
            {
                if(heldItemName == "ToastedBurgerTop" && GameObject.Find("Receivers/Burger/ToastedBurgerTop").activeInHierarchy == false)
                {
                    PlaceHeldItem();
                    GameObject.Find("Receivers/Burger/ToastedBurgerTop").SetActive(true);
                    burgerComplete += 1;
                }
                if (heldItemName == "ToastedBurgerBottom" && GameObject.Find("Receivers/Burger/ToastedBurgerBottom").activeInHierarchy == false)
                {
                    PlaceHeldItem();
                    GameObject.Find("Receivers/Burger/ToastedBurgerBottom").SetActive(true);
                    burgerComplete += 1;
                }
                if (heldItemName == "CookedPatties" && GameObject.Find("Receivers/Burger/CookedBurgerPatties").activeInHierarchy == false)
                {
                    PlaceHeldItem();
                    GameObject.Find("Receivers/Burger/CookedBurgerPatties").SetActive(true);
                    burgerComplete += 1;
                }
                if (heldItemName == "BurgerGreens" && GameObject.Find("Receivers/Burger/BurgerGreens").activeInHierarchy == false)
                {
                    PlaceHeldItem();
                    GameObject.Find("Receivers/Burger/BurgerGreens").SetActive(true);
                    burgerComplete += 1;
                }
                if (burgerComplete == 4)
                {
                    PickUpItem(BurgerPrefab, "BurgerComplete", new Vector3(0, 2, 2));
                    GameObject.Find("Receivers/Burger/ToastedBurgerTop").SetActive(false);
                    GameObject.Find("Receivers/Burger/ToastedBurgerBottom").SetActive(false);
                    GameObject.Find("Receivers/Burger/CookedBurgerPatties").SetActive(false);
                    GameObject.Find("Receivers/Burger/BurgerGreens").SetActive(false);
                    burgerComplete = 0;
                }
            }
        }
    }


    private void PickUpItem(GameObject itemPrefab, string itemName, Vector3 offset)
    {
        heldItem = Instantiate(itemPrefab, transform, false);
        heldItem.transform.localPosition = offset;
        heldItemName = itemName;
    }
    private void PlaceHeldItem()
    {
        Destroy(heldItem);
        heldItemName = "";
    }

    private void OnTriggerEnter(Collider other)
    {
        triggerName = other.name;
        print(triggerName);
    }

    private void OnTriggerExit(Collider other)
    {
        triggerName = "";
    }

    public void ServeBurger(GameObject burgerTable)
    {
        PlaceHeldItem();
        GameObject.Find("TableReceivers/" + burgerTable.name + "/Tray_Blue").SetActive(true);
        GameObject.Find("TableReceivers/" + burgerTable.name + "/ToastedBurgerTop").SetActive(true);
        GameObject.Find("TableReceivers/" + burgerTable.name + "/BurgerGreens").SetActive(true);
        GameObject.Find("TableReceivers/" + burgerTable.name + "/CookedBurgerPatties").SetActive(true);
        GameObject.Find("TableReceivers/" + burgerTable.name + "/ToastedBurgerBottom").SetActive(true);
        
    }
}
