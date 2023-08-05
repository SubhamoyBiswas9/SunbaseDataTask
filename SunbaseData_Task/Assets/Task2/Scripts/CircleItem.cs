using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleItem : MonoBehaviour
{
    bool interactable = true;

    private void OnMouseEnter()
    {
        if (interactable && Input.GetMouseButton(0))
        {
            interactable = false;
            EventHandler.OnCrossed?.Invoke(gameObject);
        }
    }

    private void OnMouseExit()
    {
        if (interactable && Input.GetMouseButton(0))
        {
            interactable = false;
            EventHandler.OnCrossed?.Invoke(gameObject);
        }
    }
}
