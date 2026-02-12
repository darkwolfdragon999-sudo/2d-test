using UnityEngine;
using UnityEngine.UI;

public class WinCondition : MonoBehaviour
{
	public GameObject winCanvas;
	public Text finalTimeText;

	private bool hasWon;

	void OnTriggerEnter2D(Collider2D other)
	{
		if (hasWon) return;
		if (!other.CompareTag("Player")) return;

		hasWon = true;

		if (GameTimer.instance != null)
		{
			GameTimer.instance.StopTimer();

			float finalTime = GameTimer.instance.GetElapsedTime();

			// Add to leaderboard
			if (LeaderboardManager.instance != null)
			{
				LeaderboardManager.instance.AddTime(finalTime);
			}

			if (finalTimeText != null)
			{
				int minutes = Mathf.FloorToInt(finalTime / 60f);
				int seconds = Mathf.FloorToInt(finalTime % 60f);
				finalTimeText.text = "Final Time: " + $"{minutes:00}:{seconds:00}";
			}
		}

		if (winCanvas != null)
			winCanvas.SetActive(true);
	}
}
