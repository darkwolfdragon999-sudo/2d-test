using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
	public void PlayGame()
	{
		SceneManager.LoadScene(1); // Level1 must be index 1
	}

	public void QuitGame()
	{
		Application.Quit();
		Debug.Log("Game Quit"); // Shows in editor only
	}
}
