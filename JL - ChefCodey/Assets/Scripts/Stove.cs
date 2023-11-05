using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stove : MonoBehaviour
{

    public GameObject toast;

    public string cookedFood = "";

    // Start is called before the first frame update
    void Start()
    {
        toast.SetActive(false);
    }

    public void ToastBurgerTop()
    {
        toast.SetActive(true);
        cookedFood = "ToastedTop";
    }

    public void CleanStove()
    {
        toast.SetActive(false);
        cookedFood = "";
    }
}
