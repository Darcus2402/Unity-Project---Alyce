using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuocoFatuoShooting : MonoBehaviour
{
    [SerializeField] private Transform firePoint;
    [SerializeField] GameObject bulletPrefab;

    [SerializeField] private float bulletForce = 20f;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1)) {
            Shoot();
        }
    }


    void Shoot() {
        //GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation); -95 ora
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        bullet.GetComponent<Rigidbody2D>().AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
    }
}
