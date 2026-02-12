using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	public float speed = 5f;
	public float jumpHeightMultiplier = 2f;

	private Rigidbody2D rb;
	private bool isGrounded;
	private Vector3 startPosition;
	private float jumpForce;

	void Start()
	{
		rb = GetComponent<Rigidbody2D>();
		startPosition = transform.position;

		float gravity = Mathf.Abs(Physics2D.gravity.y * rb.gravityScale);
		float playerHeight = GetComponent<BoxCollider2D>().size.y * transform.localScale.y;
		jumpForce = Mathf.Sqrt(2 * gravity * playerHeight * jumpHeightMultiplier);
	}

	void Update()
	{
		// Keyboard + Controller horizontal movement
		float moveX = Input.GetAxisRaw("Horizontal");
		rb.linearVelocity = new Vector2(moveX * speed, rb.linearVelocity.y);

		// Jump keys
		bool jumpPressed =
			Input.GetKeyDown(KeyCode.Space) ||
			Input.GetKeyDown(KeyCode.W) ||
			Input.GetKeyDown(KeyCode.UpArrow) ||
			Input.GetKeyDown(KeyCode.JoystickButton0) || // Controller A / Cross
			Input.GetKeyDown(KeyCode.JoystickButton5) || // D-Pad Up (some controllers)
			Input.GetButtonDown("Jump");                 // optional legacy mapping

		if (jumpPressed && isGrounded)
		{
			rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
			isGrounded = false;
		}
	}

	void OnCollisionEnter2D(Collision2D collision)
	{
		// Detect ground properly
		if (collision.gameObject.CompareTag("Ground"))
		{
			isGrounded = true;
		}
	}

	void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.CompareTag("Enemy"))
		{
			rb.linearVelocity = Vector2.zero;
			transform.position = startPosition;
		}
	}
}
