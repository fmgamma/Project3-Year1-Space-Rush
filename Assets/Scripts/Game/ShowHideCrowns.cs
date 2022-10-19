using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowHideCrowns : MonoBehaviour
{
    public GameObject P1Crown;
    public GameObject P2Crown;
    public GameObject P1TimerBar;
    public GameObject P2TimerBar;



    // Start is called before the first frame update
    void Start()
    {
        P1Crown.SetActive(false);
        P2Crown.SetActive(false);

        if (PlayerPrefs.GetFloat("P1 Score") > PlayerPrefs.GetFloat("P2 Score"))
        {
            P1Crown.SetActive(true);
        }
        else
        {
            P2Crown.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
