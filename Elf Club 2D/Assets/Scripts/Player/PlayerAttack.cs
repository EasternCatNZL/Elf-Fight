using UnityEngine;
using System.Collections;

public class PlayerAttack : MonoBehaviour {

    public Rigidbody2D weapon; //Rigidbody physics component of the weapon
    public float attackSpeed; //The speed at which the weapon initially moves
    [HideInInspector]
    public Transform weaponTrans; //Transform of the weapon    
    private Quaternion weaponRotate; //Rotation of the weapon


    // Use this for initialization
    void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
	    
	}

    void FixedUpdate()
    {
        Attack();
    }

    void Attack()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            //Gets the hidden rotation of the player
            weaponRotate = GetComponent<PlayerMovement>().rotate;
            //Creates weapon using current transform and hidden rotation
            Rigidbody2D weaponInstance = Instantiate(weapon, transform.position, weaponRotate) as Rigidbody2D;
            //Gives weapon speed
            //weaponInstance.velocity = attackSpeed * weaponInstance.transform.right ;
        }
    }
}
