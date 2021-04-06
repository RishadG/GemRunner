using UnityEngine;

public class jumpPad : MonoBehaviour
{
    // Start is called before the first frame update
    public float jumpForce = 250f;
    private SlowdownTime slowdownTime;
    void Awake()
    {
        //slowdownTime = GetComponent<SlowdownTime>();
        if(PlayerPrefs.HasKey("JumpPower"))
        {
            jumpForce = PlayerPrefs.GetFloat("JumpPower");
        }
    }
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Player")
        {
            //if its the player, then pick up the obsticle
            
            GameObject player = collider.gameObject;
            touchcontrols tc = player.GetComponent<touchcontrols>();
            tc.animator.SetBool("isJumping", true);
            player.GetComponent<Rigidbody>().AddForce(0, jumpForce * Time.deltaTime, 0, ForceMode.Impulse);
            //slowdownTime.doSlowMotion();
            
        }
    }

  
}
