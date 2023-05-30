using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int Health;
    [SerializeField] private int InitialHealth;
    [SerializeField] TextMeshProUGUI textHP;
    [SerializeField] Animator animator;

    private bool playerAlive = true;
    // Start is called before the first frame update
    void Start()
    {
        Health = InitialHealth;
        textHP.text = "HP " + Health;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void PlayerTakeDamage(int damage)
    {
        Health -= damage;
        textHP.text = "HP " + Health;

        if (Health <= 0 && playerAlive) 
        {
            playerAlive = false;
            Debug.Log("Player morto");
            StartCoroutine(AnimatorAndChangeSceneCoroutine());
        }
    }

    IEnumerator AnimatorAndChangeSceneCoroutine()
    {
        animator.SetTrigger("outro");
        yield return new WaitForSeconds(2f);
        SceneManager.LoadSceneAsync(3);
    }
}
