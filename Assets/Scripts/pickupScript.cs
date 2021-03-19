using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class pickupScript : MonoBehaviour
{
    public GameObject pickupEffect;
    public Text Score;
    public ParticleSystem pickupParticles;
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider collider)
    {
        
        if (collider.tag == "Player")
        {
            // add 1 to the store
            Pickup();

        }
    }
    private void Pickup()
    {
        Debug.Log("Called pickup script");

        pickupParticles.Play();
       // GetComponent<ParticleSystem>().Play();
        ParticleSystem.EmissionModule em = pickupParticles.emission;
        em.enabled = true;
        AudioSource al = GetComponent<AudioSource>();
        al.Play();

        GetComponent<MeshRenderer>().enabled = false;
        //Instantiate(pickupEffect, transform.position, transform.rotation);
        //incrementScore(1);
       // Destroy(gameObject);
    }
    private void incrementScore(int incrementBy)
    {
        string[] splitString = Score.text.Split(':');
        int newScore = int.Parse(splitString[1]) + incrementBy;
        Score.text = "Score: " + newScore;

    }
}
