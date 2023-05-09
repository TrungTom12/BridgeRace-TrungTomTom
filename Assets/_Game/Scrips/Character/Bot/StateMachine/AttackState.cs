using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : IState<Bot>
{
    public void OnEnter(Bot t)
    {
        //TODO:test
        //Transform target = GameObject.Find("Win").transform;
        //t.SetDestination(target.position);
        t.SetDestination(LevelManager.Ins.FinishedPoint);
    }

    public void OnExecute(Bot t)
    {
        if (t.BrickCount == 0)// neu chua du gach se chuyen state va tim gach
        {
            t.ChangeState(new PatrolState());
        }
    }

    public void OnExit(Bot t)
    {

    }

}
