using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour // Timer
{
	public Text timerText;
	public float currentTime = 30;
	public string sceneName = "EndScene";
	
	bool mercy = true;
	public float mercyPeriod = 2;

	void Start()
	{
		timerText.text = "Time: " + (int)currentTime;
	}


    // Update is called once per frame
    void Update()
    {
		if (mercy == true)
		{
			mercyPeriod -= Time.deltaTime;
			if (mercyPeriod <=0)
			{
				mercy = false;
			}
		}
		else
		{
			currentTime -= Time.deltaTime;
			timerText.text = "Time: " + (int)currentTime;
		}
		
		if (currentTime <= 0)
		{
			SceneManager.LoadScene(sceneName);
		}
    }
}
