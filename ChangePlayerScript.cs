
using UnityEngine;

public class ChangePlayerScript : MonoBehaviour
{
    [SerializeField] GameObject Player;
    [SerializeField] GameObject Ghost;
    [SerializeField] PlayerMovement playerMov;
    [SerializeField] private float speed;
    [SerializeField] private float maxDistanceBeforeReturningPlayer;
    [SerializeField] Camera cameraPiccina;
    [SerializeField] GameObject crosshair;
    [SerializeField] LineRenderer lineRend;

    private bool cameraFantasma = false;
    private bool staTornando = false;
    private float step;
    private float  staticStepVelocity;

    private void Start() {
        staticStepVelocity = step;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) {
            Debug.Log("Spazio premuto");
            changeGiocatore();
        }

        if (staTornando == true) {
            fantasmaTornante();
        }


        if (Ghost.activeSelf)
        {
            lineRend.positionCount = 2;
            DrawLineBetweenObjects();

            if(Vector2.Distance(Player.transform.position, Ghost.transform.position) > maxDistanceBeforeReturningPlayer)
            {
                RitornaFantasma();
            }
        }
    }

    private void changeGiocatore() {

        if (playerMov.isActiveAndEnabled == true) {
            AttivaFantasma();

            cameraFantasma = true;
            changeCamera(cameraFantasma);

        } else {
            RitornaFantasma();


        }
    }

    void AttivaFantasma() {
        step = staticStepVelocity;

        playerMov.enabled = false;
        Player.GetComponent<BoxCollider2D>().enabled = false; // disattiva collider
        Ghost.GetComponent<GhostMovement>().enabled = true;
        crosshair.SetActive(true);

        playerMov.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        Player.GetComponentInChildren<Animator>().SetBool("FrontMovement", false);
        Player.GetComponentInChildren<Animator>().SetBool("SideMovement", false);
        Player.GetComponentInChildren<Animator>().SetBool("BackMovement", false);

        Ghost.transform.position = Player.transform.position;
        Ghost.SetActive(true);
    }


    void RitornaFantasma() {
        staTornando = true;
    }

    void SpegniFantasma() {
        Ghost.SetActive(false);

        cameraFantasma = false;
        changeCamera(cameraFantasma);
        playerMov.enabled = true;
        crosshair.SetActive(false);
        Player.GetComponent<BoxCollider2D>().enabled = true; // attiva collider
    }


    void fantasmaTornante() {
        Ghost.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        Ghost.GetComponent<GhostMovement>().enabled = false;

        // velocità progressima
        //step += speed * Time.deltaTime;
        step += Time.deltaTime;
        Ghost.transform.position = Vector2.MoveTowards(Ghost.transform.position, Player.transform.position, step);

        if (Vector2.Distance(Ghost.transform.position, Player.transform.position) < 1.5f) {
            SpegniFantasma();
            staTornando = false;
        }
    }

    void changeCamera(bool cameraDelFantasma) {
        if (cameraDelFantasma) {
            cameraPiccina.transform.parent = null;
            cameraPiccina.transform.parent = Ghost.transform;
            cameraPiccina.transform.position = new Vector3(Ghost.transform.position.x, Ghost.transform.position.y, -10f);
            
        } else {
            cameraPiccina.transform.parent = null;
            cameraPiccina.transform.parent = Player.transform;
            cameraPiccina.transform.position = new Vector3(Player.transform.position.x, Player.transform.position.y, -10f);
        }
    }

    void DrawLineBetweenObjects()
    {
        lineRend.SetPosition(0, Player.transform.position);
        lineRend.SetPosition(1, Ghost.transform.position);
    }
}
