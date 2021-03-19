using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMonitor : MonoBehaviour
{
    public GameObject levelCompletePanel;
    private bool levelComplete = false;
    // Start is called before the first frame update

    void Start()
    {
        // display a message to tap
        // actually do the tap
       

    }
    public void LevelComplete()
    {
        if(!levelComplete)
        {
            levelCompletePanel.SetActive(true);
            Component.FindObjectOfType<scoreScript>().enabled = false;
          //  levelCompletePanel.GetComponent<>
//            Invoke("loadNextScene", 2f);
        }

    }
    public  void loadNextScene()
    {
        Debug.Log(SceneManager.GetActiveScene().buildIndex);
        if (SceneManager.GetActiveScene().buildIndex == 3)
        {
            SceneManager.LoadScene(0);
        }
        else
        { 
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
    public void goToMenu()
    {
        SceneManager.LoadScene(0);

    }
    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
