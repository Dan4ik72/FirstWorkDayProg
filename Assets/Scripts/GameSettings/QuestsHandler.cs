using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestsHandler : MonoBehaviour
{
    [SerializeField] private List<Interactable> _quests;

    public bool CheckQuestsDone()
    {
        foreach(var quest in _quests)
        {
            if (quest.IsAvailable == true)
                return false;
        }

        return true;
    }

    public void RestartQuests()
    {
        foreach (var quest in _quests)
            quest.ResetByDefault();
    }

    public void DisableQuests()
    {
        foreach (var quest in _quests)
            quest.Disable();
    }
}
