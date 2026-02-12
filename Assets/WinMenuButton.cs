using UnityEngine;
using UnityEngine.SceneManagement;

public class WinMenuButton : MonoBehaviour
{
	public void GoToMainMenu()
	{
		// Resume time before changing scenes
		Time.timeScale = 1f;

		// Load Main Menu scene (must be in Build Settings)
		SceneManager.LoadScene("MainMenu");
	}
}
