using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class PauseMenu : MonoBehaviour
{
	public GameObject pauseMenuUI;
	public GameObject firstSelectedButton;

	private bool isPaused = false;

	void Start()
	{
		Time.timeScale = 1f;
		pauseMenuUI.SetActive(false);
		isPaused = false;
	}

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Escape) ||
			Input.GetKeyDown(KeyCode.JoystickButton7) ||
			Input.GetKeyDown(KeyCode.JoystickButton9))
		{
			if (isPaused)
				Resume();
			else
				Pause();
		}
	}

	public void Resume()
	{
		pauseMenuUI.SetActive(false);
		Time.timeScale = 1f;
		isPaused = false;
		EventSystem.current.SetSelectedGameObject(null);
	}

	public void Pause()
	{
		pauseMenuUI.SetActive(true);
		Time.timeScale = 0f;
		isPaused = true;

		// Force controller selection
		EventSystem.current.SetSelectedGameObject(null);
		EventSystem.current.SetSelectedGameObject(firstSelectedButton);
	}

	public void LoadMainMenu()
	{
		Time.timeScale = 1f;
		SceneManager.LoadScene("MainMenu");
	}

	public void QuitGame()
	{
		Time.timeScale = 1f;
		Application.Quit();
		Debug.Log("Quit Game");
	}
}
