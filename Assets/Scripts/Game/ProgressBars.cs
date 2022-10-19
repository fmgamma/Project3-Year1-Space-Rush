using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class ProgressBars : MonoBehaviour
{
    public GameObject P1TimerBar;
    public GameObject P2TimerBar;
    private Slider barSlider1;
    private Slider barSlider2;
    public GameObject P1Crown;
    public GameObject P2Crown;
    private float P1Score;
    private float P2Score;
    private bool bar1Filled;
    private bool bar2Filled;
    private bool updatesDone;

    //initialisation
    void Start()
    {
        P1Score = PlayerPrefs.GetFloat("P1 Score");
        P2Score = PlayerPrefs.GetFloat("P2 Score");
        P1Crown.SetActive(false);
        P2Crown.SetActive(false);
        barSlider1 = P1TimerBar.GetComponent<Slider>();
        barSlider1.value = 0.0f;
        barSlider2 = P2TimerBar.GetComponent<Slider>();
        barSlider2.value = 0.0f;
        updatesDone = false;
    }

    //called once per frame
    void Update()
    {
        float DeltaTime = Time.deltaTime;

        if (barSlider1.value < P1Score)
        {
            barSlider1.value += 45.0f * DeltaTime;
            if (barSlider1.value >= P1Score)
            {
                barSlider1.value = P1Score;
                bar1Filled = true;
            }
        }
        if (barSlider2.value < P2Score)
        {
            barSlider2.value += 45.0f * DeltaTime;
            if (barSlider2.value >= P2Score)
            {
                barSlider2.value = P2Score;
                bar2Filled = true;
            }
        }

        if(bar1Filled && bar2Filled && !updatesDone)
        {
            if (PlayerPrefs.GetFloat("P1 Score") > PlayerPrefs.GetFloat("P2 Score"))
            {
                P1Crown.SetActive(true);
            }
            else
            {
                P2Crown.SetActive(true);
            }
                updatesDone = true;
        }
    }
}

