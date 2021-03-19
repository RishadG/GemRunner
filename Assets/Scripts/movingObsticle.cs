using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movingObsticle : MonoBehaviour
{
    // Start is called before the first frame update

    // Update is called once per frame
    public float moveBy = 10f;
    Rigidbody rb;
    public  float movementStep  = 1.2f;
    public float whenPlayerClose = -10;
    GameObject playerOBJ;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        playerOBJ = GameObject.Find("Player");
    }
    void Start()
    {
       

    }
    void Update()
    {
        float diff = playerOBJ.transform.position.x - transform.position.x;
        //Debug.Log(playerOBJ.transform.position.x + "-" + transform.position.x + "= " + diff);
        if (diff < whenPlayerClose)
        {
            transform.position = Vector3.MoveTowards(transform.position,
                                                    new Vector3(transform.position.x, 
                                                    transform.position.y, moveBy), movementStep);
        }
    }
}
