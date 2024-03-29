﻿using System;
using System.Collections.Generic;

namespace Organizer
{
	public class RotateSort
	{

        private List<int> array = new List<int>();

        /// <summary>
        /// Sort an array using the functions below
        /// </summary>
        /// <param name="input">The unsorted array</param>
        /// <returns>The sorted array</returns>
        public List<int> Sort(List<int> input)
        {
            array = new List<int>(input);

            SortFunction(0, array.Count - 1);
            return array;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="low">De index within this.array to start with</param>
        /// <param name="high">De index within this.array to stop with</param>
        private void SortFunction(int low, int high)
        {
            if (low >= high)
                return;

            //rotatiegetal kiezen, het middelste element
            int pivotIndex = (low + high) / 2;
            int pivot = array[pivotIndex];

            //splits array rond rotatiegetal
            int splitPoint = Partitioning(low, high, pivot);

            //Recursief de linkerhelft sorteren
            SortFunction(low, splitPoint -1);

            //Recursief de rechterhelft sorteren
            SortFunction(splitPoint, high);
        }

        /// 
        /// Partition the array in a group 'low' digits (e.a. lower than a chosen pivot) and a group 'high' digits
        /// </summary>
        /// <param name="low">De index within this.array to start with</param>
        /// <param name="high">De index within this.array to stop with</param>
        /// <returns>The index in the array of the first of the 'high' digits</returns>
        private int Partitioning(int low, int high, int pivot) {
            while (low <= high) {
                //First element van linkerhelft groter of gelijk aan rotatiegetal
                while (array[low] < pivot) {
                    low++;
                }

                //Vindt eerste element van rechterhelft kleiner of gelijk aan rotatiegetal
                while (array[high] > pivot) {
                    high--;
                }

                //swap als de pivots niet gekruist hebben
                if (low <= high) {
                    int temp = array[low];
                    array[low] = array[high];
                    array[high] = temp;
                    low++;
                    high--;
                }
            }
            return low;
        }
    }
}
