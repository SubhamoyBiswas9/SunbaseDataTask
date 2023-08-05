using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class DataHandler : MonoBehaviour
{

    [SerializeField] string apiURL;

    void Start()
    {
        StartCoroutine(FetchData());
    }

    IEnumerator FetchData()
    {
        using(UnityWebRequest request = UnityWebRequest.Get(apiURL))
        {
            yield return request.SendWebRequest();

            if (request.result != UnityWebRequest.Result.Success)
            {
                Debug.Log("Error while fetching data: " + request.error);
                yield break;
            }

            string responseData = request.downloadHandler.text;
            Debug.Log("API Response: " + request.downloadHandler.text);

            JsonData data = JsonUtility.FromJson<JsonData>(request.downloadHandler.text);

            EventHandler.OnDataFetched?.Invoke(data);
        }
    }
}
[System.Serializable]
public class JsonData
{
    public List<ClientData> clients;
    List<Data> data;
    string label;
}
[System.Serializable]
public class ClientData
{
    public bool isManager;
    public int id;
    public string label;
}

class Data
{
    string address;
    string name;
    int points;
}
