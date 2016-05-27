using UnityEngine;
using System.Collections;

public class BasicWeaponBehaviour : MonoBehaviour {

    public float range; //Distance of attack from character
    public float speed; //Speed of hit box movement
    public float lifeTime; //Time that an object should exist after spawning
    public bool useRange;
    public bool useTime;

    private Vector2 startPos; //The starting position of attack
    private Vector2 endPos; //The ending position of attack
    private Vector2 currentPos; //The current position of attack
    private float startTime; //The time when attack started
    private float distance; //Distance traveled

	// Use this for initialization
	void Start () {
        //startTime = Time.time;
        startPos = transform.position;
        startTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
        //transform.position += transform.forward * Time.deltaTime * speed;
        if (useRange)
        {
            destroyRange();
        }
        if (useTime)
        {
            destroyTime();
        }
	}

    //Destroys an object after flying a set range
    void destroyRange()
    {
        distance = Vector2.Distance(startPos, transform.position);
        print(distance);
        if (distance >= range)
        {
            Destroy(gameObject);
        }
    }

    void destroyTime()
    {
        Destroy(gameObject, lifeTime);
        print(Time.time - startTime);
    }
}
