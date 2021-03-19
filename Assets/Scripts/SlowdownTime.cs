using UnityEngine;

public class SlowdownTime : MonoBehaviour
{
    // Start is called before the first frame update
    public float slowdownFactor = 0.05f;
    public float slowdownLength = 3f;
    public bool isSlowmo = false;
    private CameraFollow camera;

    // Update is called once per frame
    private void Awake()
    {
         camera = FindObjectOfType<CameraFollow>();
    }
    void Update()
    {
        Time.timeScale += (1f / slowdownLength) * Time.unscaledDeltaTime;
        Time.timeScale = Mathf.Clamp(Time.timeScale, 0f, 1f);
        if (Time.timeScale == 1)
        {
            isSlowmo = false;
        }
        if (isSlowmo)
        {
            camera.moveCameraToPlayer();
        }
        else
        {
            camera.normalCam();
        }

    }

    public void doSlowMotion()
    {
        Time.timeScale = slowdownFactor;
        Time.fixedDeltaTime = Time.timeScale * 0.02f;
        isSlowmo = true;
    }
}
