﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace OOP2
{
    public class IntArray
    {
        private int[] array = new int[4];

        private int emptyPosition = -1;

        public IntArray()
        {
            this.array = new int[4];
        }

        public void Add(int element)
        {
            ResizeIfNeeded();

            array[emptyPosition] = element;
        }

        public int Count()
        {
            return array.Length;
        }

        public int Element(int index)
        {
            return array[index];
        }

        public void SetElement(int index, int element)
        {
            array[index] = element;
        }

        public bool Contains(int element)
        {
            return Array.Exists(array, item => item == element);
        }

        public int IndexOf(int element)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == element) 
                {
                    return i;
                }
            }

            return -1;
        }

        public void Insert(int index, int element)
        {
            ResizeIfNeeded();

            for (int i = array.Length - 1; i > index; i--)
            {
                array[i] = array[i - 1];
            }

            array[index] = element;
        }

        public void Clear()
        {
            array = new int[0];
            emptyPosition = -1;
        }

        public void Remove(int element)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == element)
                {
                    RemoveAt(i);
                    break;
                }
            }

            emptyPosition--;
        }

        public void RemoveAt(int index)
        {
            for (int i = index; i < array.Length - 1; i++)
            {
                array[i] = array[i + 1];                
            }

            emptyPosition--;
        }

        private void ResizeIfNeeded()
        {
            emptyPosition++;

            if (emptyPosition == array.Length)
            {
                Array.Resize(ref array, array.Length * 2);
            }
        }
    }
}