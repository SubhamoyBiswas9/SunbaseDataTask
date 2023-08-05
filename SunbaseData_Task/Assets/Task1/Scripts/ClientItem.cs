using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using DG.Tweening;

public class ClientItem : MonoBehaviour
{
    [SerializeField] TMP_Text idText;
    [SerializeField] TMP_Text labelText;

    [SerializeField] RectTransform rectTransform;
    [SerializeField] float scaleDuration = .2f;

    bool isManager; public bool _isManager { get => isManager; }

    int id;
    string label;

    private void OnEnable()
    {
        rectTransform.localScale = Vector3.zero;
        rectTransform.DOScale(1, scaleDuration);
    }

    public void Initialize(int id, string label,bool isManager)
    {
        this.id = id;
        this.label = label;
        idText.text = id.ToString();
        labelText.text = label;
        this.isManager = isManager;
    }

    public void OnClickItem()
    {
        EventHandler.OnItemClicked?.Invoke(id, label, isManager);
    }
}
