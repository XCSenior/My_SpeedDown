using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour		//随机生成各种平台
{

	public List<GameObject> platforms = new List<GameObject>();     //List存储游戏对象组

	public float spawnTime;         //public可调整随机生成时间间隔
	private float countTime;        //脚本内部记录时间
	private Vector3 spawnPosition;	//获得生成位置
	
	
	void Update () 
	{
		SpawnPlatforms();
	}


	public void SpawnPlatforms()
    {
		countTime += Time.deltaTime;				  //开始计时
		spawnPosition = transform.position;         //随机生成位置设置成挂载物体的位置
		spawnPosition.x = Random.Range(-2.8f, 2.8f);        //生成位置的x值在范围内随机

		if (countTime >= spawnTime)			//记录时间>=设置的生成间隔时间
        {
			CreatePlatforms();
			countTime = 0;
        }

    }


	public void CreatePlatforms()
	{
		int index = Random.Range(0, platforms.Count);       //生成从0到List长度的随机数
		int spikeBallNum = 0;
        if (index == 4)
        {
			spikeBallNum++;
        }
		if(spikeBallNum>1)
        {
			spikeBallNum = 0;
			countTime = spawnTime;		//用时间控制，立即生成一个平台示例
			return;
        }
		GameObject newPlatform =  Instantiate(platforms[index], spawnPosition, Quaternion.identity);        //实例化随机生成平台
		newPlatform.transform.SetParent(this.transform);		//变成挂载物体的子集

    }


}
