using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour 
{

	static GameManager instance;

	public Text timeScore;
	public GameObject gameOverUI;

	private void Awake()
    {
        if (instance != null)
        {
			Destroy(gameObject);
        }
		instance = this;
    }

	
	void Update () 
	{
		timeScore.text = Time.timeSinceLevelLoad.ToString("00");		//设置计时UI文字内容，每次场景加载重新计算时间
	}


	public void RestartGame()
    {
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);     //加载当前场景名字的场景，即重载场景
		Time.timeScale = 1;			//重新开始游戏
    }

	public void Quit()
    {
		Application.Quit();			//build游戏后可体现效果
    }


	public static void GameOver(bool isDead)		//static可在其他脚本中调用
    {
        if (isDead)
        {
			instance.gameOverUI.SetActive(true);		//显示游戏结束UI
			Time.timeScale = 0;		//游戏整体暂停
        }
    }

}
