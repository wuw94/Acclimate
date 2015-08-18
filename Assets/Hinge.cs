using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Hinge : MonoBehaviour
{
	private Vector2 diff;
	private float angle;
	
	void FixedUpdate()
	{
		UpdateRotation();
		UpdateVelocity();
		SlowDown();
	}
	
	void UpdateRotation()
	{
		//Determine the difference between coordinates of mouse and this object's position
		diff = new Vector2(	GetComponent<SpringJoint2D>().connectedBody.transform.position.x - transform.position.x,
	                   		GetComponent<SpringJoint2D>().connectedBody.transform.position.y - transform.position.y);
		
		//Determine the resulting angle
		angle = -Mathf.Atan2(diff.x,diff.y) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.Euler(0,0,angle);
	}
	
	void UpdateVelocity()
	{
		//Determine Direction
		if (true)
		{
			GetComponent<Rigidbody2D>().velocity = new Vector2(	Mathf.Cos((angle+90) * Mathf.Deg2Rad) * 5,
																Mathf.Sin((angle+90) * Mathf.Deg2Rad) * 5);
		}
	}
	
	void SlowDown()
	{
		GetComponent<Rigidbody2D>().velocity = new Vector2(	Mathf.Lerp(GetComponent<Rigidbody2D>().velocity.x, 0, Time.deltaTime),
		                                                   Mathf.Lerp(GetComponent<Rigidbody2D>().velocity.y, 0, Time.deltaTime));
	}
}
