using UnityEngine;
using System.Collections;

public class PlayerAttack : MonoBehaviour {

    public Rigidbody2D weapon;
    public float attackSpeed;
    public Transform weaponTrans;
    private Quaternion weaponRotate;
    

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
            weaponRotate = GetComponent<PlayerMovement>().rotate;
            Rigidbody2D weaponInstance = Instantiate(weapon, transform.position, weaponRotate) as Rigidbody2D;
            weaponInstance.velocity = attackSpeed * weaponInstance.transform.right ;
        }
    }
}
