using UnityEngine;

public class jumpPad : MonoBehaviour
{
    // Start is called before the first frame update
    public float jumpForce = 300f;
    bool isSlowMo = false;
    private SlowdownTime slowdownTime;
    void Awake()
    {
        slowdownTime = GetComponent<SlowdownTime>();
    }
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Player")
        {
            //if its the player
            
            GameObject player = collider.gameObject;
            playerMovement pm = player.GetComponent<playerMovement>();
            player.GetComponent<Rigidbody>().AddForce(0, jumpForce * Time.deltaTime, 0, ForceMode.Impulse);
            pm.animator.SetBool("isJumping", true);
            pm.isGrounded = false;
            pm.isJumping = false;
            slowdownTime.doSlowMotion();
            
        }
    }

  
}
