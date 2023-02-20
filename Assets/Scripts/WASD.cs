using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WASD : MonoBehaviour
{
	public float speed = 0.025f;
	
	float xBorder;
	float yBorder;
	
	Vector3 startPosition;
	// Movement keys
	public KeyCode upKey = KeyCode.W;
	public KeyCode downKey = KeyCode.S;
	public KeyCode leftKey = KeyCode.A;
	public KeyCode rightKey = KeyCode.D;
	public KeyCode upKeyAlt = KeyCode.UpArrow;
	public KeyCode downKeyAlt = KeyCode.DownArrow;
	public KeyCode leftKeyAlt = KeyCode.LeftArrow;
	public KeyCode rightKeyAlt = KeyCode.RightArrow;
	
    // Start is called before the first frame update
    void Start()
    {
        xBorder = (Screen.width-transform.localScale.x/2)/200;
		yBorder = (Screen.height-transform.localScale.y/2)/200;
		print("x = " + xBorder);
		print("y = " + yBorder);
		startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
		{// Movement
			{// Input
				Vector3 newPosition = transform.position;
				if (Input.GetKey(upKey) || Input.GetKey(upKeyAlt))
				{
					newPosition.y+=speed;
					transform.position = newPosition;
				}
				if (Input.GetKey(downKey) || Input.GetKey(downKeyAlt))
				{
					newPosition.y-=speed;
					transform.position = newPosition;
				}
				if (Input.GetKey(leftKey) || Input.GetKey(leftKeyAlt))
				{
					newPosition.x-=speed;
					transform.position = newPosition;
				}
				if (Input.GetKey(rightKey) || Input.GetKey(rightKeyAlt))
				{
					newPosition.x+=speed;
					transform.position = newPosition;
				}
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
		
    }
	void OnCollisionEnter2D(Collision2D collision)
	{
		if(collision.collider.CompareTag ("Object"))
				{
					transform.position = startPosition;
				}
	}
}
