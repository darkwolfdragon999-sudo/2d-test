using UnityEngine;
using TMPro;
using System.Collections.Generic;

public class LeaderboardManager : MonoBehaviour
{
	public static LeaderboardManager instance;

	private TMP_Text leaderboardText;

	private List<float> times = new List<float>();
	private const int maxScores = 5;

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
			return;
		}
	}

	public void SetLeaderboardText(TMP_Text textObject)
	{
		leaderboardText = textObject;
		RefreshLeaderboard();
	}

	public void AddTime(float time)
	{
		LoadScores();

		times.Add(time);
		times.Sort();

		if (times.Count > maxScores)
			times.RemoveAt(times.Count - 1);

		SaveScores();
	}

	public void RefreshLeaderboard()
	{
		LoadScores();
		UpdateLeaderboardUI();
	}

	void SaveScores()
	{
		PlayerPrefs.SetInt("ScoreCount", times.Count);

		for (int i = 0; i < times.Count; i++)
			PlayerPrefs.SetFloat("Score" + i, times[i]);

		PlayerPrefs.Save();
	}

	void LoadScores()
	{
		times.Clear();

		int count = PlayerPrefs.GetInt("ScoreCount", 0);

		for (int i = 0; i < count; i++)
			times.Add(PlayerPrefs.GetFloat("Score" + i));
	}

	void UpdateLeaderboardUI()
	{
		if (leaderboardText == null) return;

		leaderboardText.text = "Leaderboard\n";

		if (times.Count == 0)
		{
			leaderboardText.text += "No scores yet\n";
			return;
		}

		for (int i = 0; i < times.Count; i++)
		{
			int minutes = Mathf.FloorToInt(times[i] / 60f);
			int seconds = Mathf.FloorToInt(times[i] % 60f);

			leaderboardText.text += (i + 1) + ". " + $"{minutes:00}:{seconds:00}\n";
		}
	}
}
