using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Setting : UICanvas
{
    //public override void Open()
    //{
    //    base.Open();
    //}

    //public override void Close(float delayTime)
    //{

    //}

    public void ContinueButton()
    {
        Close(0);
    }

    public void RetryButton()
    {
       // UIManager.Ins.OpenUI<MianMenu>();
        LevelManager.Ins.OnRetry();
        Close(0);
    }
}
