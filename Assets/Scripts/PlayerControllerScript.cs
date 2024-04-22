using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerScript : MonoBehaviour
{
    [SerializeField]
    protected CharacterController controller;

    [SerializeField]
    protected float moveSpeed;
    [SerializeField]
    protected float mouseSpeed;

    private float cameraTilt = 0;
    
    [SerializeField]
    protected Transform cam;

    public bool canMove;

    private float originalSpeed;

    private float fasterSpeed;
    void Awake()
    {
        canMove = true;
    }
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        originalSpeed = moveSpeed;
        fasterSpeed = originalSpeed + 3;
    }

    // Update is called once per frame
    void Update()
    {
        if (canMove)
        {
            HandleMovement();
            //Debug.Log("Can Move");
        }
        if (!canMove)
        {
            //Debug.Log("Can't Move");
        }
    }


    public void HandleMovement()
    {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        float side = Input.GetAxis("Horizontal");
        float forward = Input.GetAxis("Vertical");

        float turn = mouseX * Time.deltaTime * mouseSpeed;
        float tilt = mouseY * Time.deltaTime * mouseSpeed * -1;

        float y = -9.8f * Time.deltaTime;
        float x = side * moveSpeed * Time.deltaTime;
        float z = forward * moveSpeed * Time.deltaTime;

        cameraTilt += tilt;
        cameraTilt = Mathf.Clamp(cameraTilt, -80, 80);

        cam.localEulerAngles = new Vector3(cameraTilt, 0,0);
        controller.Move(transform.TransformDirection(new Vector3(x, y, z)));
        transform.eulerAngles += new Vector3(0, turn, 0);

        if (Input.GetKey(KeyCode.LeftShift))
        {
            moveSpeed = fasterSpeed;
        }
        else
        {
            moveSpeed = originalSpeed;
        }
    }
}
