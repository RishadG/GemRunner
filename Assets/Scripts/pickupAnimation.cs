using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class pickupAnimation : MonoBehaviour
{
    public Animator animator;
    public TextMeshProUGUI scoreText;
    private int newScore = 0;
    // Start is called before the first frame update
    public void setnewScore(int score)
    {
        this.newScore = score;
    }
    public int getNewScore()
    {
        return this.newScore;
    }

    void Awake()
    {
        animator = this.GetComponent<Animator>();
    }
    public void UpdateScore()
    {
        newScore = int.Parse(scoreText.text) + 1;
       // Debug.Log("increment score:" + newScore);
        scoreText.text = newScore.ToString();
        //animator.enabled = false;
    }

    public void startAnimation()
    {
        //Debug.Log("called start animation");
        UpdateScore();
        animator.SetTrigger("incrementScore");
        //animator.Play(0);
    }
    public void disableGemCountAnimation()
    {
       // animator.enabled = false;
    }

}
