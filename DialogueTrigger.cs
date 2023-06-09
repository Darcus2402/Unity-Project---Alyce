using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DialogueTrigger : MonoBehaviour
{
    
    public Dialogue[] dialogue;
    public bool continuaDialogo = true;
    private GameObject Player;
    [SerializeField] private Animator animator;
    int numeroDialogo = 0;
    int quantitąDialoghi;

    private void Start() {
        Player = GameObject.Find("Player");
        //animator = GameObject.Find("Canvas").GetComponentInChildren<Animator>();
    }


    // vede se c'č altro dialogo, altrimenti chiude
    public void ContinuaDialogo() {
        if (quantitąDialoghi > numeroDialogo) {
            continuaDialogo = true;
            TriggerDialogue();
        } else {
            ChiudiDialogo();
        }
    }

    //prende quantitą di dialogo
    int getDialogueQuantity() {
        return dialogue.Length;
    }


    public void TriggerDialogue() {
        quantitąDialoghi = getDialogueQuantity();

        Debug.Log("Trigger dialogo");

        if (continuaDialogo) {

            continuaDialogo = false;
            FindObjectOfType<DialogueScript>().StartDialogue(dialogue[numeroDialogo]);
            numeroDialogo++;
        }
    }



    void ChiudiDialogo()
    {
        animator.SetTrigger("MenuExit");
        Player.GetComponent<PlayerMovement>().enabled = true;
        StartCoroutine(RobeDaFineDialogo());



    }

  IEnumerator RobeDaFineDialogo()
    {
        GameObject.Find("IntroOutroComp").GetComponent<Animator>().SetTrigger("outro");
        yield return new WaitForSeconds(2f);
        SceneManager.LoadSceneAsync(3);
    }
}
