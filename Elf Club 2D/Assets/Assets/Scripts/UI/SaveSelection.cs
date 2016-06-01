using UnityEngine;
using System.Collections;

public class SaveSelection : MonoBehaviour {

    public static int[] selectedCharc;

	// Use this for initialization
	void Start () {
        DontDestroyOnLoad(transform.gameObject);
        selectedCharc = new int[4];
	}
	
	// Update is called once per frame
	void FixedUpdate () {
	
	}

    public void setSelectedCharc(int _player, int _selectedCharc)
    {
        selectedCharc[_player] = _selectedCharc;
    }

    public int getSelectedCharc(int _player)
    {
        return selectedCharc[_player];
    }
}
