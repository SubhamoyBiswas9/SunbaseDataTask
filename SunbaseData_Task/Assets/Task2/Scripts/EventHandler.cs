using System;
using UnityEngine;

public class EventHandler
{
    public static Action<GameObject> OnCrossed;
    public static Action OnMouseUpEvent;
    public static Action OnRestartEvent;
    public static Action<JsonData> OnDataFetched;
    public static Action<int, string, bool> OnItemClicked;
}
