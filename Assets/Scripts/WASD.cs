using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WASD : MonoBehaviour // Controls movement, health, and collision with enemies
{
	public float speed = 0.025f;
	public int health = 3;
	public float invulnerability = 2;
	float invulnTime = 0;
	
	float xBorder;
	float yBorder;
	
	public Text healthText;
	
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
	
    void Start()
    {
        xBorder = (Screen.width-transform.localScale.x/2)/200;
		yBorder = (Screen.height-transform.localScale.y/2)/200;
		print("x = " + xBorder);
		print("y = " + yBorder);
		startPosition = transform.position;
		healthText.text = "Health: " + health;
    }

    void Update()
    {
		{// Movement
			{// Input
				Vector3 newPosition = transform.position;
				if (Input.GetKey(upKey) || Input.GetKey(upKeyAlt)) // Up
				{
					if (Input.GetKey(leftKey) || Input.GetKey(leftKeyAlt)) // Up Left
					{
						newPosition.x-=speed/1.5f;
						newPosition.y+=speed/1.5f;
						transform.position = newPosition;
					}
					else if (Input.GetKey(rightKey) || Input.GetKey(rightKeyAlt)) // Up Right
					{
						newPosition.x+=speed/1.5f;
						newPosition.y+=speed/1.5f;
						transform.position = newPosition;
					}
					else
					{
						newPosition.y+=speed;
						transform.position = newPosition;
					}
				}
				
				if (Input.GetKey(downKey) || Input.GetKey(downKeyAlt)) // Down
				{
					if (Input.GetKey(leftKey) || Input.GetKey(leftKeyAlt)) // Down Left
					{
						newPosition.x-=speed/1.5f;
						newPosition.y-=speed/1.5f;
						transform.position = newPosition;
					}
					else if (Input.GetKey(rightKey) || Input.GetKey(rightKeyAlt)) // Down Right
					{
						newPosition.x+=speed/1.5f;
						newPosition.y-=speed/1.5f;
						transform.position = newPosition;
					}
					else
					{
						newPosition.y-=speed;
						transform.position = newPosition;
					}
				}
				
				if ((Input.GetKey(leftKey) || Input.GetKey(leftKeyAlt)) && !(Input.GetKey(upKey) || Input.GetKey(upKeyAlt) || Input.GetKey(downKey) || Input.GetKey(downKeyAlt))) // Left
				{
					newPosition.x-=speed;
					transform.position = newPosition;
				}
				
				if ((Input.GetKey(rightKey) || Input.GetKey(rightKeyAlt)) && !(Input.GetKey(upKey) || Input.GetKey(upKeyAlt) || Input.GetKey(downKey) || Input.GetKey(downKeyAlt))) // Right
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
		
		if (invulnTime > 0) // While invulnerable
		{
			invulnTime-=Time.deltaTime;
			gameObject.GetComponent<SpriteRenderer>().color = new Color(.5f,.5f,1f,.5f);
			if (invulnTime <= 0) // End invulnerability
			{
				gameObject.GetComponent<SpriteRenderer>().color = new Color(1f,1f,1f,1f);
			}
		}
    }
	
	void OnCollisionEnter2D(Collision2D collision)
	{
		if((collision.collider.CompareTag ("Enemy")) && (invulnTime <=0) ) // On touch enemy
				{
					invulnTime = invulnerability; // Invulnerable
					health-=1; // Hurt
					if (health <= 0) // Die if no health
					{
						SceneManager.LoadScene("EndScene");
					}
					transform.position = startPosition; // Return to origin
					healthText.text = "Health: " + health; // Show new health
				}
	}
}
