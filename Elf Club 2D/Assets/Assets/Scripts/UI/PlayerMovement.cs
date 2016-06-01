using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

    public static float speed = 10;
    private float charSelected;

	// Use this for initialization
	void Start () {
        charSelected = GameObject.Find("SaveData").GetComponent<SaveSelection>().getSelectedCharc(1);
        if(charSelected == 0)
        {
            GetComponent<SpriteRenderer>().color = Color.blue;
        }
        else if (charSelected == 1)
        {
            GetComponent<SpriteRenderer>().color = Color.red;
        }
        else if (charSelected == 2)
        {
            GetComponent<SpriteRenderer>().color = Color.green;
        }
    }
	
	// Update is called once per frame
	void Update () {
	    
	}

    void FixedUpdate()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        Vector2 movement = new Vector2(h, v);
        GetComponent<Rigidbody2D>().velocity = movement * speed;
    }

    public void IncreaseSpeed()
    {
        speed++;
    }
}
