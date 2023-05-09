using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorObject : GameUnit
{
    public ColorType colorType;
    
    [SerializeField] private ColorData colorData;
    [SerializeField] private Renderer renderer;

    public void ChangeColor(ColorType colorType)
    {
        this.colorType = colorType;
        renderer.material = colorData.GetColorMat(colorType);
    }
     

    //public Material[] colorMats;
    //private Material GetColorMat(ColorType colorType)
    //{
    //    return colorMats[(int)colorType];
    //}

}
