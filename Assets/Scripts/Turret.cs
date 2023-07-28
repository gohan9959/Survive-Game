using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    [SerializeField] Camera mainCamera;
    [SerializeField] GameObject[] bullets;
    private GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.isGameActive)
        {
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit raycastHit))
            {
                Vector3 lookDirection = raycastHit.point;
                lookDirection.y = GameObject.Find("Player").transform.position.y;
                transform.LookAt(lookDirection);
            }
            if (Input.GetMouseButtonDown((int)Enumerations.BulletType.Light) && gameManager.GetBulletCount(Enumerations.BulletType.Light) > 0)
            {
                Instantiate(bullets[(int)Enumerations.BulletType.Light], transform.position, transform.rotation);
                gameManager.UpdateBulletCount(-1, Enumerations.BulletType.Light);
            }
            if (Input.GetMouseButtonDown((int)Enumerations.BulletType.Dark) && gameManager.GetBulletCount(Enumerations.BulletType.Dark) > 0)
            {
                Instantiate(bullets[(int)Enumerations.BulletType.Dark], transform.position, transform.rotation);
                gameManager.UpdateBulletCount(-1, Enumerations.BulletType.Dark);
            }
        }
    }
}
