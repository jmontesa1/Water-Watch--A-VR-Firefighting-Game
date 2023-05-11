using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;
using Debug = UnityEngine.Debug;
using TMPro;
using System.Diagnostics;
using System.Threading;

//Created by John Montesa
public class RandomFire : MonoBehaviour
{
    public GameObject fire;
    public GameObject treeNotDead;
    public int health;
    public int chance;
    public bool simRun = false;
    public bool onFire;
    public int probability = 10;
    public static int score;
    public TextMeshProUGUI pointsDisplay;
    public TextMeshProUGUI final;
    //public Timer timer;

    // Start is called before the first frame update
    void Start()
    {
        chance = Random.Range(1, 100);
        fire.SetActive(false);
        treeNotDead.SetActive(true);
        health = Random.Range(5, 10);
        onFire = false;
        score = 0;
        Debug.Log("Start methdo random fire");
    }

    // Update is called once per frame
    void Update()
    {
        pointsDisplay.text = "" + score;

        if (simRun == false && health > 0)
        {
            StartCoroutine(fireChance());
        }

        if (simRun == false && health <= 0)
        {
            RandomFire.dencrementScore();
            onFire = false;
            fire.SetActive(false);
            treeNotDead.SetActive(false);
            this.enabled = false;
        }

        /*if (timer.done == true)
        {
            StartCoroutine(endgame());
        }*/

        //if health == 15
        if (health >= 15)
        {
            RandomFire.incrementScore();
            onFire = false;
            fire.SetActive(false);
            health = Random.Range(5, 10);

        }
        final.text = "" + score;
        }

    IEnumerator fireChance()
    {
        simRun = true;

        yield return new WaitForSeconds(3);
        chance = Random.Range(1, 100);
        if (chance < probability && onFire == false)
        {
            fire.SetActive(true);
            onFire = true;
        }
        else if (onFire == true)
        {
            health--;
        }
        simRun = false;
    }

    public static void incrementScore() 
    {
        score += 300;
    }

    public static void dencrementScore()
    {
        score -= 300;
    }

    /*IEnumerator endgame()
    {
        //simRun = true;
        //yield return new WaitForSeconds(300);
        //simRun = false;
    }*/

}


