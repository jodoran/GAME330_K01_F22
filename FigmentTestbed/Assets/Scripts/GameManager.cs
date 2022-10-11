using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Enemy newEnemy = new Enemy();
    public GameObject newBullet;

    bool isTouching = false;

    float maxDistance = 1;

    private void OnTriggerStay(Collider other)
    {
        if(Vector3.Distance(other.transform.position, this.transform.position) < maxDistance)
        {
            isTouching = true;
        }
        else
        {
            isTouching = false;
        }
    }

    void Update()
    {
        if(isTouching == true)
        {

            newEnemy.Die();
        }
    }
}
