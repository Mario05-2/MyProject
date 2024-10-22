using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class healthPlayer : MonoBehaviour
{
    public int maxHealth;
    public int currentHealth;
    
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    void TakeDamage(int amount)
    {
        currentHealth -= amount;
        if(currentHealth<= 0)
        {
            Destroy(gameObject);

            //We're dead
            //can play Game over screen
            //could play a death animation
        }
    }

}
