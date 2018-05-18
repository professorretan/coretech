using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickToLoadMap : MonoBehaviour {

    private void OnMouseDown()
    {
        Levels.CloseLevel();
        Levels.LoadLevel("Map");
    }
}
