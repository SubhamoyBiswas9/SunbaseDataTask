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
        StartCoroutine(GenerateItemList(data));
        
    }

    IEnumerator GenerateItemList(JsonData data)
    {
        foreach (var item in data.clients)
        {
            ClientItem clientItem = Instantiate(clientItemPrefab, clientListContent);

            Details clientDetail = new Details();
            switch (item.id)
            {
                case 1:
                    clientDetail = data.data.detail1;
                    break;
                case 2:
                    clientDetail = data.data.detail2;
                    break;
                case 3:
                    clientDetail = data.data.detail3;
                    break;
                default:
                    clientDetail = null;
                    break;
            }
            clientItem.Initialize(item, clientDetail);

            clientItemList.Add(clientItem);

            yield return new WaitForSeconds(.1f);
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

    void OpenPopup(string name, string points, string address)
    {
        popupPanel.SetActive(true);
        if (string.IsNullOrEmpty(name))
            popupDataUI.AssignData();
        else
            popupDataUI.AssignData(name, points, address);
    }
}
