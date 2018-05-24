using System;

namespace LabWork1.Solution
{
    public class Algorithms : IAlgorithms
    { 
        private int[] array;
        public int numberOfPositives;
        public int numberOfNegatives;
        public double average;
        public void Algorithm()
        {
            for(int i = 0; i < array.Length; i++)
            {
                average += array[i];
                if (array[i] < 0)
                {
                    numberOfNegatives++;
                }
                else
                {
                    numberOfPositives++;
                }
            }
            average = (double)average / array.Length;
        }

        public int[] GetArray()
        {
            return array;
        }

        public int GetNumberOfPositives()
        {
            return numberOfPositives;
        }

        public int GetNumberOfNegatives()
        {
            return numberOfNegatives;
        }

        public double GetAverage()
        {
            return average;
        }

        public Algorithms(int[] array)
        {
            this.array = array;
        }

        public Algorithms()
        {
        }
    }
}
