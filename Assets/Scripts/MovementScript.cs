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
    private Player player;
    public int layerMask = 1 << 9;

    //player raycast stuff
    private float yDif = 0.6f;
    private float horizontalRayLength = 0.25f;
    private float verticalRayLength = 0.35f;
    private float padding = 0.1f;

    public bool rightBlocked = false;
    public bool leftBlocked = false;
    public bool topBlocked = false;
    public bool bottomBlocked = false;

	// Use this for initialization
	void Start () {
        animator = GetComponent<Animator>();
        player = GetComponent<Player>();
	}
	
	// Update is called once per frame
	void Update () {

		mouseLook();
        animations();
        keyboardMovement();
        updatePlayerDir();
        checkWalls();

	}

	void mouseLook() {
		Vector3 position = Camera.main.WorldToScreenPoint(transform.position);
		Vector3 direction = Input.mousePosition - position;
		float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
		rotateDirectionObject.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        rotationDirectionEuler = rotateDirectionObject.transform.localEulerAngles.z;
	}

    void animations() {
        animator.SetFloat("Euler", rotationDirectionEuler);
        animator.SetBool("Moving", moving);
    }

     void updatePlayerDir()
    {
        if (!Input.GetMouseButtonDown(0))
            return;

        player.facingDir = DirectionConverter.DirectionPlayerToMouse(transform.position, Input.mousePosition); ;
    }
   
	void keyboardMovement() {
		if (Input.GetKey(KeyCode.UpArrow) && !topBlocked || Input.GetKey(KeyCode.W) && !topBlocked) {
			gameObject.transform.position += Vector3.up * verticalSpeed * Time.deltaTime;
            moving = true;
		}
		if (Input.GetKey(KeyCode.DownArrow) && !bottomBlocked || Input.GetKey(KeyCode.S) && !bottomBlocked) {
			gameObject.transform.position += Vector3.down * verticalSpeed * Time.deltaTime;
            moving = true;
        }
		if (Input.GetKey(KeyCode.LeftArrow) && !leftBlocked || Input.GetKey(KeyCode.A) && !leftBlocked) {
			gameObject.transform.position += Vector3.left * verticalSpeed * Time.deltaTime;
            moving = true;
        }
		if (Input.GetKey(KeyCode.RightArrow) && !rightBlocked || Input.GetKey(KeyCode.D) && !rightBlocked) {
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
    
    void checkWalls() {
        //visual right check
        Debug.DrawRay(transform.position - new Vector3(-padding, yDif, 0f), new Vector3(horizontalRayLength, 0f, 0f), Color.yellow);
        //visual left check
        Debug.DrawRay(transform.position - new Vector3(padding, yDif, 0f), new Vector3(-horizontalRayLength, 0f, 0f), Color.yellow);
        //visual top check
        Debug.DrawRay(transform.position - new Vector3(0f, -padding + yDif, 0f), new Vector3(0f, verticalRayLength, 0f), Color.yellow);
        //visual bottom check
        Debug.DrawRay(transform.position - new Vector3(0f, padding + yDif, 0f), new Vector3(0f, -verticalRayLength, 0f), Color.yellow);

        //check right wall
        if (Physics2D.Raycast(transform.position - new Vector3(-padding, yDif, 0f), Vector3.right, horizontalRayLength, layerMask)) {
            rightBlocked = true;
        } else {
            rightBlocked = false;
        }

        //check left wall
        if (Physics2D.Raycast(transform.position - new Vector3(padding, yDif, 0f), Vector3.left, horizontalRayLength, layerMask)) {
            leftBlocked = true;
        } else {
            leftBlocked = false;
        }

        //check top wall
        if (Physics2D.Raycast(transform.position - new Vector3(0f, -padding + yDif, 0f), Vector3.up, verticalRayLength, layerMask)) {
            topBlocked = true;
        } else {
            topBlocked = false;
        }

        //check bottom wall
        if (Physics2D.Raycast(transform.position - new Vector3(0f, padding + yDif, 0f), Vector3.down, verticalRayLength, layerMask)) {
            bottomBlocked = true;
        } else {
            bottomBlocked = false;
        }
    }
}
