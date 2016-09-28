using UnityEngine;
using System.Collections;

public class MovementScript : MonoBehaviour {

	private Vector2 mousePosition;
	public float verticalSpeed;
	public float strafeSpeed;
	private Vector3 strafeDirection;
    public GameObject rotateDirectionObject;
    public float rotationDirectionEuler;
    private Animator animator;

	public bool keyboardMovement1 = false;
	public bool keyboardMovement2 = false;
	public bool keyboardMovement3 = false;
	public bool keyboardMovement4 = false;

	// Use this for initialization
	void Start () {
        animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {

		mouseLook();
        animations();
		if (keyboardMovement1) {
			keyboardMovement ();
		} else if (keyboardMovement2) {
			keyboardMovement2nd ();
		} else if (keyboardMovement3) {
			keyboardMovement3rd ();
		} else if (keyboardMovement4) {
			keyboardMovement4th ();
		}

	}

	void mouseLook() {
		Vector3 position = Camera.main.WorldToScreenPoint(transform.position);
		Vector3 direction = Input.mousePosition - position;
		float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
		rotateDirectionObject.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        rotationDirectionEuler = rotateDirectionObject.transform.localEulerAngles.z;
        Debug.Log(rotationDirectionEuler);
	}

    void animations() {
        animator.SetFloat("Euler", rotationDirectionEuler);
    }

	void keyboardMovement() {

		Vector3 direction = (Input.mousePosition - Camera.main.WorldToScreenPoint (transform.position)).normalized;

		if (Input.GetKey(KeyCode.UpArrow)) {
			gameObject.transform.position += direction * verticalSpeed * Time.deltaTime;
		}
		if (Input.GetKey(KeyCode.DownArrow)) {
			gameObject.transform.position += -direction * verticalSpeed * Time.deltaTime;
		}
		if (Input.GetKeyDown(KeyCode.LeftArrow)) {
			strafeDirection = Quaternion.Euler(0, 0, 90) * direction;
		}
		if (Input.GetKey(KeyCode.LeftArrow)) {
			gameObject.transform.position += strafeDirection * strafeSpeed * Time.deltaTime;
		}
		if (Input.GetKeyDown(KeyCode.RightArrow)) {
			strafeDirection = Quaternion.Euler(0, 0, -90) * direction;
		}
		if (Input.GetKey(KeyCode.RightArrow)) {
			gameObject.transform.position += strafeDirection * strafeSpeed * Time.deltaTime;
		}
	}

	void keyboardMovement2nd() {
		float vertical = Input.GetAxis ("Vertical");
		float horizontal = Input.GetAxis ("Horizontal");

		gameObject.transform.position += new Vector3 (horizontal, vertical, gameObject.transform.position.z) * Time.deltaTime * verticalSpeed;
	}

	void keyboardMovement3rd() {
		if (Input.GetKey(KeyCode.UpArrow)) {
			gameObject.transform.position += Vector3.up * verticalSpeed * Time.deltaTime;
		}
		if (Input.GetKey(KeyCode.DownArrow)) {
			gameObject.transform.position += Vector3.down * verticalSpeed * Time.deltaTime;
		}
		if (Input.GetKey(KeyCode.LeftArrow)) {
			gameObject.transform.position += Vector3.left * verticalSpeed * Time.deltaTime;
		}
		if (Input.GetKey(KeyCode.RightArrow)) {
			gameObject.transform.position += Vector3.right * verticalSpeed * Time.deltaTime;
		}
	}

	void keyboardMovement4th() {
		Vector3 direction = (Input.mousePosition - Camera.main.WorldToScreenPoint (transform.position)).normalized;

		if (Input.GetKey(KeyCode.UpArrow)) {
			gameObject.transform.position += direction * verticalSpeed * Time.deltaTime;
		}
		if (Input.GetKey(KeyCode.DownArrow)) {
			gameObject.transform.position += -direction * verticalSpeed * Time.deltaTime;
		}
		if (Input.GetKey(KeyCode.LeftArrow)) {
			strafeDirection = Quaternion.Euler(0, 0, 90) * direction;
			gameObject.transform.position += strafeDirection * strafeSpeed * Time.deltaTime;
		}
		if (Input.GetKey(KeyCode.RightArrow)) {
			strafeDirection = Quaternion.Euler(0, 0, -90) * direction;
			gameObject.transform.position += strafeDirection * strafeSpeed * Time.deltaTime;
		}
	}
}
