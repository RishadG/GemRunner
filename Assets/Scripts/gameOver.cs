using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class gameOver : MonoBehaviour
{
    private GameMonitor gameMonitor;
    public GameObject levelCompletePanel, gameOverPanel;

    // Start is called before the first frame update
    public void endGame()
    {
        // go to the menu
        gameMonitor = FindObjectOfType<GameMonitor>();
        gameMonitor.goToMenu();

    }
    public void restartLevel()
    {
        gameMonitor = FindObjectOfType<GameMonitor>();
        gameMonitor.RestartLevel();
    }
    public void showGameOver()  
    {
        gameOverPanel.SetActive(true);
    }

    public void showLevelComplete()
    {
        levelCompletePanel.SetActive(true);
    }
    
}
