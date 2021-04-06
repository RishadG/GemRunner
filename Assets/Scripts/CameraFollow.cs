using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float smoothSpeed = 0.125f;
    public Vector3 offset;
    private float posY = 4.6f, posZ = 0;
   // Start is called before the first frame update
    // Update is called once per frame
    public void LateUpdate()
    {
        normalCam();
    }

    private void Awake()
    {
        if(PlayerPrefs.HasKey("CameraX"))
        {
            offset.x = PlayerPrefs.GetFloat("CameraX");
        }
        if (PlayerPrefs.HasKey("CameraY"))
        {
            //move the camera to this
            posY = PlayerPrefs.GetFloat("CameraY");
        }
        if (PlayerPrefs.HasKey("CameraZ"))
        {
            //move the camera to this
            posZ = PlayerPrefs.GetFloat("CameraZ");
        }

    }

    public void normalCam()
    {
        //crosshair.SetActive(false);
        Vector3 desiredPosition = new Vector3(target.position.x + offset.x, posY, posZ);
        Vector3 SmoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
        transform.position = desiredPosition;
     //   transform.LookAt(target.position);
    }
    
}
