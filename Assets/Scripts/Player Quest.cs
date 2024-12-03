using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerQuest : MonoBehaviour
{
    public List<QuestItem> QuestItems = new List<QuestItem>();

    public void TakeQuest(QuestItem questItem)
    {
        var check = QuestItems.FirstOrDefault(x => x.QuestItemName == questItem.QuestItemName);
        if (check == null)
        {
            QuestItems.Add(questItem);
        }
    }
}

public class QuestItem
{
    public string QuestItemName;
}
