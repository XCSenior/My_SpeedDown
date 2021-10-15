using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationBG : MonoBehaviour 
{
	Material material;
	Vector2 movement;

	public Vector2 speed;

	
	void Start () 
	{
		material = GetComponent<Renderer>().material;		//获取材质
	}
	
	
	void Update () 
	{
		movement += speed * Time.deltaTime;	//Speed * 0.02
		material.mainTextureOffset = movement;		//用movement控制贴图偏移值，达到移动贴图的效果
	}
}
