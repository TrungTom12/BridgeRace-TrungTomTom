using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class JoystickController : MonoBehaviour
{
    public static Vector3 direct;
    private Vector3 screen; 
    private Vector3 mousePosition => Input.mousePosition - screen / 2; // lấy giá trị thật của Vector không theo độ phân giải màn hình

    public RectTransform joystickBG;
    public RectTransform joystickControl;

    private Vector3 startPoint;
    private Vector3 updatePoint;
    [SerializeField] private float magnitune;

    public GameObject joystickPanel;

    void Start()
    {
        screen.x = Screen.width;
        screen.y = Screen.height;

        direct = Vector3.zero;

        joystickPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //Debug.Log("qq");
            startPoint = mousePosition;
            joystickBG.anchoredPosition = startPoint;

            joystickPanel.SetActive(true);
        }

        if (Input.GetMouseButton(0))
        {
            //Debug.Log("vv");
            updatePoint = mousePosition;
            joystickControl.anchoredPosition = Vector3.ClampMagnitude((updatePoint - startPoint), magnitune) + startPoint;
            //Debug.Log(Input.mousePosition);
            direct = (updatePoint - startPoint).normalized;
            direct.z = direct.y;
            direct.y = 0;
        }

        if(Input.GetMouseButtonUp(0)) 
        {
            joystickPanel.SetActive(false);
            direct = Vector3.zero;
        }
    }

    //private void OnDisable()
    //{
    //    direct = Vector3.zero;
    //}

}
