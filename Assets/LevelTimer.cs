using UnityEngine;
using TMPro;

public class LevelTimer : MonoBehaviour
{
	public static LevelTimer Instance;

	public TextMeshProUGUI timerText;

	private float timeElapsed;
	private bool timerRunning = true;

	void Awake()
	{
		if (Instance != null && Instance != this)
		{
			Destroy(gameObject);
			return;
		}

		Instance = this;
		DontDestroyOnLoad(gameObject);
	}

	void Update()
	{
		if (!timerRunning) return;

		timeElapsed += Time.deltaTime;

		if (timerText != null)
			timerText.text = "Time: " + timeElapsed.ToString("F2");
	}

	public void StopTimer()
	{
		timerRunning = false;
	}

	public void ResetTimer()
	{
		timeElapsed = 0f;
		timerRunning = true;
	}

	public float GetTime()
	{
		return timeElapsed;
	}
}
