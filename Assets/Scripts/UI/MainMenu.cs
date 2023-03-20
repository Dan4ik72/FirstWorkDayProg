using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public void PauseGame()
    {
        CursorBehavior.EnableCursor();

        Time.timeScale = 0f;
    }

    public void ContinueGame()
    {
        CursorBehavior.DisableCursor();

        Time.timeScale = 1f;
        gameObject.SetActive(false);
    }
}
