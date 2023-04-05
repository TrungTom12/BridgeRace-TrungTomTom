using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : ColorObject 
{
    //public ColorType colorType;
    void Start()
    {
        ChangeColor((ColorType)Random.Range(2, 9)); 
    }

    
    void Update()
    {
        
    }
}
 