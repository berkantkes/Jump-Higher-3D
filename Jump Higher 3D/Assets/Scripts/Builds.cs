using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Builds : MonoBehaviour
{
    public GameObject progressBar;
    private int maxhealth = 10;
    

    private void Start()
    {
        progressBar.GetComponent<ProgressBar>().SetMaxHealth(maxhealth);
    }
     
    public void Painting()
    {
        progressBar.GetComponent<ProgressBar>().IncreaseHealth();
    }
}
