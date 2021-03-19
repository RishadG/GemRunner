using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slideScript : MonoBehaviour
{
    public float slideby = -2f;
    public float slideSpeed = 2f;
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider collider)
    {
        if(collider.tag == "Player")
        {
            //if its the player
            Transform playerTransform = collider.gameObject.transform;
            playerTransform.position = Vector3.MoveTowards(playerTransform.position,
           new Vector3(transform.position.x,
               transform.position.y,
               slideby), slideSpeed);
        }
    }

   
}
