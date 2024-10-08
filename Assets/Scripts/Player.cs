using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int PlayerHealth = 0;
    // Start is called before the first frame update
    void Start()
    {
        PlayerHealth = 100;
    }

    // Update is called once per frame
    void Update()
    {
       if (PlayerHealth > 99) Debug.Log("PlayerHealth is = " + PlayerHealth);
    }
}
