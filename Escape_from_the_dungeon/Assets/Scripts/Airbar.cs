using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Airbar : MonoBehaviour
{
    // Start is called before the first frame update
    double airbar;
    public Slider slider;
    void Start()
    {
        airbar = GameObject.Find("Player").GetComponent<PlayerControl>().airbar/100;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("Player"))
        {
            airbar = GameObject.Find("Player").GetComponent<PlayerControl>().airbar / 100;
            slider.value = (float)airbar;
        }
    }
}
