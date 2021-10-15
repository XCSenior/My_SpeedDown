using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour 
{
	Vector3 movement;
	GameObject topLine;
	public float speed;

	void Start () 
	{
		movement.y = speed;
		topLine = GameObject.Find("TopLine");
	}
	
	void Update () 
	{
		MovePlatform();
	}

	void MovePlatform()			//向上移动各个平台
    {
		transform.position += movement * Time.deltaTime;

        if (transform.position.y >= topLine.transform.position.y)		//若平台过界
        {
			Destroy(gameObject);
		}
    }
}
