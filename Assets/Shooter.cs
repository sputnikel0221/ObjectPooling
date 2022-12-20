using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField]
    private GameObject bulletPrefab;

    private Camera mainCam;
    private bool isShoot = false;

    void Start()
    {
        mainCam = Camera.main;

    }

    void Update()
    {
        if (Input.GetMouseButton(0) && isShoot == false)
        {
            RaycastHit hitResult;
            if (Physics.Raycast(mainCam.ScreenPointToRay(Input.mousePosition), out hitResult))
            {
                isShoot = true;
                for (int i = 0; i < 500; i++)
                {
                    var bullet = ObjectPool.GetObject(); // 수정
                    var direction = new Vector3(hitResult.point.x, transform.position.y, hitResult.point.z) - transform.position;
                    bullet.transform.position = direction.normalized;
                    bullet.Shoot(direction.normalized);
                    isShoot = false;
                }
            }
        }
    }
}
