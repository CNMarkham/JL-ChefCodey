using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stove : MonoBehaviour
{

    public GameObject toast;

    // Start is called before the first frame update
    void Start()
    {
        toast.SetActive(false);
    }

    public void ToastBread()
    {
        toast.SetActive(true);
    }

    public void CleanStove()
    {

    }
}
