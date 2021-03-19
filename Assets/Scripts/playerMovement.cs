using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class playerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody rb;
    public float forwardForce = 500f;
    public float sidewaysForce = 200f;
    private int isMovingSide;
    public Animator animator;
    public bool isJumping = false;
    public bool isGrounded = true;
    public float jumpForce = 100f;
    public bool isSliding;
    private float slideTime;
    public float fallMultiplier = 2.5f;
    public Swipe swipeControls;
    public float MoveSideBy = 1f;
    public float moveToPosition = 0f;
    // Update is called once per frame
    public bool testMode = false;
    public AudioClip gettingHit, Jumping;
    AudioSource AS;
    public Text ClickToStart;

    private void Awake()
    {
         AS = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
        animator.enabled= false;
        this.testMode = true;
        
    }
    void Update()
    {
        // use to get input
        if (Input.GetKey("d"))
        {
            //   rb.AddForce(0, 0, sidewaysForce * Time.deltaTime, ForceMode.VelocityChange);
            isMovingSide = 1;
            if(moveToPosition < 2)
            moveToPosition += 2;
        }
        else if (Input.GetKey("a"))
        {
            //  rb.AddForce(0, 0, sidewaysForce * Time.deltaTime * -1, ForceMode.VelocityChange);
            isMovingSide = -1;
            if(moveToPosition > -2)
            moveToPosition -= 2;
        }
        else
        {
            isMovingSide = 0;
        }
        if (Input.GetKey("s") && !isSliding)
        {
            isSliding = true;
            slideTime = Time.time;
            animator.SetBool("isSliding", true);
        }
        if(swipeControls.SwipeLeft)
        {
            isMovingSide = -1;
            if (moveToPosition > -2)
                moveToPosition -= 2;
        }
        if (swipeControls.SwipeRight)
        {
            isMovingSide = 1;
            if (moveToPosition <2)
                moveToPosition += 2;
        }
        if(swipeControls.Tap)
        {
            // start gamed
            Debug.Log("Start game");
            ClickToStart.enabled = false;
            this.testMode = false;
            animator.enabled = true ;
        }

        transform.position = Vector3.MoveTowards(transform.position,
            new Vector3(transform.position.x,
                transform.position.y,
                moveToPosition), MoveSideBy);
        /*
transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x,
        transform.position.y,
        transform.position.z + (2f * isMovingSide)), 0.5f);
        */
        if ((Input.GetKey("w") && isGrounded) || (swipeControls.SwipeUp && isGrounded))
        {
            isJumping = true;
         //   Debug.Log("jump");
            
        }
    }
    void FixedUpdate()
    {
        if(isJumping)
        {
            AS.clip = Jumping;
            AS.loop = false;
            AS.Play();
            rb.AddForce(0, jumpForce * Time.deltaTime, 0, ForceMode.Impulse);
            animator.SetBool("isJumping", true);
            isGrounded = false;
            isJumping = false;
           
        }
        if (!testMode && rb.velocity.x > -15)
        {
            rb.AddForce(forwardForce * Time.deltaTime * -1, 0, 0);
          //  Debug.Log("playerSpeed = "  + rb.velocity.x);
        }
        
        //rb.AddForce(0, 0, sidewaysForce * Time.deltaTime * isMovingSide, ForceMode.Impulse);
        if (isMovingSide == 0)
        {
           /* Vector3 resultVelocity = rb.velocity;
            resultVelocity.z = 0;
            rb.velocity = resultVelocity;
            */
        }
      
        if (Time.time - slideTime > 1.2)
        {
            // play the animation
            //
            animator.SetBool("isSliding", false);
            isSliding = false;
        }
        if (rb.velocity.y < 0)
        {
            rb.velocity += Vector3.up * Physics.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }
        if (transform.position.y < -1)
        {
            animator.SetTrigger("isFalling");
            endLevel();

        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Floor")
        {
           // Debug.Log("on the ground");
            isGrounded = true;
            animator.SetBool("isJumping", false);
        }
        if (collision.collider.tag == "Obsticle")
        {
            Debug.Log("reset level");
            animator.SetTrigger("hasDied");
            AudioSource AS= GetComponent<AudioSource>();
            AS.clip = gettingHit;
            AS.loop = false;
            AS.Play();
            endLevel();

        }

    }

    private IEnumerator reloadLevel()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }
    private void endLevel()
    {
        StartCoroutine(reloadLevel());
        //Invoke("reloadLevel", 3f);
        Component.FindObjectOfType<scoreScript>().enabled = false;
        rb.velocity = rb.velocity.x * Vector3.zero;
        animator.enabled = false;
        this.enabled = false;
        // show the panel
        gameOver GO = FindObjectOfType<gameOver>();
        GO.showGameOver();

    }
}
