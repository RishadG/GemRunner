using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float smoothSpeed = 0.125f;
    public Vector3 offset;
    public Vector3 slowDownOffset;
    // Start is called before the first frame update
    
    // Update is called once per frame
    public void LateUpdate()
    {
        normalCam();
    }

    public void moveCameraToPlayer()
    {
        Vector3 desiredPosition = new Vector3(target.position.x + slowDownOffset.x, transform.position.y + slowDownOffset.y, transform.position.z  +slowDownOffset.z);
        Vector3 SmoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
        transform.position = SmoothedPosition;

    }
    public void normalCam()
    {
        Vector3 desiredPosition = new Vector3(target.position.x + offset.x, transform.position.y, transform.position.z);
        Vector3 SmoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
        transform.position = SmoothedPosition;
    }
}
