using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float horizontalInput;
    public float verticalInput;
    private float speed = 6.0f;
    private float jumpForce = 40.0f;
    private Rigidbody playerRB;
    private bool onGround;
    private GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        onGround = true;
        playerRB = GetComponent<Rigidbody>();
        gameManager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.isGameActive)
        {
            MovePlayer();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            onGround = true;
        }
        if (collision.gameObject.CompareTag("Enemy Light") || collision.gameObject.CompareTag("Enemy Dark"))
        {
            gameManager.UpdateLives(-1);
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("Debris"))
        {
            gameManager.UpdateLives(-2);
        }
    }

    void MovePlayer()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
        if (onGround)
        {
            playerRB.AddForce(Vector3.forward * verticalInput * speed, ForceMode.Acceleration);
            playerRB.AddForce(Vector3.right * horizontalInput * speed, ForceMode.Acceleration);
        }
        if (Input.GetKeyDown(KeyCode.Space) && onGround)
        {
            Vector3 jumpDirection = new Vector3(horizontalInput, 1.0f, verticalInput);
            playerRB.AddForce(jumpDirection * jumpForce, ForceMode.Impulse);
            onGround = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Immunity"))
        {
            Debug.Log("Picked Immunity");
        }
        if (other.gameObject.CompareTag("Heart"))
        {
            gameManager.UpdateLives(1);
        }
        if(other.gameObject.CompareTag("Refill Light"))
        {
            gameManager.UpdateBulletCount(1, Enumerations.BulletType.Light);
        }
        if (other.gameObject.CompareTag("Refill Dark"))
        {
            gameManager.UpdateBulletCount(1, Enumerations.BulletType.Dark);
        }
        Destroy(other.gameObject);
    }
}
