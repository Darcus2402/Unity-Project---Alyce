using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float horiz;
    private float vertic;

    [SerializeField] [Range(0, 100)] float speed;
    [SerializeField] private Animator animator;
    [SerializeField] private SpriteRenderer spriteRend;

    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start() 
    {
        rb = this.GetComponent<Rigidbody2D>();    
    }

    // Update is called once per frame
    void Update()
    {
        horiz = Input.GetAxisRaw("Horizontal");
        vertic = Input.GetAxisRaw("Vertical");
    }


    private void FixedUpdate() {
        rb.velocity = new Vector2(horiz * speed, vertic * speed);

        // SideMovement
        if(horiz != 0) {
            animator.SetBool("SideMovement", true);

            if(horiz > 0) {
                spriteRend.flipX = false;
            } else {
                spriteRend.flipX = true;
            }

        } else {
            animator.SetBool("SideMovement", false);
        }

        //VerticalMovement
        if (horiz == 0) {
            if (vertic != 0) {
                if (vertic > 0) {
                    // stiamo andando sopra
                    animator.SetBool("BackMovement", true);
                    animator.SetBool("FrontMovement", false);
                }
                else if (vertic < 0) {
                    //stiamo andando sotto
                    animator.SetBool("BackMovement", false);
                    animator.SetBool("FrontMovement", true);
                }
            }
            else if (vertic == 0) {
                animator.SetBool("BackMovement", false);
                animator.SetBool("FrontMovement", false);
            }
        }
    }
}
