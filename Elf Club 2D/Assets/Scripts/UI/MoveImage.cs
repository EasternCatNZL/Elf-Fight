using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MoveImage : MonoBehaviour
{

    public float speed = 1.0f;
    public Vector3 startMarker;
    public Button selectButton;

    public Image[] Images = new Image[4];
    public Vector3[] endMarkers = new Vector3[4];
    public int StartPosition;
    public int EndPosition;
    private bool CanMove = true;
    private bool MovingLeft = false;
    private bool MovingRight = false;
    private float startTime;
    private float travelLeft;

    void Start()
    {
        //Fill the endMarker array with positions of images
        /*
        endMarkers[0] = GameObject.Find("LeftPic").transform.position;
        endMarkers[1] = GameObject.Find("CenterPic").transform.position;
        endMarkers[2] = GameObject.Find("RightPic").transform.position;
        endMarkers[3] = GameObject.Find("TopPic").transform.position;
        */
        startMarker = this.transform.position;
        Images = selectButton.GetComponent<SelectCharacter>().CharcImages;

        endMarkers[0] = Images[0].transform.position;
        endMarkers[1] = Images[1].transform.position;
        endMarkers[2] = Images[2].transform.position;
        endMarkers[3] = Images[3].transform.position;

        //Sets the start position for this image
        if (this.name == Images[0].name)
        {
            StartPosition = 0;
        }
        else if (this.name == Images[1].name)
        {
            StartPosition = 1;
        }
        else if (this.name == Images[2].name)
        {
            StartPosition = 2;
        }
        else if (this.name == Images[3].name)
        {
            StartPosition = 3;
        }
    }

    void FixedUpdate()
    {
        if (MovingLeft)
        {
            float distCovered = (Time.time - startTime) * speed;
            float fracTraveled = distCovered / travelLeft;
            this.transform.position = Vector3.Lerp(startMarker, endMarkers[EndPosition], fracTraveled);
            if (Vector3.Lerp(startMarker, endMarkers[EndPosition], fracTraveled) == endMarkers[EndPosition])
            {
                startMarker = endMarkers[EndPosition];
                StartPosition = EndPosition;
                MovingLeft = false;
            }

        }
        else if (MovingRight)
        {
            float distCovered = (Time.time - startTime) * speed;
            float fracTraveled = distCovered / travelLeft;
            this.transform.position = Vector3.Lerp(startMarker, endMarkers[EndPosition], fracTraveled);
            if (Vector3.Lerp(startMarker, endMarkers[EndPosition], fracTraveled) == endMarkers[EndPosition])
            {
                startMarker = endMarkers[EndPosition];
                StartPosition = EndPosition;
                MovingRight = false;
            }
        }
        else if (!CanMove)
        {
            CanMove = true;
            for (int i = 0; i < 3; ++i)
            {
                if (Images[i].GetComponent<MoveImage>().MovingLeft == true || Images[i].GetComponent<MoveImage>().MovingRight == true)
                {
                    CanMove = false;
                }
            }
        }
    }


    //Prepares image to move left
    public void MoveLeft()
    {
        //Checks if images are still moving
        if (!CanMove || MovingLeft || MovingRight)
            return;
        if (StartPosition == 0)
        {
            EndPosition = 3;
        }
        else
        {
            EndPosition = StartPosition - 1;
        }
        startTime = Time.time;
        travelLeft = Vector3.Distance(startMarker, endMarkers[EndPosition]);
        MovingLeft = true;
        CanMove = false;
    }

    //Prepares image to move left
    public void MoveRight()
    {
        //Checks if images are still moving
        if (!CanMove || MovingLeft || MovingRight)
            return;
        if (StartPosition == 3)
        {
            EndPosition = 0;
        }
        else
        {
            EndPosition = StartPosition + 1;
        }
        startTime = Time.time;
        travelLeft = Vector3.Distance(startMarker, endMarkers[EndPosition]);
        MovingRight = true;
        CanMove = false;
    }

    public void SetCanMove(bool _NewBool)
    {
        CanMove = _NewBool;
    }

}