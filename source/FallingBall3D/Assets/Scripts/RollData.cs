using System;
using UnityEditor;
using UnityEngine;

public class RollData : ScriptableObject
{
    public event Action<int> XAngleUpdated = delegate { };
    public event Action<int> ZAngleUpdated = delegate { };

    public int XAngle;
    public int ZAngle;

    [MenuItem("Custom/Create/New roll data instance", false, 1)]
    public static void CreateRollData()
    {
        RollData data = ScriptableObject.CreateInstance<RollData>();
        AssetDatabase.CreateAsset(data, "Assets/New roll data.asset");
        AssetDatabase.Refresh();
    }

    public void SetXAngle(int angle)
    {
        if (XAngle != angle)
        {
            XAngle = angle;
            XAngleUpdated(XAngle);
        }
    }

    public void SetZAngle(int angle)
    {
        if (ZAngle != angle)
        {
            ZAngle = angle;
            ZAngleUpdated(ZAngle);
        }
    }
}
