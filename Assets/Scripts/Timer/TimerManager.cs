using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TimerManager : MonoBehaviour
{
    [SerializeField] private PlayerManager player1 = null;
    [SerializeField] private PlayerManager player2 = null;

    private TextMesh txt;
    public float timerFloat;

    // Start is called before the first frame update
    void Start()
    {
        txt = GetComponent<TextMesh>();
        timerFloat = 90.0f;
    }

    // Update is called once per frame
    void Update()
    {
        timerFloat -= Time.deltaTime;
        if (timerFloat > 10)
        {
            txt.text = string.Format("Time: {0:0}", timerFloat);
        }
        else if (timerFloat > 0)
        {
            txt.color = new Color(1, 0.5f, 0.5f);
            txt.text = string.Format("Time: {0:0.00}", timerFloat);
        }
        else if (timerFloat <= 0)
        {
            Time.timeScale = 0.3f;
            txt.text = "Time: 0";
        }
        if (timerFloat < -1)
        {
            PlayerPrefs.SetFloat("P1 Score", player1.crownedTime);
            PlayerPrefs.SetFloat("P2 Score", player2.crownedTime);
            Time.timeScale = 1.0f;
            SceneManager.LoadScene("PostGame");
        }
    }
}
