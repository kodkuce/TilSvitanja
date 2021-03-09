using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelMainMenu : Level
{
    void Update()
    {
        if( Input.GetButtonUp("Use") )
        {
            GoNextLevel();
        }
    }
}
