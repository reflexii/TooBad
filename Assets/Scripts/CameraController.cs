using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	public GameObject player;
	private float speed;
	private Vector3 moveTemporary;
	private float xDifference;
	private float yDifference;
	public float movementLimit;

	public bool marioCamera = true;
	public bool smoothing = true;
	public float smoothingSpeed;

	void Start () {
		speed = GameObject.Find ("Player").GetComponent<MovementScript> ().verticalSpeed;
	}

	void Update () {
		if (marioCamera) {
			xDifference = Mathf.Abs (player.transform.position.x - transform.position.x);
			yDifference = Mathf.Abs (player.transform.position.y - transform.position.y) * (16f/9f);

			if (xDifference >= movementLimit || yDifference >= movementLimit) {
				moveTemporary = player.transform.position;
				moveTemporary.z = -10f;

				transform.position = Vector3.MoveTowards (transform.position, moveTemporary, speed * Time.deltaTime);

			}
		} else if (!marioCamera && !smoothing) {
			transform.position = new Vector3(player.transform.position.x, player.transform.position.y, -10f);
		} else if (!marioCamera && smoothing) {
			transform.position = Vector3.Lerp (transform.position, new Vector3 (player.transform.position.x, player.transform.position.y, -10f), smoothingSpeed * Time.deltaTime);
		}

	}
}
