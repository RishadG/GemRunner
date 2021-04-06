using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallRun : MonoBehaviour
{
    public LayerMask whatIsWall;
    public float wallRunForce, maxWallRunTime, maxWallSpeed;
    bool isWallRunRight, isWallRunLeft;
    public bool iswallRunning;
    public float maxCameraTilt, wallRunCameraTilt;
    public Rigidbody rb;
    public GameObject orientation;
    public GameObject playerRotate;
    Animator animator;
    public GlueMechanics glueMechanics;
    private int wallrunDirection = 0;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        glueMechanics = GetComponent<GlueMechanics>();
    }
    private void Update()
    {
        checkForWall();
        WallRunInput();
     
    }
    // Start is called before the first frame update
    private void WallRunInput()
    {
        if (isWallRunRight && !iswallRunning && rb.velocity.y <= 0 )
        {
            wallrunDirection = -1;
            StartWallRun();
        }
        if(isWallRunLeft && !iswallRunning && rb.velocity.y <= 0)
        {
            wallrunDirection = 1;
            StartWallRun();
        }
    }
    private void StartWallRun()
    {
        Debug.Log("Wall Run Start");
        rb.useGravity = false;
        iswallRunning = true;
        animator.SetBool("isJumping", false);
        if (isWallRunLeft)
        {
         //   rb.AddForce(-transform.right * wallRunForce / 5 * Time.deltaTime);
           playerRotate.transform.localRotation = Quaternion.Euler(0, -90f, -45f);
        }
        else
        {
          //  rb.AddForce(transform.right * wallRunForce / 5 * Time.deltaTime);
            playerRotate.transform.localRotation = Quaternion.Euler(0, -90f, 45f);
        }
        rb.velocity = Vector3.up * 0;
    }
    public void StopWallRun()
    {
        rb.useGravity = true;
        iswallRunning = false;
        Debug.Log("stopped wall run");
       // animator.SetBool("isWallRunning", false);
        animator.SetBool("isJumping", true);
        rb.GetComponent<Rigidbody>().AddForce(0, 250f * Time.deltaTime, 0 , ForceMode.Impulse);
        playerRotate.transform.localRotation = Quaternion.Euler(0, -90f, 0f);

    }
    private void checkForWall()
    {
        isWallRunRight = Physics.Raycast(orientation.transform.position, new Vector3(0,0,90), 1.8f, whatIsWall);
        isWallRunLeft= Physics.Raycast(orientation.transform.position, new Vector3(0, 0, -90), 1.8f, whatIsWall);
        if(!isWallRunLeft && !isWallRunRight && iswallRunning)
        {
            StopWallRun();
        }

    }

    

}
