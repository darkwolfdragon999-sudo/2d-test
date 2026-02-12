using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class MainMenuLoad : MonoBehaviour
{
	public void LoadGame()
	{
		if (SaveSystem.Instance.LoadPlayer(out Vector3 pos, out int level))
		{
			StartCoroutine(LoadSceneAndPlacePlayer(level, pos));
		}
		else
		{
			Debug.Log("NO SAVE FOUND");
		}
	}

	private IEnumerator LoadSceneAndPlacePlayer(int level, Vector3 pos)
	{
		SceneManager.LoadScene(level);

		// wait one frame for scene to load
		yield return null;

		GameObject player = GameObject.FindGameObjectWithTag("Player");
		if (player != null)
		{
			player.transform.position = pos;
		}
	}
}
