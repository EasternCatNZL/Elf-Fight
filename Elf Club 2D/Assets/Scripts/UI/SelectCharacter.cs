using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SelectCharacter : MonoBehaviour {

    public int Player;
    public int SelectedCharc;
    public Image[] CharcImages;
    public static int NumCompleted;
    

	// Use this for initialization
	void Start () {
        DontDestroyOnLoad(this);
        NumCompleted = 0;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
	}

    //Sets the selected character. Takes an int to determine whether to increment(>0) or decrement(<0).
    public void SetSelection(int _Direction)
    {
        if(_Direction < 0)
        {
            if(SelectedCharc <= 0)
            {
                SelectedCharc = 3;
            }
            else
            {
                SelectedCharc--;
            }
        }
        else if(_Direction > 0)
        {
            if (SelectedCharc >= 3)
            {
                SelectedCharc = 0;
            }
            else
                SelectedCharc++;
        }
    }

    public void Select()
    {
        NumCompleted++;
        GameObject.Find("SaveData").GetComponent<SaveSelection>().setSelectedCharc(Player, SelectedCharc);
        if(NumCompleted == 2)
        {
            Application.LoadLevel("TestScene");
        }
    }
}
