using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    [SerializeField] GameObject hitEffect;
    [SerializeField] int damage = 1;


    private void OnCollisionEnter2D(Collision2D collision) {
        if (hitEffect != null) {
            GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
            Destroy(effect, 3f);

        }

        if (collision.gameObject.TryGetComponent<EnemyHealth>(out EnemyHealth enemyDamage))
        {
            enemyDamage.OnHit(damage);
            Destroy(gameObject);
        } else
        {
            Destroy(gameObject);
        }
        
    }

    private void Update() {
        Destroy(gameObject, 5f);
    }
}
