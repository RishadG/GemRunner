using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class touchcontrols : MonoBehaviour
{
    private Touch touch;
    public float speedModifier = 0.15f;
    private float zPos;
    public float p1leftBound = -4.2f;
    public float p1RightBound = -0.7f;
    public bool stopMovement = false;
    private Transform player1, player2;
    public GameObject GO1;
    public float movementStep = 0.1f;
    public float forwardMotion = 1f;
    public float forwardMotionSmooth = 0.125f;
    public Text ClickToStart;
    public Animator animator;
    public bool testMode = true;
    public float forwardForce = 800f;
    // Start is called before the first frame update
    private Rigidbody rb;
    public float fallMultiplier = 2.5f;
    public AudioClip gettingHit;
    public float maxVelocity = -15f;
    public Vector3 drawDistance;
    void Awake()
    {
        //animator.enabled = false;
        if (PlayerPrefs.HasKey("MaxSpeed"))
        {
            //move the camera to this
            maxVelocity = (PlayerPrefs.GetFloat("MaxSpeed") * -1);
        }
    }
    void Start()
    {
        player1 = GO1.transform;
       // animator.enabled = false;
        // animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }
    // Update is called once per frame
    void Update()
    {
        if (!stopMovement)
        {
            if (Input.touchCount > 0)
            {
                touch = Input.GetTouch(0);

                if (touch.phase == TouchPhase.Moved)
                {
                    // get the final z position
                    // min pos: 0.7
                    zPos = player1.position.z + (touch.deltaPosition.x * speedModifier);
                   // float temp = Camera.main.ScreenToWorldPoint(new Vector3(touch.deltaPosition.x, touch.deltaPosition.y, 0)).x;
                    //Debug.Log("temp:" + temp);
                   // zPos = player1.position.z + temp;
                    //zPos = player1.position.z + touch.deltaPosition.x * speedModifier;

                    //Debug.Log("deltaPos:" + touch.deltaPosition);
                    // check if the final positon is within bounds
                    if (zPos >= p1RightBound)
                    {
                        zPos = p1RightBound;
                    }
                    if (zPos <= p1leftBound)
                    {
                        zPos = p1leftBound;
                    }
                   

                    // Debug.Log("touch moved by " + touch.deltaPosition.x);
                }
                else
                {
                    ClickToStart.enabled = false;
                    this.testMode = false;
                    animator.enabled = true;
                    animator.SetBool("isRunning", true);
                }
            }
            //Vector3 forwardForce = new Vector3(forwardMotion, 0f, 0f);
            //RB1 = GO1.GetComponent<Rigidbody>();
            //RB2 = GO2.GetComponent<Rigidbody>();
            ////Debug.Log(RB1);
            //RB1.AddForce(forwardForce,ForceMode.VelocityChange);
            //RB2.AddForce(forwardForce, ForceMode.VelocityChange);
            
           
                
        }
    }
    void FixedUpdate()
    {
        // check if you can move forward, and ensure max speed is capped
        if (!testMode && rb.velocity.x > maxVelocity)
        {
            rb.AddForce(forwardForce * Time.deltaTime * -1, 0, 0);
             // Debug.Log("playerSpeed = "  + rb.velocity.x);
        }

        if (zPos <= p1RightBound && zPos >= p1leftBound)
        {
           // rb.MovePosition(transform.position + new Vector3(0, 0, zPos));
            // move the player
            player1.position = Vector3.MoveTowards(player1.position, new Vector3(
                player1.position.x,
                player1.position.y,
                zPos
                ), movementStep);
             
        }
        if (rb.velocity.y < 0)
        {
            rb.velocity += Vector3.up * Physics.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }
        //check if the player has fallen
        if (transform.position.y < 0)
        {
            endLevel();
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Floor" && animator.GetBool("isJumping"))
        {
            // Debug.Log("on the ground");
            //isGrounded = true;
            animator.SetBool("isJumping", false);
        }
        if (collision.collider.tag == "Obsticle")
        {
            animator.enabled = true;
            animator.SetTrigger("hasDied");
            Handheld.Vibrate();
            testMode = true;
            stopMovement = true;
            rb.velocity = Vector3.zero;
            Debug.Log("hasDied TC");
            AudioSource AS = GetComponent<AudioSource>();
            AS.enabled = true;
            AS.clip = gettingHit;
            AS.loop = false;
            AS.Play();
            Invoke("endLevel",2.0f);

        }

    }
    public void endLevel()
    {
        //StartCoroutine(reloadLevel());
        //Invoke("reloadLevel", 3f);
        //animator.enabled = false;
        FindObjectOfType<gameOver>().showGameOver();
        //this.enabled = false;
        // show the panel
    }

}
