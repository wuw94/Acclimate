using UnityEngine;
using System.Collections;

public class Controllable : Microbe
{
	private Vector2 diff;
	private float angle;
	
	void Start()
	{
		NewData();
	}
	
	void FixedUpdate()
	{
		base.FixedUpdate();
		if (Input.GetMouseButton(0))
		{
			UpdateRotation();
			UpdateVelocity();
		}
		else
		{
			SlowDown();
		}
		Debug.Log(GetComponent<Rigidbody2D>().velocity);
							
	}
	
	void UpdateRotation()
	{
		//Determine the difference between coordinates of mouse and this object's position
		diff = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y) -
							new Vector2(transform.position.x, transform.position.y);
		
		//Determine the resulting angle
		angle = Mathf.LerpAngle(angle, -Mathf.Atan2(diff.x,diff.y) * Mathf.Rad2Deg, Time.deltaTime * stat[Attribute.turn_rate]/5);
		transform.rotation = Quaternion.Euler(0,0,angle);
	}
	
	void UpdateVelocity()
	{
		//Determine Direction
		GetComponent<Rigidbody2D>().velocity = new Vector2(	Mathf.Cos((angle+90) * Mathf.Deg2Rad) * stat[Attribute.speed]/25,
			                                                     Mathf.Sin((angle+90) * Mathf.Deg2Rad) * stat[Attribute.speed]/25);
		
	}
	
	void SlowDown()
	{
		GetComponent<Rigidbody2D>().velocity = new Vector2(	Mathf.Lerp(GetComponent<Rigidbody2D>().velocity.x, 0, Time.deltaTime),
		                                                   Mathf.Lerp(GetComponent<Rigidbody2D>().velocity.y, 0, Time.deltaTime));
	}
}
