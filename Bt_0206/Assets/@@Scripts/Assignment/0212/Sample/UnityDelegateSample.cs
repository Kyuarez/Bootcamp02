using System;
using UnityEngine;
using UnityEngine.Events;

namespace Bootcamp0212
{
    public class UnityDelegateSample : MonoBehaviour
    {
        Action action;
        Action<int> action2;
        Action<int, int> action3;

        Func<int, int> func01;
        Func<int, int, string> func02;

        private void Start()
        {
            action += Sample;
            action2 += Sample01;
            action3 += Sample02;

            func01 += FuncSample01;
            func02 += FuncSample02;

            func01 += (int a) => { return a + 1; };

            func02 += (int a, int b) => {
                
                return (a + b).ToString();
            };
            
        }

        public int FuncSample01(int a)
        {
            return 0;
        }
        public string FuncSample02(int a, int b)
        {
            return null;
        }

        public void Sample()
        {

        }

        public void Sample01(int a)
        {

        }

        public void Sample02(int a, int b) 
        {

        }
    }

}

