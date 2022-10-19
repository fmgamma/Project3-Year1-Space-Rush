using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerStinger : MonoBehaviour
{
    [SerializeField] private GameObject timer = null;
    private MeshRenderer txtRenderer;
    private TimerManager timeManager;

    // Start is called before the first frame update
    void Start()
    {
        timeManager = timer.GetComponent<TimerManager>();
        txtRenderer = GetComponent<MeshRenderer>();
        txtRenderer.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (timeManager.timerFloat < 0)
        {
            txtRenderer.enabled = true;
        }
    }
}
