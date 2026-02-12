using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerSaveLoad : MonoBehaviour
{
	void Start()
	{
		// Try to load when the level starts
		if (SaveSystem.Instance.LoadPlayer(out Vector3 pos, out int level))
		{
			if (level == SceneManager.GetActiveScene().buildIndex)
			{
				transform.position = pos;
			}
		}
	}

	// This is what the pause menu will call
	public void SavePosition()
	{
		int level = SceneManager.GetActiveScene().buildIndex;
		SaveSystem.Instance.SavePlayer(transform.position, level);
		Debug.Log("PLAYER SAVED");
	}
}
