using UnityEngine;

public class Swipe : MonoBehaviour
{
    // Start is called before the first frame update
    private bool tap, swipeLeft, swipeRight, swipeUp, swipeDown;
    private Vector2 startTouch, swipeDelta;
    private bool isDragging = false;

    public Vector2 SwipeDelta { get { return swipeDelta; } }
    public bool SwipeLeft { get { return swipeLeft; } }
    public bool SwipeRight { get { return swipeRight; } }
    public bool SwipeUp { get { return swipeUp; } }
    public bool SwipeDown { get { return swipeDown; } }
    public bool Tap { get { return tap; } }


    // Update is called once per frame
    private void Update()
    {
        tap = swipeUp = swipeDown = swipeLeft = swipeRight = false;
        #region Standalone Inputs
        if (Input.GetMouseButtonDown(0))
        {
            tap = true;
            startTouch = Input.mousePosition;
            isDragging = true;
        }
        else if(Input.GetMouseButtonUp(0))
        {
            isDragging = false;
            Reset();
        }
        #endregion
        #region Mobile Inputs
        if(Input.touches.Length > 0)
        {
            if (Input.touches[0].phase == TouchPhase.Began)
            {
                tap = true;
                startTouch = Input.touches[0].position;
                isDragging = true;
            }
            else if (Input.touches[0].phase == TouchPhase.Ended || Input.touches[0].phase == TouchPhase.Canceled)
            {
                isDragging = false;
                Reset();
            }

        }
        #endregion

        // calculate the distance
        swipeDelta = Vector2.zero;
        if (isDragging)
        { 
            if(Input.touches.Length > 0)
            {
                swipeDelta = Input.touches[0].position - startTouch;
            }
            else if(Input.GetMouseButton(0))
            {
                swipeDelta = (Vector2)Input.mousePosition - startTouch;
            }
        }
        if (swipeDelta.magnitude > 0)
        {
            //Debug.Log("swipeMag: " + swipeDelta.magnitude);
        }
        if(swipeDelta.magnitude > 20)
        {
            float x = swipeDelta.x;
            float y = swipeDelta.y;
            if (Mathf.Abs(x) > Mathf.Abs(y))
            {
                // left or right
                if (x < 0)
                {
                    swipeLeft = true;
                }
                else
                {
                    swipeRight = true;
                }
            }
            else 
            {
                // up or down
                if (y < 0)
                {
                    swipeDown = true;
                }
                else
                {
                    swipeUp  = true;
                }
            }
            Reset();
        }

    }
    private void Reset()
    {
        isDragging = false;
        startTouch = Vector2.zero;
    }
}
