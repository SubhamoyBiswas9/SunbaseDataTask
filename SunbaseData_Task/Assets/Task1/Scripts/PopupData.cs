using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using DG.Tweening;

public class PopupData : MonoBehaviour
{
    [SerializeField] TMP_Text nameText;
    [SerializeField] TMP_Text pointsText;
    [SerializeField] TMP_Text addressText;

    [SerializeField] RectTransform rectTransform;

    [SerializeField] float scaleDuration = .1f;

    private void OnEnable()
    {
        rectTransform.localScale = Vector3.zero;
        rectTransform.DOScale(1, scaleDuration);
    }

    public void AssignData(string name = "N/A", string points = "N/A", string address = "N/A")
    {
        nameText.text = "Name : " + name;
        pointsText.text = "Points : " + points;
        addressText.text = "Address : " + address;
    }
}
