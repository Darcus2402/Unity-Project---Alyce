using UnityEngine;

public class GhostMeleeAttack : MonoBehaviour {
    [SerializeField] Camera camerinapiccina;
    [SerializeField] float attackOffset = 2f;
    [SerializeField] GameObject attackGameObject;
    [SerializeField] int damage = 1;
    [SerializeField] float coldown = 0.3f;
    [SerializeField] SpriteRenderer spriteRend;

    private float _coldown;
    private Animator animator;
    private Vector3 mousePos;
    private Collider2D hitCollider;


    // Start is called before the first frame update
    void Start() {
        _coldown = coldown;
        animator = attackGameObject.GetComponent<Animator>();
        hitCollider = attackGameObject.GetComponent<Collider2D>();
        spriteRend = attackGameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update() {
        if (_coldown <= 0) {
            if (Input.GetMouseButtonDown(0)) {
                mousePos = camerinapiccina.ScreenToWorldPoint(Input.mousePosition);
                Vector3 mouseDir = (mousePos - transform.position).normalized;
                Debug.Log(mouseDir);

                Vector3 attackPosition = transform.position + mouseDir * attackOffset;
                //Debug.Log(attackPosition);
                // POSIZIONE

                settaPosizioneAngolosa(mouseDir);
                attackGameObject.transform.position = attackPosition;

                // POSIZIONE
                animator.SetTrigger("AttackAnimOn");
                //Debug.Log("animator trigger 0 on");
                _coldown = coldown; // reset coldown
            }
        }
        else _coldown -= Time.deltaTime;
    }


    private void OnTriggerEnter2D(Collider2D collision) {
        Debug.Log(collision.name);

        if (collision.gameObject.TryGetComponent<EnemyHealth>(out EnemyHealth enemyTakeDamage)) {
            enemyTakeDamage.OnHit(damage);
        }
    }

    void settaPosizioneAngolosa(Vector3 posizione) {

        string luogo;

        if (Mathf.Abs(posizione.x) > Mathf.Abs(posizione.y)) {
            // domina la x
            if (posizione.x > 0) {
                // la x sta a destra
                luogo = "destra";
                print("vince x destra");
            }
            else {
                // la x sta a sinistra
                luogo = "sinistra";
                print("vince x sinistra");
            }
        }
        else {
            // domina la y
            if (posizione.y > 0) {
                // la y sta sopra
                luogo = "sopra";
                print("vince y destra");
            }
            else {
                // la y sta a sinistra
                luogo = "sotto";
                print("vince y sinistra");
            }
        }


        switch (luogo) {
            case "destra":
                spriteRend.flipX = false;
                attackGameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
                break;
            case "sinistra":
                spriteRend.flipX = true;
                attackGameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
                break;
            case "sopra":
                spriteRend.flipX = false;
                attackGameObject.transform.rotation = Quaternion.Euler(0, 0, 90);
                break;
            case "sotto":
                spriteRend.flipX = false;
                attackGameObject.transform.rotation = Quaternion.Euler(0, 0, -90);
                break;
        }
    }
}
