using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public Vector2 direccion;
    public float speed=20f;
    public float aim;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //transform.Translate(new Vector2(aim * Time.deltaTime * speed, 0));
        GetComponent<Rigidbody2D>().velocity = direccion * speed;
    }
    /*private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.IsTouchingLayers(LayerMask.GetMask("Ground")))
        {
            Destroy(this.gameObject);
        }
    }*/
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag != "Player")
        {
            Destroy(gameObject);
        }
    }
}
