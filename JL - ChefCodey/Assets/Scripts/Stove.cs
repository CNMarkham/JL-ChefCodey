using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stove : MonoBehaviour
{
    [Header("Prefabs")]
    public GameObject toast;
    public GameObject bottomtoast;
    public GameObject cookedpatty;

    [Header("Inventory")]
    public string cookedFood = "";
    public bool isCooking = false;

    [Header("Particles")]
    public ParticleSystem smoke;
    public ParticleSystem complete;

    // Start is called before the first frame update
    void Start()
    {
        toast.SetActive(false);
        bottomtoast.SetActive(false);
        cookedpatty.SetActive(false);
    }

    public void ToastBurgerTop()
    {
        isCooking = true;
        smoke.Play();
        toast.SetActive(true);
        cookedFood = "ToastedTop";
        Invoke("CompleteCooking", 6f);
    }

    public void ToastBurgerBottom()
    {
        isCooking = true;
        smoke.Play();
        bottomtoast.SetActive(true);
        cookedFood = "ToastedBottom";
        Invoke("CompleteCooking", 6f);
    }

    public void CookPatty()
    {
        isCooking = true;
        smoke.Play();
        cookedpatty.SetActive(true);
        cookedFood = "CookedPatty";
        Invoke("CompleteCooking", 8f);
    }

    public void CleanStove()
    {
        toast.SetActive(false);
        cookedpatty.SetActive(false);
        bottomtoast.SetActive(false);
        cookedFood = "";
        complete.Stop();
    }

    private void CompleteCooking()
    {
        isCooking = false;
        smoke.Stop();
        complete.Play();
    }
}
