using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostMovement : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;
    [SerializeField][Range(0, 100)] float speed;
    [SerializeField] Camera Cam;
    [SerializeField] Animator animator;
    [SerializeField] SpriteRenderer spriteRend;



    private float horizontal, vertical;
    private Vector2 mousePositionInWorld;

    // Start is called before the first frame update
    void Start()
    {
        rb.GetComponent<Rigidbody2D>();
        Cam = Cam ?? Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");

        // prendi posizione del mouse nel mondo in base alla pos della camera
        mousePositionInWorld = Cam.ScreenToWorldPoint(Input.mousePosition);
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * speed, vertical * speed);
        CheckAnimator();

        Vector2 lookDir = mousePositionInWorld - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        // rb.rotation = angle;
    }


    void CheckAnimator()
    {

        if (horizontal != 0)
        {
            // sta andando in orizzontale
            if (horizontal > 0)
            {
                // sta andando a destra
                animator.SetBool("DiLato", true);
                spriteRend.flipX = false;
            }
            else if (horizontal < 0)
            {
                animator.SetBool("DiLato", true);
                spriteRend.flipX = true;
            }
        }
        else
        {
            animator.SetBool("DiLato", false);
        }


        if (vertical != 0)
        {
            if (vertical > 0)
            {
                // sta andando sopra
                animator.SetBool("Sopra", true);
                animator.SetBool("Sotto", false);
            }
            else if (vertical < 0)
            {
                // sta andando sotto
                animator.SetBool("Sotto", true);
                animator.SetBool("Sopra", false);
            }
        }
        else
        {
            animator.SetBool("Sotto", false);
            animator.SetBool("Sopra", false);
        }
    }
}

