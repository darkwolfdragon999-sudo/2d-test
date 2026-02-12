using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour
{
	public static GameTimer instance;

	public Text timerText; // Assign in inspector

	private float elapsedTime = 0f;
	private bool isRunning = false;

	void Awake()
	{
		if (instance == null)
		{
			instance = this;
			DontDestroyOnLoad(gameObject);
		}
		else
		{
			Destroy(gameObject);
		}
	}

	void OnEnable()
	{
		StartRun();
	}

	void Update()
	{
		if (!isRunning) return;

		elapsedTime += Time.deltaTime;
		UpdateTimerUI();
	}

	void UpdateTimerUI()
	{
		if (timerText == null) return;

		int minutes = Mathf.FloorToInt(elapsedTime / 60f);
		int seconds = Mathf.FloorToInt(elapsedTime % 60f);

		timerText.text = $"{minutes:00}:{seconds:00}";
	}

	public void StartRun()
	{
		elapsedTime = 0f;
		isRunning = true;
		UpdateTimerUI();
	}

	public void StopTimer()
	{
		isRunning = false;
	}

	public float GetElapsedTime()
	{
		return elapsedTime;
	}

	public string GetFinalTime()
	{
		int minutes = Mathf.FloorToInt(elapsedTime / 60f);
		int seconds = Mathf.FloorToInt(elapsedTime % 60f);
		return $"{minutes:00}:{seconds:00}";
	}
}
