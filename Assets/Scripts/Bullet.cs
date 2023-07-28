using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float speed = 5.0f;
    private Enumerations.BulletType type;
    // Start is called before the first frame update
    void Start()
    {
        Physics.IgnoreCollision(GetComponent<CapsuleCollider>(), GameObject.Find("Player").GetComponent<SphereCollider>());
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        if(transform.position.x > 25.0f || transform.position.z > 10.0f)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy Light") && gameObject.CompareTag("Bullet Dark"))
        {
            FindObjectOfType<GameManager>().UpdateScore(1);
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("Enemy Dark") && gameObject.CompareTag("Bullet Light"))
        {
            FindObjectOfType<GameManager>().UpdateScore(1);
            Destroy(collision.gameObject);
        }
        Destroy(gameObject);
    }

    public void SetBulletType(Enumerations.BulletType type)
    {
        this.type = type;
    }
    public Enumerations.BulletType GetBulletType()
    {
        return type;
    }
}
