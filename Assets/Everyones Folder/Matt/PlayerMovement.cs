using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    [Header("Basic Movement")]
    [SerializeField] private float speed;
    Rigidbody playerRB;

    [Header("Jump Variables")]
    [SerializeField] private int jumpForce;
    private bool isGrounded;

    [Header("Camera Variables")]
    [SerializeField] private float camSpeed;
    [SerializeField] private GameObject cam;
    [SerializeField] private float angleView;

    [Header("Anim")]
    [SerializeField] private GameObject arms;
    Animator playerAnim;

   
    // Start is called before the first frame update
    void Start()
    {
        playerAnim = GetComponent<Animator>();
        playerRB = GetComponent<Rigidbody>();
        Cursor.visible = false;
        Screen.lockCursor = true;
    }

    // Update is called once per frame
    void Update()
    {
        //Basic Camera
        float camHorizontal = Input.GetAxis("Mouse X") * camSpeed;
        float camVertical = Input.GetAxis("Mouse Y") * camSpeed;
        transform.Rotate(0, camHorizontal, 0);
        if (camVertical > 0)
        {
            //90-270 degrees
            if (cam.transform.eulerAngles.x < 270 + angleView && cam.transform.eulerAngles.x > 90)
            {
                camVertical = 0;
            }
        }
        else if (camVertical < 0)
        {
            if (cam.transform.eulerAngles.x > 90 - angleView && cam.transform.eulerAngles.x < 270)
            {
                camVertical = 0;
            }
        }

        cam.transform.Rotate(-camVertical, 0, 0);
        
    }
    private void FixedUpdate()
    {
        //Basic Movement
        //Forward and Back Movement
        float moveFor = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        //Left and Right Side Movement
        float moveSide = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        playerRB.velocity = transform.TransformDirection(moveSide, playerRB.velocity.y, moveFor);
        if(playerRB.velocity.x != 0 || playerRB.velocity.z != 0)
        {
            playerAnim.SetInteger("Speed", 1);
            
        }
        else
        {
            playerAnim.SetInteger("Speed", 0);
        }
    }
    public bool IsGrounded()
    {
        return isGrounded;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Door"))
        {
            other.GetComponentInParent<DoorManager>().SlamDoor();
        }
        if (other.CompareTag("KillBox"))
        {
            Cursor.visible = true;
            Screen.lockCursor = false;
            SceneManager.LoadScene("Credit_Scene");
        }
        
    }
}
