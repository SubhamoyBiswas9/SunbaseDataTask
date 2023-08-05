using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using DG.Tweening;

public class ClientItem : MonoBehaviour
{
    [SerializeField] TMP_Text labelText;
    [SerializeField] TMP_Text pointsText;

    [SerializeField] RectTransform rectTransform;
    [SerializeField] float scaleDuration = .2f;

    bool isManager; public bool _isManager { get => isManager; }

    int id;
    int points;
    string label;
    string clientName;
    string address;

    private void OnEnable()
    {
        rectTransform.localScale = Vector3.zero;
        rectTransform.DOScale(1, scaleDuration);
    }

    public void Initialize(ClientData clientData, Details clientDetails)
    {
        this.id = clientData.id;        
        this.label = clientData.label;
        this.isManager = clientData.isManager;
        labelText.text = clientData.label;

        if (clientDetails == null)
            pointsText.text = "N/A";
        else
        {
            this.clientName = clientDetails.name;
            this.points = clientDetails.points;
            this.address = clientDetails.address;
            pointsText.text = clientDetails.points.ToString();
        }
    }

    public void OnClickItem()
    {
        EventHandler.OnItemClicked?.Invoke(clientName, points.ToString(), address);
    }
}
