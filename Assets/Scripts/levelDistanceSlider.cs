using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class levelDistanceSlider : MonoBehaviour
{
    private Slider slider;
    public GameObject Player, endLevel;
    private float totalDistance, currentDistance, distancePercent, playerDistance;
    // Start is called before the first frame update
    void Start()
    {
        // get the distance to the end game
        slider = GetComponent<Slider>();
        totalDistance = Vector3.Distance(endLevel.transform.position, Player.transform.position)    ;
        playerDistance = totalDistance;
       // Debug.Log("distance to end = " + totalDistance);
       // slider.maxValue = totalDistance;

    }

    // Update is called once per frame
    void Update()
    {
        updateSlider();
    }

    private void updateSlider()
    {
        // get the current distance
        currentDistance = Vector3.Distance(endLevel.transform.position, Player.transform.position);
        distancePercent = currentDistance / totalDistance;
      //  Debug.Log("currentDistance :" + currentDistance + "totalDistance : " + totalDistance);
        if (slider.value < 1 - distancePercent)
        {
            slider.value = 1 - distancePercent;
        }
        
    }
}
