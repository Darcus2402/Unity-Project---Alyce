using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdjustSortingLayer : MonoBehaviour
{
    private SpriteRenderer spriteRend;
    [SerializeField] private bool isPlayer;
    // Start is called before the first frame update
    void Start()
    {
        spriteRend = this.GetComponent<SpriteRenderer>();   
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlayer) {
            spriteRend.sortingOrder = 1 + (int)Mathf.Abs((int)transform.position.y * 0.5f);
        }
        else {
            spriteRend.sortingOrder = (int)Mathf.Abs((int)transform.position.y * 0.5f);
        }
    }
}
