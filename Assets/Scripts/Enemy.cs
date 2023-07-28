using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float speed = 5.0f;
    private Enumerations.EnemyType type;
    // Start is called before the first frame update
    void Start()
    {
        Physics.IgnoreCollision(GetComponent<BoxCollider>(), GameObject.Find("Left Boundary").GetComponent<MeshCollider>());
        Physics.IgnoreCollision(GetComponent<BoxCollider>(), GameObject.Find("Right Boundary").GetComponent<MeshCollider>());
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 moveDirection = GameObject.Find("Player").transform.position;
        moveDirection.y = 0.0f;
        transform.LookAt(moveDirection);
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    public void SetEnemyType(Enumerations.EnemyType type)
    {
        this.type = type;
    }
    public Enumerations.EnemyType GetEnemyType()
    {
        return type;
    }

    public void SetSpeed(float speed)
    {
        this.speed = speed;
    }
}
