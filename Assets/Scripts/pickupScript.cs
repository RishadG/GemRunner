using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
 using TMPro;

public class pickupScript : MonoBehaviour
{
    public GameObject pickupEffect;
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


        pickupParticles.Play();
       // GetComponent<ParticleSystem>().Play();
        ParticleSystem.EmissionModule em = pickupParticles.emission;
        em.enabled = true;
        AudioSource al = GetComponent<AudioSource>();
        al.Play();
        // play the score animation
        GetComponent<MeshRenderer>().enabled = false;
        pickupAnimation pa = FindObjectOfType<pickupAnimation>();
        pa.startAnimation();
        //Instantiate(pickupEffect, transform.position, transform.rotation);
        //incrementScore(1);
        // Destroy(gameObject);
    }
  
}
