using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerScript : MonoBehaviour
{
    [SerializeField] float spawnerColdown;
    [SerializeField] GameObject enemy;

    float coldownTemp;
    // Start is called before the first frame update
    void Start()
    {
        coldownTemp = spawnerColdown;
    }

    // Update is called once per frame
    void Update()
    {

        if(coldownTemp - Time.deltaTime > 0)
        {
            coldownTemp -= Time.deltaTime;
            // sta ancora in coldown
        } else
        {
            //reset coldown
            coldownTemp = spawnerColdown;
            SpawnaNemico();
        }
    }


    void SpawnaNemico()
    {
        Instantiate(enemy, this.transform.position, Quaternion.identity);
    }
}
