using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Basic Movement")]
    [SerializeField] private float speed;
    Rigidbody playerRB;

    [Header("Jump Variables")]
    [SerializeField] private int jumpForce;
    private bool isGrounded;

    // Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("Vertical " + Input.GetAxis("Vertical"));
        //Debug.Log("Horizontal " + Input.GetAxis("Horizontal"));

        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            Debug.Log("Jump");
            playerRB.velocity = Vector3.zero;
            playerRB.AddForce(Vector3.up * jumpForce);
        }

    }
    private void FixedUpdate()
    {
        //Forward and Back Movement
        float moveFor = Input.GetAxis("Vertical");
        //Left and Right Side Movement
        float moveSide = Input.GetAxis("Horizontal");

        float camHorizontal = Input.GetAxis("Mouse X");
        float camVertical = Input.GetAxis("Mouse Y");

        //transform.rotation.y += camHorizontal;
        playerRB.velocity = new Vector3(moveSide * speed, playerRB.velocity.y, moveFor * speed);

        isGrounded = Physics.Raycast(transform.position, Vector3.down, 1f);
    }
}
