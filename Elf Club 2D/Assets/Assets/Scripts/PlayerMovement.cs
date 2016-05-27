using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

    private Rigidbody2D rigid;
    public Quaternion rotate;
    private SpriteRenderer spriteRender;
    //public Transform weaponTrans;
    public Sprite[] sprites;
    public float speed;

	// Use this for initialization
	void Start () {
        rigid = GetComponent<Rigidbody2D>();
        rotate = transform.rotation;
        //weaponTrans = transform;
        spriteRender = GetComponent<SpriteRenderer>();
    }
	
	// Update is called once per frame
	void Update () {

	}

    void FixedUpdate()
    {
        Move();
        

    }

    void Move()
    {
        //Movement
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        Vector2 movement = new Vector2(h, v);
        rigid.velocity = movement * speed;


        //Rotation
        if (movement != Vector2.zero)
        {
            //float x, y, z;

            Vector2 dir = GetComponent<Rigidbody2D>().velocity;
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            rotate = Quaternion.AngleAxis(angle, Vector3.forward);


            //Change sprite when rotating in directions
            if (h > 0)
            {
                spriteRender.sprite = sprites[3];
            }
            if (h < 0)
            {
                spriteRender.sprite = sprites[2];
            }
            if (v > 0)
            {
                spriteRender.sprite = sprites[0];
            }
            if (v < 0)
            {
                spriteRender.sprite = sprites[1];
            }
        }
    }
}

//Vector3 moveDirection = gameObject.transform.position;


/*float angle = Mathf.Atan2(moveDirection.y, moveDirection.x) * Mathf.Rad2Deg;
transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);*/
