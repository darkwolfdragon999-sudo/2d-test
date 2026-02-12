using UnityEngine;

public class MainMenuUI : MonoBehaviour
{
	public GameObject leaderboardPanel;

	public void ShowLeaderboard()
	{
		leaderboardPanel.SetActive(true);

		if (LeaderboardManager.instance != null)
			LeaderboardManager.instance.RefreshLeaderboard();
	}

	public void HideLeaderboard()
	{
		leaderboardPanel.SetActive(false);
	}
}
