using UnityEngine;
using UnityEngine.SceneManagement;

public class RunTimer : MonoBehaviour
{
	public static RunTimer Instance;

	public float timeElapsed;
	private bool isRunning = false;

	void Awake()
	{
		// Singleton pattern
		if (Instance != null && Instance != this)
		{
			Destroy(gameObject);
			return;
		}

		Instance = this;
		DontDestroyOnLoad(gameObject);
	}

	void Start()
	{
		StartTimer();
	}

	void Update()
	{
		if (!isRunning) return;

		timeElapsed += Time.deltaTime;
	}

	public void StartTimer()
	{
		isRunning = true;
	}

	public void StopTimer()
	{
		isRunning = false;
	}

	public void ResetTimer()
	{
		timeElapsed = 0f;
		isRunning = true;
	}

	public float GetTime()
	{
		return timeElapsed;
	}
}
