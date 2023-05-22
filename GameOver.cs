using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameOver : MonoBehaviour
{
    private PlayerMovement playerControllerScript;
    public Text gameOverText;

    void Start()
    {
        playerControllerScript =
        GameObject.Find("Player").GetComponent<PlayerMovement>();
        gameOverText.enabled = false;

    }
    void Update()
    {
        if (playerControllerScript.gameOver == true)
        {
            Time.timeScale = 0f;
            gameOverText.enabled = true;

        }
    }


}

