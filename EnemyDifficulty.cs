using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDifficulty : MonoBehaviour
{
    [SerializeField] ProgressScript progressScript;
    [SerializeField] GameObject[] Spawners;

    public float progressoCopia;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        progressoCopia = progressScript._progresso;

        AttivaSpawner();

    }

    void AttivaSpawner()
    {
        switch (progressoCopia)
        {
            case 10:
                Spawners[1].SetActive(true);
                break;
            case 40:
                Spawners[2].SetActive(true);
                break;
            case 60:
                Spawners[3].SetActive(true);
                break;
            case 80:
                Spawners[4].SetActive(true);
                break;
            case 95:
                Spawners[5].SetActive(true);
                break;
        }

    }
}
