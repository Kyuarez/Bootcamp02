using System.Collections.Generic;
using UnityEngine;

namespace Bootcamp0212
{
    public class UsingObserver2 : MonoBehaviour, ISubject
    {
        List<Observer> observers = new List<Observer>();

        public void Add(Observer observer)
        {
            observers.Add(observer);
        }

        public void Notify()
        {
            foreach (Observer observer in observers) 
            {
                observer.OnNotify();
            }
        }

        public void Remove(Observer observer)
        {
            observers.Remove(observer);
        }

        void Start()
        {
            Observer01 ob1 = new Observer01();
            Observer02 ob2 = new Observer02();

            Add(ob1);
            Add(ob2);
        }
    }
}


