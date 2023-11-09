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
    public GameObject CookedPatty;

    public GameObject heldItem;
    public string heldItemName;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("space"))
        {
            if(triggerName == "Burger_Top")
            {
                PickUpItem(BurgerTopPrefab, "BurgerTop", new Vector3(0, 2, 2));
            }
            if(triggerName == "Burger_Bottom")
            {
                PickUpItem(BurgerBottomPrefab, "BurgerBottom", new Vector3(0, 3, 2));
            }
            if (triggerName == "Burger_Greens")
            {
                PickUpItem(BurgerGreensPrefab, "BurgerGreens", new Vector3(0, 2, 2));
            }
            if (triggerName == "Burger_Patties")
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
                    if(stove.cookedFood == "ToastedTop")
                    {
                        PickUpItem(BurgerTopPrefab, "ToastedBurgerTop", new Vector3(0, 2, 2));
                        stove.CleanStove();
                    }
                    if (stove.cookedFood == "ToastedBottom")
                    {
                        PickUpItem(BurgerBottomPrefab, "ToastedBurgerBottom", new Vector3(0, 3, 2));
                        stove.CleanStove();
                    }
                    if (stove.cookedFood == "CookedPatty")
                    {
                        PickUpItem(BurgerPattiesPrefab, "CookedPatties", new Vector3(0, 2, 2));
                        stove.CleanStove();
                    }
                }
            }

            if(triggerName == "Receivers")
            {
                if(heldItemName == "ToastedBurgerTop")
                {
                    PlaceHeldItem();
                    GameObject.Find("Receivers/Burger/ToastedBurgerTop").SetActive(true);
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
}
