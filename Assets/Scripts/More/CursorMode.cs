using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorMode : MonoBehaviour
{
    public void Locked()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void Unlocked()
    {
        Cursor.lockState = CursorLockMode.None;
    }
}
