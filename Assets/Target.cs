using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public float health = 1f;

    public void takeDamage(float amount)
    {
        health -= amount;
        if (health <= 0f){
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }
}
