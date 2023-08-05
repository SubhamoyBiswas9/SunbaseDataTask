using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawLine : MonoBehaviour
{
    [SerializeField] GameObject linePrefab;
    [SerializeField] float minDist = 0.1f;

    Camera mainCamera;
    LineRenderer line;
    Vector3 previousPos;

    List<GameObject> lineObjects = new List<GameObject>();

    private void OnEnable()
    {
        EventHandler.OnRestartEvent += OnRestartEventCalled;
    }

    private void OnDisable()
    {
        EventHandler.OnRestartEvent -= OnRestartEventCalled;
    }

    private void Start()
    {
        mainCamera = Camera.main;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            line = Instantiate(linePrefab).GetComponent<LineRenderer>();
            previousPos = line.transform.position;
            line.positionCount = 1;

            lineObjects.Add(line.gameObject);
        }

        if (Input.GetMouseButton(0))
        {
            Vector3 currentPosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
            currentPosition.z = 0f;

            if (Vector3.Distance(currentPosition, previousPos) > minDist)
            {
                if (previousPos == transform.position)
                {
                    line.SetPosition(0, currentPosition);
                }
                else
                {
                    line.positionCount++;
                    line.SetPosition(line.positionCount - 1, currentPosition);
                }

                previousPos = currentPosition;
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            EventHandler.OnMouseUpEvent();
        }
    }

    void OnRestartEventCalled()
    {
        foreach(GameObject line in lineObjects)
        {
            Destroy(line);
        }
        lineObjects.Clear();
    }
}
