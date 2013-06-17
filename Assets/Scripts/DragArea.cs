using UnityEngine;
using System.Collections;

public class DragArea : MonoBehaviour
{
	// Use this for initialization
	void Start ()
    {
	    
	}
	
	// Update is called once per frame
	void Update ()
    {
	    
	}

    void OnMouseOver()
    {
        //disable aiming when mouse is down and over the drag area so to avoid undesired aiming.
        if (Input.GetMouseButton(0))
        {
            PowerSlider.instance.canAim = false;
        }
    }

    void OnMouseUp()
    {
        //if the mouse button is release allow aiming again.
        //THIS WILL BE DELETED WHEN THE GAME PROGRESSES TO USING ONE SHOT
        PowerSlider.instance.canAim = true;
    }
}
