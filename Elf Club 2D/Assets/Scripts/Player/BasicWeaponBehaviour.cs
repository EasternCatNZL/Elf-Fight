using UnityEngine;
using System.Collections;

public class BasicWeaponBehaviour : MonoBehaviour {

    public float range; //Distance of attack from character
    public float speed; //Speed of hit box movement
    public float lifeTime; //Time that an object should exist after spawning
    public float timePosA; //Time for hit box to be in pos 1
    public float timePosB; //Time for hit box to be in pos 2
    //For test purpose
    public bool useRange; //Check to use range values when moving
    //For test purposes
    public bool useTime; //Check to use timer when moving
    [HideInInspector]
    public Vector3 parentPos; //Vector value of parent
    public float distance; //Distance ahead of parent the hit box moves to

    private Vector2 startPos; //The starting position of attack
    private Vector2 endPos; //The ending position of attack
    private Vector2 currentPos; //The current position of attack
    private float startTime; //The time when attack started
    //private float distance; //Distance traveled

	// Use this for initialization
	void Start () {
        startTime = Time.time;
        //startPos = transform.position;
        
	}
	
	// Update is called once per frame
	void Update () {
        //transform.position += transform.forward * Time.deltaTime * speed;

        //bobbleHit();
        /*
        if (useRange)
        {
            destroyRange();
        }
        if (useTime)
        {
            destroyTime();
        }
        */
	}

    //Destroys an object after flying a set range
    void destroyRange()
    {
        //Calculates the current distance since the projectile spawned
        distance = Vector2.Distance(startPos, transform.position);
        print(distance);
        //If the distance is greater than the set range, destroy the projectile
        if (distance >= range)
        {
            Destroy(gameObject);
        }
    }

    //Destroys an object after flying for a set time
    void destroyTime()
    {
        //If the time since spawning is longer than life time, destroy the game object
        Destroy(gameObject, lifeTime);
        print(Time.time - startTime);
    }


    //Create a collision box that follows the bobble hat
    //Should include two frames
    //First starts the collision box on top of elf, when bobble is still on head
    //Second moves the collision box to the area in front of elf, after swining the bobble
    /*
    void bobbleHit()
    {
        //Get the current time;
        float currentTimePassed = Time.time - startTime;
        //While in first segment of animation
        while (timePosA > currentTimePassed)
        {
            transform.position = parentPos;
        }
        //While in second segment of animation
        while (timePosB > currentTimePassed)
        {
            //Vector2 newLocation = parentPos + (gameObject.transform.position.normalized * distance);
            transform.position = parentPos + (gameObject.transform.position.normalized * distance);
        }
        //Once done, destroy the object
        Destroy(gameObject);
    }
    */
}
