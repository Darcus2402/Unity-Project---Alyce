using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*          Per far funzionare lo script: Attacca questo alla tomba, e scrivi i testi.
 *          Crea poi un dialogue object con dialogue script e dialogue trigger.
 *          
 *          Collega textMesh con Name e Testo, e collega il trigger al dialogueScript
 * 
 */




public class TombInteract : MonoBehaviour
{
    
    [SerializeField] GameObject Player;
    [SerializeField] float interactableDistance = 1f;
    [SerializeField] DialogueTrigger dialogueTriggerObject;
    [SerializeField] DialogueScript dialogueScriptObject;
    [SerializeField] Animator animator;
    [SerializeField] GameObject TextInteract;

    private bool discorsoIniziato;
    private bool puoiInteragire;
    // Start is called before the first frame update
    void Start()
    {
        discorsoIniziato = false;
        Player = GameObject.Find("Player");
        //animator = GameObject.Find("Canvas").GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //check puoi interagire
        if (!puoiInteragire && Vector2.Distance(this.transform.position, Player.transform.position) < interactableDistance) {
            puoiInteragire = true;
            Debug.Log("Puoi interagire");
            TextInteract.SetActive(true);
        }
        else if (Vector2.Distance(this.transform.position, Player.transform.position) >= interactableDistance) { 
            puoiInteragire = false;
            TextInteract.SetActive(false);
        }



        if (puoiInteragire) {
 
            if (Input.GetKeyDown(KeyCode.E) && !discorsoIniziato) {
                //Attiva animazione menu
                Player.GetComponent<PlayerMovement>().enabled = false;
                animator.SetTrigger("MenuEnter");
                dialogueTriggerObject.TriggerDialogue();
                discorsoIniziato = true;
                return;
            }
        }


        if (discorsoIniziato && Input.GetKeyDown(KeyCode.E)) {
                dialogueScriptObject.DisplayNextSentence();
                Debug.Log("Display next sentence chiamato");

        }
    }
}
