using UnityEngine;
using UnityEngine.UI;

public class GlueMechanics : MonoBehaviour
{
    public ParticleSystem pickupParticles;
    private touchcontrols player;
    private GameObject bucket;
    public float glueAmount = 4;
    public float maxGlue = 10;
    public float addGlueAmount = 1f;
    public float removeGlueAmount = 0.5f;
    public Slider glueSlider;
    private WallRun wallRun;
    public float glueTimeout = 1f;
    private float currentTIme;
    // Start is called before the first frame update

    void Awake()
    {
        wallRun = GetComponent<WallRun>();
        currentTIme = 0;
    }

     void Update()
    {
        if(wallRun.iswallRunning)
        {
            // if the user is wallrunning
            //Debug.Log("DT" + Time.time );
            //Debug.Log("CT" + currentTIme);
            //Debug.Log(Time.time - currentTIme);
            if (Time.time - currentTIme > glueTimeout)
            {
                // if the timeout has been reached  
                //useGlue();
                Debug.Log("used glue");
                currentTIme = Time.time;
                //reduce the amount of glue
            }
        }
    }
    private void OnTriggerEnter(Collider collider)
    {

        if (collider.tag == "Paint")
        {
            bucket = collider.gameObject;
           // pickupParticles = bucket.GetComponent<ParticleSystem>();
            // add 1 to the store
            player = GetComponent<touchcontrols>();
            Pickup();

        }
    }
    private void Pickup()
    {
        Debug.Log("Called pickup script");

        //pickupParticles.Play();
        // GetComponent<ParticleSystem>().Play();
        //ParticleSystem.EmissionModule em = pickupParticles.emission;
        //em.enabled = true;
        //AudioSource al = GetComponent<AudioSource>();
        //al.Play();
        addGlue();
        bucket.SetActive(false);
        //bucket.GetComponent<MeshRenderer>().enabled = false;
        //Instantiate(pickupEffect, transform.position, transform.rotation);
        //incrementScore(1);
        // Destroy(gameObject);
    }
    private void addGlue()
    {
        if (glueAmount < maxGlue)
        { 
            glueAmount += addGlueAmount;
            // move the slider by glue amount  / 10
            glueSlider.value = glueAmount / 10f;
        }
    }
    private void useGlue()
    {
        if(glueAmount > removeGlueAmount)
        { 
           // glueAmount -= removeGlueAmount;
            // move the slider by glue amount  / 10
            glueSlider.value = glueAmount / 10f;
        }
        else
        {
           // wallRun.StopWallRun();
        }
    }

}
