using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Debris : MonoBehaviour
{
    private Rigidbody debrisRb;
    [SerializeField] float force;
    private bool moveLeft;
    [SerializeField] int health = 2;
    // Start is called before the first frame update
    void Start()
    {
        debrisRb = GetComponent<Rigidbody>();
        Physics.IgnoreCollision(GetComponent<CapsuleCollider>(), GameObject.Find("Left Boundary").GetComponent<MeshCollider>());
        Physics.IgnoreCollision(GetComponent<CapsuleCollider>(), GameObject.Find("Right Boundary").GetComponent<MeshCollider>());
        if(transform.position.x > 0)
        {
            moveLeft = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (moveLeft)
        {
            debrisRb.AddForce(Vector3.left * force);
        }
        else
        {
            debrisRb.AddForce(Vector3.right * force);
        }
        if(transform.position.y < -2.0f || health <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy Dark") || collision.gameObject.CompareTag("Enemy Light"))
        {
            health--;
            FindObjectOfType<GameManager>().UpdateScore(1);
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.CompareTag("Debris"))
        {
            health = 0;
        }
    }
}
