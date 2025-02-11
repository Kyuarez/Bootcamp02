using System;
using UnityEngine;
using UnityEngine.Scripting;

public class TestGC : MonoBehaviour
{
    #region Unity Document
    //reference : https://docs.unity3d.com/kr/2022.3/ScriptReference/Scripting.GarbageCollector.GCMode.html
    static void LogForGCModeChange()
    {
        //GCModeChanged : GC Event
        //@tk : �� GCMode �ٲ�� ȣ��Ǵ� �̺�Ʈ ; ����� ��� ���ε�.
        GarbageCollector.GCModeChanged += (GarbageCollector.Mode mode) =>
        {
            Debug.Log("GCModeChanged: " + mode);
        };
    }

    static void EnableGC()
    {
        GarbageCollector.GCMode = GarbageCollector.Mode.Enabled; //GC Ȱ��ȭ
        GC.Collect(); //GC ��ü Ž�� ����
        //GarbageCollector.CollectIncremental();//GC ������ ����
    }

    static void DisableGC()
    {
        GarbageCollector.GCMode = GarbageCollector.Mode.Disabled; //GC ��Ȱ��ȭ
    }
    #endregion
}
