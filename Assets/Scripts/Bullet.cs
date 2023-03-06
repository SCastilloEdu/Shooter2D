using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
	public float movementSpeed = 0.01f;
	float lifetime = 0.5f;
	
	float xBorder;
	float yBorder;
	
    // Start is called before the first frame update
    void Start()
    {
        xBorder = 9f-transform.localScale.x/2;
		yBorder = 5f-transform.localScale.y/2;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.up * Time.deltaTime * movementSpeed);
		if (transform.position.x >= xBorder || transform.position.x <= -xBorder || transform.position.y >= yBorder || transform.position.y <= -yBorder) // Cleans up bullets that leave the playing field
		{
			lifetime-=Time.deltaTime;
		}
		if (lifetime<=0)
		{
			Destroy(gameObject);
		}
    }
	
	void OnCollisionEnter2D(Collision2D collision)
	{
		if(collision.collider.CompareTag ("Enemy")) // On touch enemy
		{
			Destroy(gameObject); // Destroy bullet
		}
	}
}