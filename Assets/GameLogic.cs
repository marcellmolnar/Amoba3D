using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLogic : MonoBehaviour
{

    private static bool playersTurn;
    private static bool gameInProgress;

    // Start is called before the first frame update
    void Start()
    {
        playersTurn = true;
        gameInProgress = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void changePlayer()
    {
        playersTurn = !playersTurn;
        if (playersTurn)
        {
            //Debug.Log("player");
        }
        else
        {
            botLogic.step();
        }
    }

    public static void playerWon()
    {
        gameInProgress = false;
        Debug.Log("Player won");
    }

    public static void computerWon()
    {
        gameInProgress = false;
        Debug.Log("Computer won");
    }

    public static bool isPlayersTurn()
    {
        return playersTurn && gameInProgress;
    }

    public static bool isBotsTurn()
    {
        return !playersTurn && gameInProgress;
    }
}
