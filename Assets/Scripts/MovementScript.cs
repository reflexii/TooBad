using UnityEngine;
using System.Collections;

public class MovementScript : MonoBehaviour {

	private Vector2 mousePosition;
	public float verticalSpeed;
	public float strafeSpeed;
	private Vector3 strafeDirection;
    public GameObject rotateDirectionObject;
    public float rotationDirectionEuler;
    public bool moving = false;
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
        keyboardMovement();

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
        animator.SetBool("Moving", moving);
    }

	

	

	void keyboardMovement() {
		if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W)) {
			gameObject.transform.position += Vector3.up * verticalSpeed * Time.deltaTime;
            moving = true;
		}
		if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S)) {
			gameObject.transform.position += Vector3.down * verticalSpeed * Time.deltaTime;
            moving = true;
        }
		if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A)) {
			gameObject.transform.position += Vector3.left * verticalSpeed * Time.deltaTime;
            moving = true;
        }
		if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D)) {
			gameObject.transform.position += Vector3.right * verticalSpeed * Time.deltaTime;
            moving = true;
        }
        if (Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.W) ||
            Input.GetKeyUp(KeyCode.DownArrow) || Input.GetKeyUp(KeyCode.S) ||
            Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.A) ||
            Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.D)) {

            moving = false;
        }
	}
}
