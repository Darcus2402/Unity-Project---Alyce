using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minigametomba : MonoBehaviour
{
    [SerializeField] GameObject Player;
    [SerializeField] GameObject Ghost;
    [SerializeField] GameObject ArrowSprite;
    [SerializeField] ProgressScript progressScript;
    private bool isPlayerNow;
    bool nuovoInput;
    int inputToProgress;
    int randomNumber;

    // Start is called before the first frame update
    void Start()
    {
        if (Player == null)
        {
            Player = GameObject.Find("Player");
        }

        if (Ghost == null)
        {
            Player = GameObject.Find("Ghost");
        }

        SetupArrow();
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(this.transform.position, Player.transform.position) < 2f)
        {
            ArrowSprite.SetActive(true);
            Minigame();
        }
        else
        {
            ArrowSprite.SetActive(false);
        }
    }


    void Minigame()
    {
        if (Input.anyKey && !Ghost.activeSelf )
        {
            int playerAction = TakeInput();
            CheckInput(playerAction);
        }
    }

    void SetupArrow()
    {
        randomNumber = Random.Range(0, 4);
        print(randomNumber);
        RotateArrow(randomNumber);

    }

    void RotateArrow(int rotationNumber)
    {
        switch (rotationNumber)
        {
            case 0:
                ArrowSprite.transform.rotation = Quaternion.Euler(0, 0, 0); //Sopra
                inputToProgress = 0;
                break;
            case 1:
                ArrowSprite.transform.rotation = Quaternion.Euler(0, 0, -90); //Destra
                inputToProgress = 1;
                break;
            case 2:
                ArrowSprite.transform.rotation = Quaternion.Euler(0, 0, -180); //Sotto
                inputToProgress = 2;
                break;
            case 3:
                ArrowSprite.transform.rotation = Quaternion.Euler(0, 0, 90); //sinistra
                inputToProgress = 3;
                break;

        }
    }

    int TakeInput()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            return 0;
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            return 1;
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            return 2;
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            return 3;
        }
        else
        {
            return 4;
        }
    }

    void CheckInput(int playerInput)
    {
        if (playerInput == inputToProgress)
        {
            progressScript._progresso += 1;
            SetupArrow();
        } 
        else if (playerInput == 4)
        {
            nuovoInput = false;
        }
    }
}

