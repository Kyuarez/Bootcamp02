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
        //@tk : 걍 GCMode 바뀌면 호출되는 이벤트 ; 디버그 찍는 거인듯.
        GarbageCollector.GCModeChanged += (GarbageCollector.Mode mode) =>
        {
            Debug.Log("GCModeChanged: " + mode);
        };
    }

    static void EnableGC()
    {
        GarbageCollector.GCMode = GarbageCollector.Mode.Enabled; //GC 활성화
        GC.Collect(); //GC 전체 탐색 실행
        //GarbageCollector.CollectIncremental();//GC 점진적 실행
    }

    static void DisableGC()
    {
        GarbageCollector.GCMode = GarbageCollector.Mode.Disabled; //GC 비활성화
    }
    #endregion
}
