using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Levels {
    
    [NonSerialized] public Level CurrentLevel;
    [NonSerialized] public int StartingLevel = 1;

    public void LoadStartingLevel()
    {
        LoadLevel(StartingLevel);
    }

    public void LoadLevel(int levelNumber)
    {
        if (levelNumber >= 1)
        {
            // Try to create the game object from the prefab in the resources folder (NOTE: the full path will be "Resources/Levels/Level1", etc.)
            GameObject levelGO = ResourceManager.Create("Levels/Level" + levelNumber);

            // Check if we successfully loaded the game object
            if (levelGO)
            {
                // Check to make sure the game object has the Level component
                Level level = levelGO.gameObject.GetComponent<Level>();
                if (level)
                {
                    CurrentLevel = level;

                    // Level was successfully loaded so call OnComplete
                    OnLevelLoadComplete();
                }
            }
        }
        else
        {
            Debug.Log("Unable to load level: " + levelNumber.ToString());
            return;
        }

    }

    private void OnLevelLoadComplete()
    {
        if(CurrentLevel)
        {
            CurrentLevel.SpawnPlayer();
            CurrentLevel.SpawnEnemy();
        }
    }
}
