using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
	public float speed = 2f;
	public float moveDistance = 3f;

	private Vector3 startPosition;
	private int direction = 1;

	void Start()
	{
		startPosition = transform.position;
	}

	void Update()
	{
		transform.Translate(Vector2.right * direction * speed * Time.deltaTime);

		if (Vector3.Distance(transform.position, startPosition) >= moveDistance)
		{
			direction *= -1;
		}
	}
}
