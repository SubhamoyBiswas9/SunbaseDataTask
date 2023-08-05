using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using Newtonsoft.Json;

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

            //JsonData data = JsonUtility.FromJson<JsonData>(request.downloadHandler.text);

            JsonData data = JsonConvert.DeserializeObject<JsonData>(request.downloadHandler.text);

            EventHandler.OnDataFetched?.Invoke(data);
        }
    }
}
[System.Serializable]
public class JsonData
{
    public List<ClientData> clients;
    public Data data;
    string label;
}

public class ClientData
{
    public bool isManager;
    public int id;
    public string label;
}
[System.Serializable]
public class Data
{
    [JsonProperty("1")]
    public Details detail1;
    [JsonProperty("2")]
    public Details detail2;
    [JsonProperty("3")]
    public Details detail3;
}

public class Details
{
    public string address;
    public string name;
    public int points;
}
