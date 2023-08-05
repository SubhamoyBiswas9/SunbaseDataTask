using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ClientRole
{
    AllClients,
    ManagersOnly,
    NonManagers
}

public class DataUI : MonoBehaviour
{
    [SerializeField] ClientItem clientItemPrefab;
    [SerializeField] Transform clientListContent;

    [SerializeField] GameObject popupPanel;
    [SerializeField] PopupData popupDataUI;

    List<ClientItem> clientItemList = new List<ClientItem>();

    private void OnEnable()
    {
        EventHandler.OnDataFetched += GenerateList;
        EventHandler.OnItemClicked += OpenPopup;
    }

    private void OnDisable()
    {
        EventHandler.OnDataFetched -= GenerateList;
        EventHandler.OnItemClicked -= OpenPopup;
    }

    public void GenerateList(JsonData data)
    {
        foreach(var item in data.clients)
        {
            ClientItem clientItem = Instantiate(clientItemPrefab, clientListContent);
            clientItem.Initialize(item.id, item.label, item.isManager);

            clientItemList.Add(clientItem);
        }
        
    }

    public void OnDropdownValueChanged(int val)
    {
        foreach(var item in clientItemList)
        {
            item.gameObject.SetActive(false);
        }

        switch ((ClientRole)val)
        {
            case ClientRole.AllClients:
                foreach (var item in clientItemList)
                {
                    item.gameObject.SetActive(true);
                }
                break;
            case ClientRole.ManagersOnly:
                foreach (var item in clientItemList)
                {
                    if (item._isManager)
                        item.gameObject.SetActive(true);
                }
                break;
            case ClientRole.NonManagers:
                foreach (var item in clientItemList)
                {
                    if (!item._isManager)
                        item.gameObject.SetActive(true);
                }
                break;
        }
    }

    void OpenPopup(int id, string label, bool isManager)
    {
        popupPanel.SetActive(true);
        popupDataUI.AssignData(id, label, isManager);
    }
}
