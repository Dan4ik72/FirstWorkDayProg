using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class CursorBehavior
{
    public static void DisableCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public static void EnableCursor()
    {
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
    }
}
