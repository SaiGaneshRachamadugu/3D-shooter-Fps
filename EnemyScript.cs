using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public float health = 50f;

    public void takedamage(float damage) {
        health -= damage;
        Debug.Log(health);
        if (health <= 0f) {
            Die();
        }
    }

    void Die() {
        Destroy(gameObject);
    }
}
