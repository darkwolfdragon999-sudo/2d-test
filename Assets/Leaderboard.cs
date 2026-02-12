using UnityEngine;
using TMPro;
using System.Collections.Generic;
using System.Linq;

public class Leaderboard : MonoBehaviour
{
	public TextMeshProUGUI leaderboardText;

	private const int maxEntries = 5;

	void Start()
	{
		DisplayLeaderboard();
	}

	public void AddTime(float newTime)
	{
		List<float> times = LoadTimes();

		times.Add(newTime);
		times = times.OrderBy(t => t).ToList();

		if (times.Count > maxEntries)
			times = times.Take(maxEntries).ToList();

		SaveTimes(times);
		DisplayLeaderboard();
	}

	void DisplayLeaderboard()
	{
		if (leaderboardText == null) return;

		List<float> times = LoadTimes();

		leaderboardText.text = "Leaderboard\n";

		for (int i = 0; i < times.Count; i++)
		{
			int minutes = Mathf.FloorToInt(times[i] / 60f);
			int seconds = Mathf.FloorToInt(times[i] % 60f);

			leaderboardText.text += $"{i + 1}. {minutes:00}:{seconds:00}\n";
		}
	}

	List<float> LoadTimes()
	{
		List<float> times = new List<float>();

		for (int i = 0; i < maxEntries; i++)
		{
			if (PlayerPrefs.HasKey("LB_Time_" + i))
				times.Add(PlayerPrefs.GetFloat("LB_Time_" + i));
		}

		return times;
	}

	void SaveTimes(List<float> times)
	{
		for (int i = 0; i < maxEntries; i++)
			PlayerPrefs.DeleteKey("LB_Time_" + i);

		for (int i = 0; i < times.Count; i++)
			PlayerPrefs.SetFloat("LB_Time_" + i, times[i]);

		PlayerPrefs.Save();
	}
}
