using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManagerScript : MonoBehaviour
{
    private bool scenaPronta;
    private bool caricoUno;
    // Start is called before the first frame update
    void Start()
    {
        scenaPronta = false;
        caricoUno = false;
      
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Play() {
        if (!caricoUno) {
            StartCoroutine(CaricaSceneAsync());
            caricoUno = true;
        }
    }

    IEnumerator CaricaSceneAsync() {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(2);
        asyncLoad.allowSceneActivation = false;

        while (!asyncLoad.isDone) { // finchè la scena non è caricata
            yield return null; 

            if(asyncLoad.progress >= 0.9f) {

                if (!scenaPronta) {
                    print("Scena pronta");
                    scenaPronta = true;
                }
                if (scenaPronta) {
                    asyncLoad.allowSceneActivation = true;
                }
            }
        }
    }

    public void ExitFromGame()
    {
        Application.Quit();
    }
}
