using UnityEngine;

namespace Bootcamp0212
{
    public interface ISubject
    {
        void Add(Observer observer);
        void Remove(Observer observer);
        void Notify();

    }

    public abstract class Observer
    {
        public abstract void OnNotify();
    }

    public class Observer01 : Observer
    {
        public override void OnNotify()
        {
            throw new System.NotImplementedException();
        }
    }
    public class Observer02 : Observer
    {
        public override void OnNotify()
        {
            throw new System.NotImplementedException();
        }
    }

}

