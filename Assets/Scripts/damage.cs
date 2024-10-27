using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class damage : MonoBehaviour
{
    public playerHealth PlayerHealth;
    public int amountDamage = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collsion)
    {
        if (collsion.gameObject.tag == "Player")
        {
            PlayerHealth.TakeDamage(amountDamage);
        }
    }

   
}
