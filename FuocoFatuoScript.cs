using UnityEngine;

public class FuocoFatuoScript : MonoBehaviour {
    [SerializeField] Camera mainCamera;
    [SerializeField] Rigidbody2D rb;
    [SerializeField] GameObject crossHair;

    private Vector2 mousePositionInWorld;


    void Start() {
        rb.GetComponent<Rigidbody2D>();
        mainCamera = Camera.main;

        if(mainCamera == null) {
            mainCamera = GameObject.Find("Camera").GetComponent<Camera>();
            Debug.Log("Camera Trovata");
        }
    }



    void Update() {
        mousePositionInWorld = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        crossHair.transform.position = mousePositionInWorld;
    }


    void FixedUpdate() {
        Vector2 lookDir = mousePositionInWorld - rb.position;
        //float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg + gradiExtra; // 90
        float angle = Vector2.SignedAngle(Vector2.up, lookDir);
        rb.rotation = angle  -6.5f;
        
    }


} 

