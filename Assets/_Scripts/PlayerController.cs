using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour 
{
	Rigidbody2D rb;
	Animator anim;

	public float speed;
	float xVelocity;        //x轴移动值


	public float checkRadius;
	public LayerMask platform;
	public GameObject groundCheck;
	public bool isOnGround;     //判断是否在平台上，不在则播放fall动画

	bool playerDead;		//检测游戏角色是否死亡




	void Start () 
	{
		rb = GetComponent<Rigidbody2D>();		//获取角色
		anim = GetComponent<Animator>();		//获取动画
	}
	
	void Update () 
	{	
		//检测是否有接触平台
		isOnGround = Physics2D.OverlapCircle(groundCheck.transform.position,checkRadius,platform);

		anim.SetBool("isOnground", isOnGround);

		Movement();
	}

	void Movement()
    {
		xVelocity = Input.GetAxisRaw("Horizontal");		//返回-1、0、1，即左右的移动方向

		rb.velocity = new Vector2(xVelocity * speed, rb.velocity.y);    //移动角色


		anim.SetFloat("speed",Mathf.Abs(rb.velocity.x));		//给Animator中的speed赋值，可切换跑动动画

		if(xVelocity!=0)
        {
			transform.localScale = new Vector3(xVelocity, 1, 1);        //改变角色左右朝向
		}
    }

    private void OnCollisionEnter2D(Collision2D other)		//检测与Fan的碰撞
    {
        if (other.gameObject.CompareTag("Fan"))
        {
			rb.velocity = new Vector2(rb.velocity.x, 10f);		//与Fan碰撞被吹起
        }
    }


    private void OnTriggerEnter2D(Collider2D other)		//判断是否碰撞到某物体
    {
        if (other.CompareTag("Spike"))
        {
            anim.SetTrigger("dead");		//设置死亡动画触发器dead
        }
    }


    public void PlayerDead()		//检测死亡并设置死亡状态
    {
		playerDead = true;
		GameManager.GameOver(playerDead);
    }




	private void OnDrawGizmosSelected()			//可视化检测范围
    {
		Gizmos.color = Color.blue;
		Gizmos.DrawWireSphere(groundCheck.transform.position, checkRadius);
    }
}
