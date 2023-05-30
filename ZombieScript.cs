using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombieScript : MonoBehaviour
{
    [SerializeField] Transform target;
    NavMeshAgent agent;
    [SerializeField] float moveSpeed;
    [SerializeField] int Damage;
    [SerializeField] float distanceForAttack = 1.5f;

    bool staAttaccando = false;

    // Start is called before the first frame update
    void Start()
    {
        moveSpeed = Random.Range(1, 4);
        Damage = 1;
        target = GameObject.Find("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position += (target.transform.position - transform.position).normalized * moveSpeed * Time.deltaTime;
        

        if(Vector2.Distance(this.transform.position, target.transform.position) < distanceForAttack && !staAttaccando)
        {
            Debug.Log("Inizio Attacco");
            staAttaccando = true;
            //inizio attacco
            StartCoroutine(ZombieAttack());

        }
    }

    IEnumerator ZombieAttack()
    {
        yield return new WaitForSeconds(2.3f);
        Debug.Log("Check distanza, continuo");
        if (Vector2.Distance(this.transform.position, target.transform.position) <= distanceForAttack)
        {

            target.GetComponent<PlayerHealth>().PlayerTakeDamage(Damage);
            Debug.Log("Danno eseguito");
        }
        staAttaccando = false;
    }
}
