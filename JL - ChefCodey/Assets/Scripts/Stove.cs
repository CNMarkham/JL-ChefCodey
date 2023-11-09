using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stove : MonoBehaviour
{

    public GameObject toast;
    public GameObject bottomtoast;
    public GameObject cookedpatty;

    public string cookedFood = "";

    // Start is called before the first frame update
    void Start()
    {
        toast.SetActive(false);
        bottomtoast.SetActive(false);
        cookedpatty.SetActive(false);
    }

    public void ToastBurgerTop()
    {
        toast.SetActive(true);
        cookedFood = "ToastedTop";
    }

    public void ToastBurgerBottom()
    {
        bottomtoast.SetActive(true);
        cookedFood = "ToastedBottom";
    }

    public void CookPatty()
    {
        cookedpatty.SetActive(true);
        cookedFood = "CookedPatty";
    }

    public void CleanStove()
    {
        toast.SetActive(false);
        cookedpatty.SetActive(false);
        //bottomtoast turns off immediately
        bottomtoast.SetActive(false);
        cookedFood = "";
    }
}
