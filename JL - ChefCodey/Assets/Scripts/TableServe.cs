using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableServe : MonoBehaviour
{
    public Interact interact;
    public bool playerCollided;
    // Start is called before the first frame update
    void Start()
    {
        playerCollided = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(playerCollided == true)
        {
            if(Input.GetKeyDown("space"))
            {

                if(interact.heldItemName == "BurgerComplete" && GameObject.Find("TableReceivers/" + gameObject.name + "/Tray_Blue").activeInHierarchy == false)
                {
                    interact.ServeBurger(gameObject);
                }
            }
        }
    }
    public void OnTriggerEnter(Collider other)
    {
 
        if (other.gameObject.tag == "Player")
        {
            playerCollided = true;
        }
    }
}