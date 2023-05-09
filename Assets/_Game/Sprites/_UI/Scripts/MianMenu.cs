using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MianMenu : UICanvas
{
    public void PlayButton()
    {
        LevelManager.Ins.OnStartGame();

        UIManager.Ins.OpenUI<GamePlay>();

        Close(0);
    }
}
