using UnityEngine;
using System.Collections;

public class PlayerAim : MonoBehaviour
{
    public GameObject playerDisc;

	// Use this for initialization
	void Start ()
    {
	    
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (PowerSlider.instance.canAim)
        {
            if (Input.GetMouseButton(0))
            {
                Aim();
            }
        }

        if (PowerSlider.instance.canShoot)
        {
            //when the power slider has been released launch the disc
            if (PowerSlider.instance.shotForce > 0)
            {
                LaunchDisc();
            }
  
            PowerSlider.instance.canShoot = false;
        }
	}

    void LaunchDisc()
    {
        Instantiate(playerDisc, transform.position, transform.rotation);
    }

    void Aim()
    {
        Vector3 mousePos = Input.mousePosition;

        Ray mouseRay = Camera.main.ScreenPointToRay(mousePos);

        Plane plane = new Plane(Vector3.up, transform.position);

        float hitDist = 0.0f;

        if (plane.Raycast(mouseRay, out hitDist))
        {
            Vector3 mousePoint = mouseRay.GetPoint(hitDist);

            //rotate towards mouse.
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(mousePoint - transform.position), 30);
            //only rotate on the Y
            transform.rotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y, 0);
        }
    }
}
