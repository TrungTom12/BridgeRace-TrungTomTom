using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    public Transform startPoint;
    public Transform endPoint;
    public int botAmount;
    public Stage[] stage;

    public void OnInit()
    {
        for (int i = 0; i < stage.Length; i++)
        {
            stage[i].OnInit();
        }
    }
}
