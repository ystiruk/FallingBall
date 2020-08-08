using System.Collections;
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

    IEnumerator RotateInTime(Vector3 byAngles, float inTime)
    {
        var fromAngle = transform.rotation;
        var toAngle = Quaternion.Euler(/*transform.eulerAngles + */byAngles);
        for (var t = 0f; t < 1; t += Time.deltaTime / inTime)
        {
            transform.rotation = Quaternion.Lerp(fromAngle, toAngle, t);
            yield return null;
        }
    }

    private void M_PlaneRollData_ZAngleUpdated(int obj)
    {
        //plane.localRotation = Quaternion.Euler(0, 0, obj);
        StartCoroutine(RotateInTime(Vector3.right * obj, 1.5f));
    }

    private void M_PlaneRollData_XAngleUpdated(int obj)
    {
        //plane.localRotation = Quaternion.Euler(obj, 0, 0);
        StartCoroutine(RotateInTime(Vector3.forward * obj, 1.5f));
    }
}
