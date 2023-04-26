using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState { MaiMenu ,Gameplay,Pause}
public class GameManager : MonoBehaviour
{
    private GameState m_State;

    public void ChangeState(GameState gameState)
    {
        this.m_State = gameState;
    }

    public bool IsState(GameState gameState)
    {
        return this.m_State == gameState;
    }
}
