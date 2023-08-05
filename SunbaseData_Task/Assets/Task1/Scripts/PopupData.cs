using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using DG.Tweening;

public class PopupData : MonoBehaviour
{
    [SerializeField] TMP_Text labelText;
    [SerializeField] TMP_Text idText;
    [SerializeField] TMP_Text isManagerText;

    [SerializeField] RectTransform rectTransform;

    [SerializeField] float scaleDuration = .1f;

    private void OnEnable()
    {
        rectTransform.localScale = Vector3.zero;
        rectTransform.DOScale(1, scaleDuration);
    }

    public void AssignData(int id, string label, bool isManager)
    {
        labelText.text = "Label : " + label;
        idText.text = "ID : "+ id.ToString();
        isManagerText.text = "IsManager : " + isManager.ToString();
    }
}
