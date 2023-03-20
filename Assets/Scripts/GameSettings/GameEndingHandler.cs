using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameEndingHandler : MonoBehaviour
{
    [SerializeField] private QuestsHandler _questsHandler;
    [SerializeField] private Image _spottedPanel;
    [SerializeField] private Image _notInTimePanel;
    [SerializeField] private Image _donePanel;    
 
    [SerializeField] private Movement _playerMovement;

    public void TryToEndGame()
    {
        if (_questsHandler.CheckQuestsDone())
            ShowDonePanel();
        else
            ShowNotIntimePanel();
    }

    public void ShowSpottedPanel()
    {
        CursorBehavior.EnableCursor();
        _spottedPanel.gameObject.SetActive(true);
        _playerMovement.enabled = false;
    }

    private void ShowNotIntimePanel()
    {
        if (_spottedPanel.gameObject.active == true)
            return;

        CursorBehavior.EnableCursor();

        _notInTimePanel.gameObject.SetActive(true);
        _playerMovement.enabled = false;
    }

    private void ShowDonePanel()
    {
        CursorBehavior.EnableCursor();
        _donePanel.gameObject.SetActive(true);
        _playerMovement.enabled = false;
    }
}
