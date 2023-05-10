using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class WaterCollision : MonoBehaviour
{
    public RandomFire randomFire;
    private Waterbend water;

    void Start()
    {
        // Find the Waterbend component attached to the same GameObject as this script
        water = GetComponent<Waterbend>();
    }

    private void OnTriggerEnter(Collider other)
    {
        // Get the Waterbend component attached to the collided object
        Waterbend otherWater = other.GetComponent<Waterbend>();
        Debug.Log("Trigger entered");
        if (otherWater == null)
        {
            // Increase the health of the tree
            randomFire.health += 1;
            Debug.Log("Health Increased!");

            // Check if the tree has reached 15 hp, and turn off the fire if it has
            if (randomFire.health >= 15)
            {
                randomFire.score += 300;
            }

            // Check if the tree is dead, and decrease score if it is
            if (randomFire.health <= 0)
            {
                randomFire.score -= 300;
            }

            // Destroy the water object
            Destroy(other.gameObject);
        }
    }
}
