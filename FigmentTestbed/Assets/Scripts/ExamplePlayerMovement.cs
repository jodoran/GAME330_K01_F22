using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExamplePlayerMovement : MonoBehaviour {

    public float TurnSpeed = 120.0f;
    public float MoveSpeed = 8.0f;

    
    public Transform bulletSpawnPoint;
    public GameObject bulletPrefab;
    public float bulletSpeed = 10;
    public float fireRate;
    private float lastShotTime = 0;

    public AudioSource gunSoundEffect;

    // Update is called once per frame
    void Update () {

        Quaternion to;

        if (FigmentInput.GetButton(FigmentInput.FigmentButton.LeftButton))
        {
            to = Quaternion.Euler(0, transform.rotation.eulerAngles.y - 1, 0);
            //transform.Rotate(Vector3.up, -TurnSpeed * Time.deltaTime);
            transform.rotation = Quaternion.Slerp(transform.rotation, to, TurnSpeed * Time.deltaTime);
        }
        else if (FigmentInput.GetButton(FigmentInput.FigmentButton.RightButton))
        {
            to = Quaternion.Euler(0, transform.rotation.eulerAngles.y + 1, 0);
            transform.rotation = Quaternion.Slerp(transform.rotation, to, TurnSpeed * Time.deltaTime);
        }
        else
        {
            to = Quaternion.Euler(0, transform.rotation.eulerAngles.y, 0);
            transform.rotation = Quaternion.Slerp(transform.rotation, to, TurnSpeed * Time.deltaTime/2);
        }

        

        if (FigmentInput.GetButton(FigmentInput.FigmentButton.ActionButton))
        {
            //transform.Translate(Vector3.forward * MoveSpeed * Time.deltaTime);

            if(Time.time > lastShotTime + fireRate)
            {
                Debug.Log("Shoot");
                lastShotTime = Time.time;

                GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
                bullet.GetComponent<Rigidbody>().velocity = bulletSpawnPoint.forward * bulletSpeed;

                gunSoundEffect.Play();
            }
            

            /*
            Rigidbody clone;

            clone = Instantiate(projectile, transform.position, transform.rotation);

            clone.velocity = transform.TransformDirection(Vector3.forward * 10);
            */
        }
    }
}
