using UnityEngine;
using DE = DataExchangeClient;

public class DataExchange : MonoBehaviour
{
    [SerializeField]
    private int m_Port;

    [SerializeField]
    private int m_BufferSize = 256;

    private DE.DataExchangeClient client;

    void Start()
    {
        client = new DE.DataExchangeClient(m_Port, m_BufferSize);
        client.Connect();

        InvokeRepeating("GetData", 0f, 1f);
    }

    void GetData()
    {
        Debug.Log("Get data..");
    }

    void OnApplicationQuit()
    {
        client.Close();
    }
}
