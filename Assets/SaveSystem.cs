using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveSystem : MonoBehaviour
{
	public static SaveSystem Instance;

	private void Awake()
	{
		// Keep this object alive between scenes
		if (Instance == null)
		{
			Instance = this;
			DontDestroyOnLoad(gameObject);
		}
		else
		{
			Destroy(gameObject);
		}
	}

	// Save player position and level index
	public void SavePlayer(Vector3 position, int levelIndex)
	{
		PlayerPrefs.SetFloat("PlayerX", position.x);
		PlayerPrefs.SetFloat("PlayerY", position.y);
		PlayerPrefs.SetFloat("PlayerZ", position.z);
		PlayerPrefs.SetInt("CurrentLevel", levelIndex);
		PlayerPrefs.Save();
		Debug.Log("Game Saved");
	}

	// Load player position and level index
	public bool LoadPlayer(out Vector3 position, out int levelIndex)
	{
		if (PlayerPrefs.HasKey("PlayerX") &&
			PlayerPrefs.HasKey("PlayerY") &&
			PlayerPrefs.HasKey("PlayerZ") &&
			PlayerPrefs.HasKey("CurrentLevel"))
		{
			position = new Vector3(
				PlayerPrefs.GetFloat("PlayerX"),
				PlayerPrefs.GetFloat("PlayerY"),
				PlayerPrefs.GetFloat("PlayerZ")
			);
			levelIndex = PlayerPrefs.GetInt("CurrentLevel");
			return true;
		}

		position = Vector3.zero;
		levelIndex = 0;
		return false;
	}

	// Optional: delete all saved data
	public void ClearSave()
	{
		PlayerPrefs.DeleteAll();
		Debug.Log("Save Cleared");
	}
}
