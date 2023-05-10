using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiManager : MonoBehaviour
{
       [Header("Canvas")]
    public GameObject CanvasGame;
    public GameObject CanvasRestart;

     [Header("CanvasRestart")]
     public GameObject WinTxt;
    public GameObject LooseTxt;

        public ScoreScript scoreScript;
        public Puck puckScript;
        public Player playerMovement;
        public Ai aiScript;

public void ShowRestartCanvas(bool didAiWin)
    {
        Time.timeScale = 0;//freeze time

        CanvasGame.SetActive(false);
        CanvasRestart.SetActive(true);

        if (didAiWin)
        {
            
            WinTxt.SetActive(false);
            LooseTxt.SetActive(true);
        }
        else
        {
           
            WinTxt.SetActive(true);
            LooseTxt.SetActive(false);
        }
    }
public void RestartGame()
    {
        Time.timeScale = 1;//make game run normally again

        CanvasGame.SetActive(true);
        CanvasRestart.SetActive(false);

        scoreScript.ResetScores();
        puckScript.CenterPuck();
        playerMovement.ResetPosition();
        aiScript.ResetPosition();
    }

}
