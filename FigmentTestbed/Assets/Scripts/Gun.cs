using UnityEngine;

public class Gun : MonoBehaviour
{
    public float damage = 10f;
    public float range = 100f;
    public Camera fpsCam;

    public Transform bulletSpawnPoint;
    public GameObject bulletPrefab;
    public float bulletSpeed = 10;

    public enum FigmentButton
    {
        LeftButton,
        RightButton,
        ActionButton
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("space"))
        {

        }
    }

    void Shoot()
    {
        RaycastHit hitInfo;

        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hitInfo, range))
        {
            Debug.Log(hitInfo.transform.name);

            Enemy enemy = hitInfo.transform.GetComponent<Enemy>();
            if(enemy != null)
            {
                enemy.TakeDamage(damage);
            }
        }
    }
}
