using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ColorType { Default , Black , Red, Blue , Green, Yellow , Orange , Brown, Violet}

public class Stage : MonoBehaviour
{
    public Transform[] brickPoints; //list diem brickPoint

    public List<Vector3> emptyPoint = new List<Vector3>(); //list vi tri emptyPoint

    [SerializeField] Brick brickPrefab;

    public void OnInit()
    {

    }

    public void InitColor(ColorType colorType, int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            NewBrick(colorType);
        }
    }

    public void NewBrick(ColorType colorType)
    {
        if (emptyPoint.Count > 0 ) 
        {
            Brick brick = Instantiate(brickPrefab, emptyPoint[Random.Range(0, emptyPoint.Count)], Quaternion.identity);
            brick.ChangeColor(colorType);
        }
    }

}
 