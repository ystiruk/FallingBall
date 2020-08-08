using UnityEngine;
using DE = DataExchangeClient;

public class DataExchange : MonoBehaviour
{
    [SerializeField]
    private int m_Port;

    [SerializeField]
    private int m_BufferSize = 256;

    [SerializeField]
    private float m_UpdatePeriod = 2f;

    [SerializeField]
    private RollData m_PlaneRollData;

    private DE.DataExchangeClient client;

    void Start()
    {
        client = new DE.DataExchangeClient(m_Port, m_BufferSize);
        client.Connect();

        InvokeRepeating("GetData", 0f, m_UpdatePeriod);
    }

    void GetData()
    {
        Debug.Log("Get data..");

        client.Send("yaw");
        int x = int.Parse(client.Receive());
        Debug.Log("x = " + x);
        m_PlaneRollData.SetXAngle(x);

        client.Send("yaw");
        int z = int.Parse(client.Receive());
        Debug.Log("z = " + z);
        m_PlaneRollData.SetZAngle(z);
    }

    void OnApplicationQuit()
    {
        client.Close();
    }
}
