using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int Health;
    [SerializeField] private int initialHealth = 3;

    // Start is called before the first frame update
    void Start()
    {
        initialHealth = Random.Range(2, 6);
        Health = initialHealth;
    }


    public void OnHit(int damage) {
        Health -= damage;

        if (Health <= 0) {
            EnemyDie();
        }
    }

    void EnemyDie() {
        //fa cose
        Debug.Log("Die");
        Destroy(gameObject);
    }
}
