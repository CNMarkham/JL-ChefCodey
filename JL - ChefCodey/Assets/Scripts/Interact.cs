using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact : MonoBehaviour
{
    public string triggerName = "";

    public GameObject BurgerTopPrefab;
    public GameObject BurgerBottomPrefab;
    public GameObject BurgerGreensPrefab;
    public GameObject BurgerPattiesPrefab;

    public GameObject heldItem;

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
                heldItem = Instantiate(BurgerTopPrefab, transform, false);
                heldItem.transform.localPosition = new Vector3(0, 2, 2);
            }
            else if(triggerName == "Burger_Bottom")
                {
                    heldItem = Instantiate(BurgerBottomPrefab, transform, false);
                    heldItem.transform.localPosition = new Vector3(0, 3, 2);
                }
            else if (triggerName == "Burger_Greens")
            {
                heldItem = Instantiate(BurgerGreensPrefab, transform, false);
                heldItem.transform.localPosition = new Vector3(0, 2, 2);
            }
            else if (triggerName == "Burger_Patties")
            {
                heldItem = Instantiate(BurgerPattiesPrefab, transform, false);
                heldItem.transform.localPosition = new Vector3(0, 2, 2);
            }
        }
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
