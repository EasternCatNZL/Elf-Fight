using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class InitCanvas : MonoBehaviour {

    public float speed = 1.0f;
    public Image[] CharPics;
    public GameObject SaveData;
    public Vector3[] startMarkers = new Vector3[4];
    private Vector3[] endMarkers = new Vector3[4];
    public Vector3 Origin;

    private bool MovingLeft = false;
    private bool MovingRight = false;
    private float startTime;
    private float travelLeft;
    private int selectedCharc;
    

    // Use this for initialization
    void Start () {
        selectedCharc = 1;
    }
	
	// Update is called once per frame
	void FixedUpdate () {

        if(MovingLeft)
        {
            float distCovered = (Time.time - startTime) * speed;
            float fracTraveled = distCovered / travelLeft;
            for (int i = 0; i < CharPics.Length; i++)
            {
                //CharPics[i].transform.position = Vector3.Lerp(startMarkers[i].transform.position, endMarkers[i].transform.position, fracTraveled);
                CharPics[i].transform.position = Vector3.Lerp(startMarkers[i], endMarkers[i], fracTraveled);
            }
            
            if(Vector3.Lerp(startMarkers[0], endMarkers[0], fracTraveled) == endMarkers[0])
            {
                MovingLeft = false;
            }
            
        }
        else if (MovingRight)
        {
            float distCovered = (Time.time - startTime) * speed;
            float fracTraveled = distCovered / travelLeft;
            for (int i = 0; i < CharPics.Length; i++)
            {
                //CharPics[i].transform.position = Vector3.Lerp(startMarkers[i].transform.position, endMarkers[i].transform.position, fracTraveled);
                CharPics[i].transform.position = Vector3.Lerp(startMarkers[i], endMarkers[i], fracTraveled);
            }

            if (Vector3.Lerp(startMarkers[0], endMarkers[0], fracTraveled) == endMarkers[0])
            {
                MovingRight = false;
            }
            
        }
    }

    public void MoveLeft()
    {
        
        if (MovingLeft || MovingRight)
            return;
        if (selectedCharc == 3)
            selectedCharc = 0;
        else
            selectedCharc++;
        startTime = Time.time;
        for(int i = 0; i < 4; i ++)
        {
            startMarkers[i] = CharPics[i].transform.position;
            if (startMarkers[i].x == Origin.x && startMarkers[i].y == Origin.y)
            {
                endMarkers[i] = new Vector3(startMarkers[i].x - 160, startMarkers[i].y + 100, 0);
            }
            else if (startMarkers[i].x == (Origin.x - 160) && startMarkers[i].y == (Origin.y + 100))
            {
                endMarkers[i] = new Vector3(startMarkers[i].x + 160, startMarkers[i].y + 100, 0);
            }
            else if (startMarkers[i].x == Origin.x && startMarkers[i].y == (Origin.y + 200))
            {
                endMarkers[i] = new Vector3(startMarkers[i].x + 160, startMarkers[i].y - 100, 0);
            }
            else if (startMarkers[i].x == (Origin.x + 160) && startMarkers[i].y == (Origin.y + 100))
            {
                endMarkers[i] = new Vector3(startMarkers[i].x - 160, startMarkers[i].y - 100, 0);
            }
        }

        travelLeft = Vector3.Distance(startMarkers[0], endMarkers[0]);
        MovingLeft = true;

    }

    public void MoveRight()
    {
        //Vector3 Origin = this.transform.position;
        if (MovingLeft || MovingRight)
            return;
        if (selectedCharc == 3)
            selectedCharc = 0;
        else
            selectedCharc++;
        startTime = Time.time;
        for (int i = 0; i < 4; i++)
        {
            startMarkers[i] = CharPics[i].transform.position;
            if (startMarkers[i].x == Origin.x && startMarkers[i].y == Origin.y)
            {
                endMarkers[i] = new Vector3(startMarkers[i].x + 160, startMarkers[i].y + 100, 0);
                
            }
            else if (startMarkers[i].x == (Origin.x - 160) && startMarkers[i].y == (Origin.y + 100))
            {
                endMarkers[i] = new Vector3(startMarkers[i].x + 160, startMarkers[i].y - 100, 0);
                
            }
            else if (startMarkers[i].x == Origin.x && startMarkers[i].y == (Origin.y + 200))
            {
                endMarkers[i] = new Vector3(startMarkers[i].x - 160, startMarkers[i].y - 100, 0);
            }
            else if (startMarkers[i].x == (Origin.x + 160) && startMarkers[i].y == (Origin.y + 100))
            {
                endMarkers[i] = new Vector3(startMarkers[i].x - 160, startMarkers[i].y + 100, 0);
            }
        }

        travelLeft = Vector3.Distance(startMarkers[0], endMarkers[0]);
        MovingRight = true;

    }

    public void SelectCharc()
    {
        SaveData.SendMessage("setSelectedCharc", selectedCharc);
        Application.LoadLevel("TestScene");
    }
}
