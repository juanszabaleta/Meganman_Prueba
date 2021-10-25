using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class disparo : MonoBehaviour
{
    public GameObject bullet;

    // Update is called once per frame
    private void Update()
    {
        shootbullet();
    }
    private void shootbullet()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            Instantiate(bullet, transform.position, Quaternion.identity);

        }
    }
}
