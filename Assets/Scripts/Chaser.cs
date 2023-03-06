using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chaser : MonoBehaviour // Enemy behaviors
{
	public float speed = 0.025f;
	public Transform targ;
	
	float xBorder;
	float yBorder;
	
    // Start is called before the first frame update
    void Start()
    {
        xBorder = (Screen.width-transform.localScale.x/2)/200;
		yBorder = (Screen.height-transform.localScale.y/2)/200;
    }

    // Update is called once per frame
    void Update()
    {
		{// Movement
			transform.position = Vector3.MoveTowards(transform.position, targ.transform.position, speed/10);
		}
		{// Screenwrap
				Vector3 newPosition = transform.position;
				float inbetween = 0.0000001f;
				if (transform.position.x >= xBorder+inbetween)
				{
					newPosition.x = -xBorder;
					transform.position = newPosition;
				}
				if (transform.position.x <= -xBorder-inbetween)
				{
					newPosition.x = xBorder;
					transform.position = newPosition;
				}
				if (transform.position.y >= yBorder+inbetween)
				{
					newPosition.y = -yBorder;
					transform.position = newPosition;
				}
				if (transform.position.y <= -yBorder-inbetween)
				{
					newPosition.y = yBorder;
					transform.position = newPosition;
				}
		}
		
		
    }
	void OnCollisionEnter2D(Collision2D collision)
	{
		if(collision.collider.CompareTag ("Bullet"))
		{
			Destroy(gameObject); // Destroy chaser
		}
	}
}
