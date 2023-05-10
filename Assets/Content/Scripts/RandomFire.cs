using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

//Created by John Montesa
public class RandomFire : MonoBehaviour
{
    public GameObject fire;
    public GameObject treeNotDead;
    public int health;
    public int chance;
    public bool simRun = false;
    public bool onFire;
    public int probability = 25;
    public int score = 0;

    // Start is called before the first frame update
    void Start()
    {
        fire.SetActive(false);
        treeNotDead.SetActive(true);
        health = Random.Range(5, 10);
        onFire = false;

        InvokeRepeating("Update", 0f, 5f);
    }

    // Update is called once per frame
    void Update()
    {
        if (simRun == false && health > 0)
        {
            StartCoroutine(fireChance());
        }

        if (health == 0)
        {
            onFire = false;
            fire.SetActive(false);
            treeNotDead.SetActive(false);
            score -= 300;
        }
        //if health==1{
        //  onFire = false,
        // fire.SetActive(false);
        // score += 300;
        //}
    }

    IEnumerator fireChance()
    {
        simRun = true;

        yield return new WaitForSeconds(3);
        chance = Random.Range(0, 100);
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
}

//oncollision{
//  health ++;
//}





