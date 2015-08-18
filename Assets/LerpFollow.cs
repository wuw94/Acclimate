using UnityEngine;
using System.Collections;

public class LerpFollow : MonoBehaviour
{
	public GameObject follow;
	
	void FixedUpdate()
	{
		transform.position = new Vector3(Mathf.Lerp(transform.position.x, follow.transform.position.x, Time.deltaTime*5),
										Mathf.Lerp(transform.position.y, follow.transform.position.y, Time.deltaTime*5),
										transform.position.z);
	}
}
