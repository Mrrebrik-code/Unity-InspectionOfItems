using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    private InputState inputState;
    [SerializeField] private KeyCode TakeObject = KeyCode.F;
    [SerializeField] private KeyCode DropObject = KeyCode.Mouse1;
    [SerializeField] private KeyCode RotationObject = KeyCode.Mouse0;
    //[SerializeField] private int DropObject = 0;
    private void Update()
    {
        inputState.isTakeObject = Input.GetKeyDown(TakeObject);
        inputState.isDropObject = Input.GetKeyDown(DropObject);
        inputState.isRotationObject = Input.GetKey(RotationObject);
        //inputState.isDropObject = Input.GetMouseButton(0);
        inputState.isZoomObject = Input.GetAxis("Mouse ScrollWheel") != 0;
    }


    private void Start()
    {
        Initializate();
    }

    private void Initializate()
    {
        TakeObject = KeyCode.F;
        DropObject = KeyCode.Mouse1;
        RotationObject = KeyCode.Mouse0;
        inputState = GetComponent<InputState>();
    }
}
