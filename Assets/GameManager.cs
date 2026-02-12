using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	public static GameManager Instance;

	public float currentTime;
	public List<float> scores = new List<float>();

	void Awake()
	{
		if (Instance == null)
		{
			Instance = this;
			DontDestroyOnLoad(gameObject);
		}
		else
		{
			Destroy(gameObject);
		}
	}

	public void ResetTimer()
	{
		currentTime = 0f;
	}

	public void AddScore(float time)
	{
		scores.Add(time);
		scores.Sort();
	}
}
