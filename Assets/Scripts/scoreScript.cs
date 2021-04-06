using UnityEngine;
using UnityEngine.UI;

public class scoreScript : MonoBehaviour
{
    public Text scoreText;
    string currentScore;
    public GameObject playerOBJ;
    // Start is called before the first frame update
    void Awake()
    {
     //   scoreText = GetComponent<Text>();
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        //string[] splitString = scoreText.text.Split(':');
        playerOBJ = GameObject.Find("Player");
        if(playerOBJ.transform.position.x < 0)
        { 
        float newScore = float.Parse(scoreText.text) + Mathf.Floor(playerOBJ.transform.position.x * -1);
        scoreText.text =  newScore  + "";
        }
        // Debug.Log("incremented score" + newScore);
    }
}
