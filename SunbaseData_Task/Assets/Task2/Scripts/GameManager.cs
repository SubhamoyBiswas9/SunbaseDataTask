using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    List<GameObject> deletionList = new List<GameObject>();

    private void OnEnable()
    {
        EventHandler.OnCrossed += AddToDeletionList;
        EventHandler.OnMouseUpEvent += DeleteItems;
    }

    private void OnDisable()
    {
        EventHandler.OnCrossed -= AddToDeletionList;
        EventHandler.OnMouseUpEvent += DeleteItems;
    }

    public void AddToDeletionList(GameObject item)
    {
        deletionList.Add(item);
    }

    public void DeleteItems()
    {
        if (deletionList.Count == 0) return;

        foreach (var item in deletionList)
            Destroy(item);

        deletionList.Clear();
    }
}
