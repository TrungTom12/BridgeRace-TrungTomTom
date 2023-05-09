using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewStageBox : MonoBehaviour
{
    //khi va cham vao NewstageBox se tao san cac vien gach
    public Stage stage;
    private List<ColorType> colorTypes = new List<ColorType>();

    private void OnTriggerEnter(Collider other)
    {
        Character character = other.GetComponent<Character>();

        //Nếu biến character khác null và kiểu màu của character không nằm trong danh sách colorTypes
        if (character != null && !colorTypes.Contains(character.colorType))
        {
            colorTypes.Add(character.colorType);
            character.stage = stage ;
            stage.InitColor(character.colorType, 5 );
        }
    }

}
