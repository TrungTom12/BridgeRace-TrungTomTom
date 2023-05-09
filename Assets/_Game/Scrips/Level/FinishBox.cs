using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishBox : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Character character = other.GetComponent<Character>();
        if (character != null)
        {
            Debug.Log("Da win");
            LevelManager.Ins.OnFinishGame();
            if (character is Player)
            {
                UIManager.Ins.OpenUI<Win>();
            }
            else 
            {
                UIManager.Ins.OpenUI<Lose>();
            }
            UIManager.Ins.CloseUI<GamePlay>();

            //Sau khi ket thuc game can phai chuyen state de bot va player  dung hoat dong
            GameManager.Ins.ChangeState(GameState.Pause);
            //Xu ly sau khi win hoac lose
            character.ChangeAnim("victory");
            character.transform.eulerAngles = Vector3.up * 180;
            character.OnInit();
        }
    }
}