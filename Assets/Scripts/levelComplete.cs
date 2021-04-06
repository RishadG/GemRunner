using UnityEngine;

public class levelComplete : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Player")
        {
            GameMonitor gm = FindObjectOfType<GameMonitor>();
            gm.LevelComplete();
            Debug.Log("level complete");
        }
            
    }
}
