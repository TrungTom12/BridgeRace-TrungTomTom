using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;

public class Bot : Character
{
    public NavMeshAgent agent;

    private Vector3 destination;

    //check khoang cach ngan nhat(luu y doan cuoi part 4)
    public bool IsDestination => Vector3.Distance(destination,Vector3.right * transform.position.x + Vector3.forward * transform.position.z) < 0.1;

    //protected override void Start()
    //{
    //    base.Start();
    //    ChangeState(new PatrolState());
    //}

    public override void OnInit()
    {
        base.OnInit();
        ChangeAnim("idle");
    }

    public void SetDestination(Vector3 position)  //tu tim den muc tieu 
    {
        agent.enabled = true;
        destination = position;
        destination.y= 0;
        agent.SetDestination(position);
    }

    IState<Bot> currentState;

    private void Update()
    {
        if (GameManager.Ins.IsState(GameState.Gameplay) && currentState != null)
        {
            currentState.OnExecute(this);
            //Check stair
            CanMove(transform.position);    
        }
    }
    public void ChangeState(IState<Bot> state)
    {
        if (currentState != null)
        {
            currentState.OnExit(this);
        }

        currentState = state;

        if (currentState != null)
        {
            currentState.OnEnter(this);
        }
    }

    internal void MoveStop()
    {
        agent.enabled = false;
    }
}
