using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public float health = 50f;
    public static bool enemyDied = false;

    private void OnTriggerEnter(Collider other)
    {
        TakeDamage(10);
    }
    public void TakeDamage(float amount)
    {
        health -= amount;
        if(health <= 0f)
        {
            Die();
            enemyDied = true;
        }
        else
        {
            enemyDied = false;
        }
    }

    public void Die()
    {
        Debug.Log("Zombie has died");
        Destroy(gameObject);
    }
}
