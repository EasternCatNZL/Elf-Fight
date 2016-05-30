using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

    private Rigidbody2D rigid; //Rigidbody physics component of the player character
    public Quaternion rotate; //Rotation variable hidden from the sprite
    private SpriteRenderer spriteRender; //Sprite renderer in charge of changing sprite when character is moving
    //public Transform weaponTrans;
    public Sprite[] sprites; //Array of sprites used by the sprite renderer
    public float speed; //Speed at which the player moves
    public float sprintSpeed; //Speed at which player moves if sprinting
    private float moveSpeed; //Speed used in functions
    private bool sprint; //Check if player is currently sprinting

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
        changeMoveSpeed(sprinting());
        Move();
    }

    void Move()
    {
        //Movement
        //Gets the input from horizontal and vertical input
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        //Changes the inputed values into directional movement
        Vector2 movement = new Vector2(h, v);
        rigid.velocity = movement * moveSpeed;


        //Rotation
        //Check that the character is moving
        //Otherwise, don't effect the sprite
        if (movement != Vector2.zero)
        {
            //float x, y, z;
            //Calculates the direction of mevement and returns the hidden rotation
            Vector2 dir = GetComponent<Rigidbody2D>().velocity;
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            rotate = Quaternion.AngleAxis(angle, Vector3.forward);


            //Change sprite when rotating in directions
            //Right
            if (h > 0)
            {
                spriteRender.sprite = sprites[3];
            }
            //Left
            if (h < 0)
            {
                spriteRender.sprite = sprites[2];
            }
            //Up
            if (v > 0)
            {
                spriteRender.sprite = sprites[0];
            }
            //Down
            if (v < 0)
            {
                spriteRender.sprite = sprites[1];
            }
        }
    }

    //Checks to see if player is holding key to sprint
    bool sprinting()
    {
        //Current test case
        if (Input.GetKey(KeyCode.LeftShift))
        {
            sprint = true;
        }
        else
        {
            sprint = false;
        }
        return sprint;
    }

    //Changes movement speed used in function depending on if player is sprinting
    void changeMoveSpeed(bool sprinting)
    {
        if (sprinting)
        {
            moveSpeed = sprintSpeed;
        }
        else if (!sprinting)
        {
            moveSpeed = speed;
        }
    }
}

//Vector3 moveDirection = gameObject.transform.position;


/*float angle = Mathf.Atan2(moveDirection.y, moveDirection.x) * Mathf.Rad2Deg;
transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);*/
