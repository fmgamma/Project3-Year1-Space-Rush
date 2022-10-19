//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.UI;
//using UnityEngine.Events;


//public class FillBars : MonoBehaviour
//{
//    //UI references
//    public Slider slider;
//    public text displayText;

//    //handle slider value
//    private flat currentValue = 0f;
//    public float CurrentValue
//    {
//        get
//        {
//            return currentValue;
//        }

//        set
//        {
//            currentValue = value;
//            slider.value = currentValue;
//            displayText.text = slider.value.ToString();
//        }
//    }

//    //initialisation
//    void Start()
//    {
//        CurrentValue = 0f;
//    }

//    //called once per frame
//    void Update()
//    {
//        CurrentValue += 0.0043f;
//    }
//}