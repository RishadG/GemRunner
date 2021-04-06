using UnityEngine;

public class SlowdownTime : MonoBehaviour
{
    // Start is called before the first frame update
    public float slowdownFactor = 0.01f;
    public float slowdownLength = 10f;
    public bool isSlowmo = false;

    // Update is called once per frame
    private void Awake()
    {
         //camera = FindObjectOfType<CameraFollow>();
    }
    void Update()
    {
        /*Time.timeScale += (1f / slowdownLength) * Time.unscaledDeltaTime;
        Time.timeScale = Mathf.Clamp(Time.timeScale, 0f, 1f);
        if (Time.timeScale == 1)
        {
            isSlowmo = false;
            camera.isSlowmo = isSlowmo;
        }
        if (isSlowmo)
        {
            camera.moveCameraToPlayer();
        }
        else
        {
            camera.normalCam();
        }
        */

    }

}
