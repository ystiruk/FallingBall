using UnityEngine;

public class PlaneController : MonoBehaviour
{
    [SerializeField]
    private RollData m_PlaneRollData;

    private Transform plane;

    void Start()
    {
        plane = GetComponent<Transform>();

        m_PlaneRollData.XAngleUpdated += M_PlaneRollData_XAngleUpdated;
        m_PlaneRollData.ZAngleUpdated += M_PlaneRollData_ZAngleUpdated;
    }

    private void M_PlaneRollData_ZAngleUpdated(int obj)
    {
        plane.localRotation = Quaternion.Euler(0, 0, obj);
    }

    private void M_PlaneRollData_XAngleUpdated(int obj)
    {
        plane.localRotation = Quaternion.Euler(obj, 0, 0);
    }
}
