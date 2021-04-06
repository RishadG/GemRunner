using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMonitor : MonoBehaviour
{
    private bool levelComplete = false;
    public GameObject player;
    private touchcontrols tc;
    public Animator animator;
    private gameOver GO;
    // Start is called before the first frame update


    void Awake()
    {
        tc = player.GetComponent<touchcontrols>();
        GO = GetComponent<gameOver>();
    }
    void Start()
    {
        // display a message to tap
        // actually do the tap
       

    }
    public void LevelComplete()
    {
        if(!levelComplete)
        {
            Debug.Log("showing panel");
            Rigidbody playerRB = player.GetComponent<Rigidbody>();
            tc.testMode = true;
            tc.stopMovement = true;
            playerRB.velocity = Vector3.zero;
            animator.SetTrigger("startDance");
            GO.Invoke("showLevelComplete",2f);
          //  tc.endLevel();
            levelComplete = true;
          //  levelCompletePanel.GetComponent<>
          // Invoke("loadNextScene", 2f);
        }

    }
    public  void loadNextScene()
    {
        Debug.Log("Loading next screen");
        Debug.Log(SceneManager.GetActiveScene().buildIndex);
        if (SceneManager.GetActiveScene().buildIndex == 2)
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
        Debug.Log("go to menu");
        SceneManager.LoadScene(0);

    }
    public void RestartLevel()
    {
        Debug.Log("Restart level");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
