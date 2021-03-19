using UnityEngine;

public class levelComplete : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Player")
        {
            FindObjectOfType<GameMonitor>().LevelComplete();
            Debug.Log("level complete");
        }
            
    }
}
