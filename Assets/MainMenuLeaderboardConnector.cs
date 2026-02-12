using UnityEngine;
using TMPro;

public class MainMenuLeaderboardConnector : MonoBehaviour
{
	public TMP_Text leaderboardText;

	void Start()
	{
		if (LeaderboardManager.instance != null)
		{
			LeaderboardManager.instance.SetLeaderboardText(leaderboardText);
		}
	}
}
