using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace algo0407
{
    public class LinearList
    {
        private int[] _container = null;
        private int _size = 0;

        public int this[int index]
        {
            get 
            { 
                return _container[index]; 
            }
            set
            {
                _container[index] = value;
            }
        }

        private void ResizeContainer()
        {

        }

        public void Add(int data)
        {

        }

        public void Insert(int index, int data)
        {

        }
        
        public int IndexOf(int data)
        {
            return 0;
        }

        public void RemoveAt(int index) 
        {

        } 
    }
}
