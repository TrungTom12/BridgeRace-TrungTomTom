using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform playerTF;
    public Transform TF;
    [SerializeField] Vector3 offset;

    private void LateUpdate()
    {
        TF.position = Vector3.Lerp(TF.position, playerTF.position + offset, Time.deltaTime * 5f);
    }
}
