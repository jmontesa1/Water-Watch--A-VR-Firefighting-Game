using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

/// <summary>
/// Created by John Montesa, TIMER
/// </summary>

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI textDisplay;
    public int secondsLeft;
    public bool takingAway = false;
    public int minutesLeft;
    public GameObject scoreMenu = new GameObject();
    public float timeStart;
    public bool done;

    void Start()
    {
        scoreMenu.SetActive(false);
        textDisplay.text = "0:00";
        StartCoroutine(wait());
        done = false;
    }

    void Update()
    {
        if (takingAway == false && secondsLeft >= 0 && done == false)
        {
            StartCoroutine(TimerTake());
        }

        if (secondsLeft <= 0 && minutesLeft <= 0)
        {
            textDisplay.text = "0:00";
            done = true;
            scoreMenu.SetActive(true);
        }

    }
    IEnumerator TimerTake() 
    {
        takingAway = true;
        yield return new WaitForSeconds(1);
        if(secondsLeft == 0)
        {
            secondsLeft += 60;
            minutesLeft -= 1;
        }
        secondsLeft -= 1;

        if (secondsLeft < 10)
        {
            textDisplay.text = minutesLeft + ":0" + secondsLeft;

        }
        else
        {
            textDisplay.text = minutesLeft + ":" + secondsLeft;
        }
        takingAway = false;

    }

    IEnumerator wait()
    {
        yield return new WaitForSeconds(timeStart);
    }

}
