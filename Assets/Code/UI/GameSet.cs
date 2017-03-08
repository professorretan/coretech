using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSet : Set {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    // DEBUG: These are just for testing menu flow
    public void OnWinGameClicked()
    {
        CloseSet();
        SetManager.OpenSet<WinSet>();
    }

    // DEBUG: These are just for testing menu flow
    public void OnLoseGameClicked()
    {
        CloseSet();
        SetManager.OpenSet<LoseSet>();
    }
}
