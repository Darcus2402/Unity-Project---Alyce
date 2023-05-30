using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ProgressScript : MonoBehaviour
{
    [SerializeField] Image image;
    [SerializeField] Animator animator;

    public float _progresso;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Progresso();
    }

    void Progresso() {
        image.fillAmount = _progresso / 100;

        if(_progresso == 100f)
        {
            animator.SetTrigger("outro");
            StartCoroutine(EndGame());
        }
    }


    void CambiaScena()
    {
        SceneManager.LoadSceneAsync(3);
    }


    IEnumerator  EndGame()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadSceneAsync(0);
    }
}
