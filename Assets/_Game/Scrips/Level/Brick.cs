using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Brick : ColorObject 
{
    [HideInInspector] public Stage stage;

    public void OnDespawn()
    {
        stage.RemoveBricks(this);
    }
}
 