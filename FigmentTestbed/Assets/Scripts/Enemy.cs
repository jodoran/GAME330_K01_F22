using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float health = 50f;


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
        }
    }

    public void Die()
    {
        Debug.Log("Zombie has died");
        Destroy(gameObject);
    }
}
