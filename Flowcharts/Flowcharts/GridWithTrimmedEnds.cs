﻿namespace Flowcharts
{
    class GridWithTrimmedEnds : IGrid
    {
        public Element[,] ElementArray { get; private set; }

        public GridWithTrimmedEnds(IGrid grid)
        {
            ElementArray = ArrayOperations.CloneArray(grid);
            RemoveNullColumnsAndRowsAtTheEnds();
        }

        public void RemoveNullColumnsAndRowsAtTheEnds()
        {
            var emptyRows = ArrayOperations.GetEmptyRows(ElementArray);

            ElementArray = ArrayOperations.RaiseAllRows(ElementArray, emptyRows);
            ElementArray = ArrayOperations.EliminateEmptyRows(ElementArray, emptyRows.Count);                                   
        }
    }
}