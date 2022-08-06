using System.Collections.Generic;
using System.Linq;

namespace Otus.GraphsSortings.Demucron.Logic
{
    public class DemucronAlgorithm
    {
        public int[][] Run(int[,] adjacencyMatrix)
        {
            var inclinationDegreeVector = GetInclinationDegreeVector(adjacencyMatrix);

            var levelCounter = 0;
            var result = new int[adjacencyMatrix.GetLength(0)][];
            while (!IsVectorEmpty(inclinationDegreeVector))
            {
                var currentSources = ProcessInclinationDegreeVector(inclinationDegreeVector, adjacencyMatrix);
                result[levelCounter++] = currentSources;
            }

            return result;
        }


        #region Support Methods

        private int?[] GetInclinationDegreeVector(int[,] adjacencyMatrix)
        {
            var result = new int?[adjacencyMatrix.GetLength(0)];

            for (var columnIndex = 0; columnIndex < result.Length; columnIndex++)
            {
                var counter = 0;
                for (var rowIndex = 0; rowIndex < adjacencyMatrix.GetLength(0); rowIndex++)
                {
                    counter += adjacencyMatrix[rowIndex, columnIndex];

                }

                result[columnIndex] = counter;
            }

            return result;
        }

        public bool IsVectorEmpty(int?[] inclinationDegreeVector)
        {
            return inclinationDegreeVector.All(x => x == null);
        }

        private int[] ProcessInclinationDegreeVector(int?[] inclinationDegreeVector, int[,] adjacencyMatrix)
        {
            var sourceIndexes = GetSourceIndexes(inclinationDegreeVector);

            foreach (var sourceIndex in sourceIndexes)
            {
                for (var columnIndex = 0; columnIndex < adjacencyMatrix.GetLength(0); columnIndex++)
                {
                    if (inclinationDegreeVector[columnIndex].GetValueOrDefault() == 0)
                        continue;

                    inclinationDegreeVector[columnIndex] = inclinationDegreeVector[columnIndex] - adjacencyMatrix[sourceIndex, columnIndex];
                }
            }

            return sourceIndexes.ToArray();
        }

        private static List<int> GetSourceIndexes(int?[] inclinationDegreeVector)
        {
            var sourceIndexes = new List<int>();

            for (var i = 0; i < inclinationDegreeVector.Length; i++)
            {
                if (inclinationDegreeVector[i] == 0)
                {
                    inclinationDegreeVector[i] = null;
                    sourceIndexes.Add(i);
                }
            }

            return sourceIndexes;
        }

        #endregion
    }
}
