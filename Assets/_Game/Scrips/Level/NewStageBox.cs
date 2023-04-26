using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewStageBox : MonoBehaviour
{
    //khi va cham vao NewstageBox se tao san cac vien gach
    public Stage stage;

    private void OnTriggerEnter(Collider other)
    {
       Bot character = other.GetComponent<Bot>();

        if (character != null)
        {
            character.stage = stage ;
            stage.InitColor(character.colorType, 5 );
        }
    }

}
