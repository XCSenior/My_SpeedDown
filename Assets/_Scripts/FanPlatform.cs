using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FanPlatform : MonoBehaviour 
{
	Animator animator;


	void Start () 
	{
		animator = GetComponent<Animator>();
	}
	
	void OnCollisionEnter2D(Collision2D other)
    {
		if (other.gameObject.CompareTag("Player"))		//当与标签为Player的物体碰撞时，播放动画
        {
			animator.Play("Fan_run");
        }
    }
}
