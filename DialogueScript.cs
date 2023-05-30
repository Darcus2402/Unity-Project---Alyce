using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueScript : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI nomePersonaggio;
    [SerializeField] private TextMeshProUGUI dialogueText;
    [SerializeField] GameObject dialogoTrigger;
    DialogueTrigger dialogoTriggeroso;

    private Queue<string> frasi;
    // Start is called before the first frame update

    private void Awake() {
        dialogoTrigger.TryGetComponent<DialogueTrigger>(out dialogoTriggeroso);
    }


    void Start()
    {
        frasi = new Queue<string>(); // instanziamo la Queue
    }


    public void StartDialogue(Dialogue dialogue) {
        nomePersonaggio.text = dialogue.nomePG;
        frasi.Clear();

        foreach(string frase in dialogue.sentences) {
            frasi.Enqueue(frase);

        }

        DisplayNextSentence();
    }


    public void DisplayNextSentence() {
        if (frasi.Count == 0) {
            EndDialogue();
            return;
        }

        Debug.Log("DisplayNextSentence");
        string sentence = frasi.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }


    IEnumerator TypeSentence (string sentence) {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray()) {
            dialogueText.text += letter;
            yield return new WaitForSeconds(0.035f);
            yield return null;
        }
    }


    void EndDialogue() {
        dialogoTriggeroso.ContinuaDialogo();
    }
}
