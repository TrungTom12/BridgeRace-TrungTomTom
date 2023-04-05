using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewStageBox : MonoBehaviour
{
    public Stage stage;

    private void OnTriggerEnter(Collider other)
    {
        Player player = other.GetComponent<Player>();

        if (player != null)
        {
            player.stage = stage ;
            stage.InitColor(player.colorType, 7);
        }
    }
}
