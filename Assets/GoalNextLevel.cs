using UnityEngine;
using UnityEngine.SceneManagement;

public class GoalNextLevel : MonoBehaviour
{
	void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.CompareTag("Player"))
		{
			int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
			SceneManager.LoadScene(nextSceneIndex);
		}
	}
}
