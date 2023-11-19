using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableServe : MonoBehaviour
{
    public Interact interact;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    //oncollisionenter check if tag is player, update every frame space + checks + interact. oncollision exit maybe
    private void OnCollisionStay(Collision collision)
    {
        if(Input.GetKeyDown("space"))
        {
            Debug.Log("CollidedPLayer");
            if(collision.gameObject.tag == "Player" && interact.heldItemName == "BurgerComplete" && GameObject.Find("TableReceivers/" + gameObject.name + "/Tray_Blue").activeInHierarchy == false)
            {
                Debug.Log("space + burgercomplete + notactive");
                interact.ServeBurger(gameObject);
            }
        }
    }
}
