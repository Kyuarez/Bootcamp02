using UnityEngine;
using System;
using System.Collections.Generic;

namespace Bootcamp0206 
{
    public class SampleData
    {
        public int i;
        public float f;
        public bool b;
        public Vector3 v;
        public string s;
        public int[] iArr;
        public List<int> iList;
    }

    public class JsonExample : MonoBehaviour
    {
        void Start()
        {
            SampleData sample = new SampleData();
            sample.i = 0;
            sample.f = 1.0f;
            sample.b = true;
            sample.v = new Vector3(1.0f, 1.0f, 1.0f);
            sample.s = "lio";
            sample.iArr = new int[5] { 1, 2, 3, 4, 5 };
            sample.iList = new List<int> { 1, 2, 3};

            string jsonData = JsonUtility.ToJson(sample);   
            Debug.Log(jsonData);

            Debug.Log("--------------------------------------");

            var jsonData2 = JsonUtility.FromJson<SampleData>(jsonData);
            Debug.Log(jsonData2.i);
            Debug.Log(jsonData2.f);
            Debug.Log(jsonData2.b);
            Debug.Log(jsonData2.v);

        }

        void Update()
        {
        
        }
    }

}

