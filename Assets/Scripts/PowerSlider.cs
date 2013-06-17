using UnityEngine;
using System.Collections;

public class PowerSlider : MonoBehaviour
{
    public bool canDrag = false,
                canAim = true,
                canShoot = false;

    private float initPosition;

    public float maxPower = 100.0f,
                 shotForce = 0.0f,
                 lowestDragDist = 10.0f;

    public int powerMultiplier = 4;

    public static PowerSlider instance;

    void Awake()
    {
        instance = this;
    }

	// Use this for initialization
	void Start ()
    {
        initPosition = transform.position.z;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (!canDrag)
        {
            //return to the original position when mouse up for effect.
            float backToInitPos = Mathf.Lerp(transform.position.z, initPosition, 20.0f * Time.deltaTime);
            transform.position = new Vector3(transform.position.x, transform.position.y, backToInitPos);
        }
	}

    void OnMouseDrag()
    {
        canDrag = true;

        //create the plane at the camera's forward direction and the position of the power slider object
        Plane plane = new Plane(Camera.main.transform.forward, transform.position);

        float distance = 0.0f;

        Vector3 mousePos = Input.mousePosition;

        //find the x and y position of the mouse
        Vector3 screenPoint = new Vector3(mousePos.x, mousePos.y, 0);
        
        //get a ray through the screen space with the x and y of the mouse position
        Ray camRay = Camera.main.ScreenPointToRay(screenPoint);

        //create the raycast through the plane.
        if (plane.Raycast(camRay, out distance))
        {
            //find the position of the ray's origin plus the direction of the ray.
            //wherever the ray is the variable pos holds it
            Vector3 pos = camRay.origin + camRay.direction * distance;
            //interpolate from the Y of the object to wherever the mouse ray is.
            float moveWithMouse = Mathf.Lerp(transform.position.z, pos.z, 20.0f * Time.deltaTime);
            moveWithMouse = Mathf.Clamp(moveWithMouse, lowestDragDist, initPosition);

            //then apply the position to those values.
            transform.position = new Vector3(transform.position.x, transform.position.y, moveWithMouse);

            //the shotForce will be applied according to how far the player drags the power slider.
            shotForce = -transform.position.z * powerMultiplier;

            //give the shotforce a maximum power
            //shotForce = Mathf.Clamp(shotForce, 0.0f, maxPower);
        }
    }

    void OnMouseUp()
    {
        canDrag = false;
        canShoot = true;

        //TEMPORARILY PLACED
        canAim = true;
    }

    void OnMouseOver()
    {
        if (Input.GetMouseButton(0))
        {
            canAim = false;
        }
    }
}
