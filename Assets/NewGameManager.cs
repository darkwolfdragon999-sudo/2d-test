using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class NewGameManager : MonoBehaviour
{
	public string firstLevelName;

	public void StartNewGame()
	{
		StartCoroutine(LoadLevelAndStartTimer());
	}

	private IEnumerator LoadLevelAndStartTimer()
	{
		SceneManager.LoadScene(firstLevelName);

		// Wait one frame for the scene to load
		yield return null;

		// Start the timer after the scene is loaded
		if (GameTimer.instance != null)
		{
			GameTimer.instance.StartRun();
		}
	}
}
