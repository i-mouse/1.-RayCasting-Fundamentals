using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float health = 50f;
   
    public void TakingDamage(float amount)
    {
        health -= amount;
        if(health<=0)
        {
            Destroy(gameObject);
        }
    }
}
