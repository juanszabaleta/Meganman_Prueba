using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class megaman : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float jumpspeed;
    [SerializeField] BoxCollider2D mispies;
    Animator myAnimator;
    Rigidbody2D mybody;
    BoxCollider2D mycollider;
    public bool dash;
    public float dasht;
    public float speeddash;
    public GameObject[] bullet;
    public bool shooting;
    private float shoot_time;
    public float time;
    public GameObject point;


    // Start is called before the first frame update
    void Start()
    {
        myAnimator = GetComponent<Animator>();
        mybody = GetComponent<Rigidbody2D>();
        mycollider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        saltar();
        correr();
        caer();
        Dash();
        Disparo();
    }

    void correr()
    {
        float direccion = Input.GetAxis("Horizontal");
        if (direccion != 0)
        {
            if (direccion < 0)
            {
                transform.localScale = new Vector2(-1, 1);
            }
            else
                transform.localScale = new Vector2(1, 1);
            myAnimator.SetBool("isruning", true);
            transform.Translate(new Vector2(direccion * Time.deltaTime * speed, 0));
        }
        else
            myAnimator.SetBool("isruning", false);
    }
    void caer()
    {
        if(mybody.velocity.y<0)
        {
            myAnimator.SetBool("falling", true);
        }
    }
    void saltar()
    {
        if (ensuelo())
        {
            myAnimator.SetBool("falling", false);
            if (Input.GetKey(KeyCode.Space))
            {
                mybody.AddForce(new Vector2(0, jumpspeed));
                myAnimator.SetTrigger("jumping");
            }
        }
        else
            myAnimator.SetBool("falling",true);
       
    }
    bool ensuelo()
    {
        return mispies.IsTouchingLayers(LayerMask.GetMask("gruond"));
    }
    void Dash()
    {
        if (Input.GetKey(KeyCode.X))
        {
            dasht += 1 * Time.deltaTime;
            if (dasht < 0.35f)
            {
                dash = true;
                myAnimator.SetBool("dash", true);
                transform.Translate(Vector3.right * speeddash * Time.deltaTime);
            }

            else
            {
                dash = false;
                myAnimator.SetBool("dash", false);
            }
        }
        else
        {
            dash = false;
            myAnimator.SetBool("dash", false);
            dasht = 0;
        }
    }
    void Disparo()
    {
        if (Input.GetKey(KeyCode.F))
        {
            shoot_time = 0.01f;
            GameObject obj = Instantiate(bullet[0], point.transform.position, transform.rotation) as GameObject;
            if (!shooting)
            {
                shooting = true;
            }
            if(shooting)
                {
                shoot_time += 1 * Time.deltaTime;
                myAnimator.SetLayerWeight(0, 0);
                myAnimator.SetLayerWeight(1, 1);
            }
            else 
            {
                myAnimator.SetLayerWeight(0, 1);
                myAnimator.SetLayerWeight(1, 0);
            }
            if(shoot_time>= time)
            {
                shooting = false;
                shoot_time = 0;
            }
        }
    }
}
