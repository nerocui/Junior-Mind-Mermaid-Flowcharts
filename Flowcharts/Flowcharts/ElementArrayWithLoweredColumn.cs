﻿using System;
using System.Linq;

namespace Flowcharts
{
    class ElementArrayWithLoweredColumn
    {
        Element[,] ElementArray;
        readonly double row;
        readonly int column;
        readonly int positions;

        public ElementArrayWithLoweredColumn(IGrid grid, double row, int column, int positions)
        {
            ElementArray = grid.ElementArray;
            this.row = row;
            this.column = column;
            this.positions = positions;
        }

        public ElementArrayWithLoweredColumn(Element[,] ElementArray, double row, int column, int positions)
        {
            this.ElementArray = ElementArray;            
            this.row = row;
            this.column = column;
            this.positions = positions;
        }

        private void LowerColumnInGrid()
        {
            if (positions == 0)
            {
                return;
            }

            var extractedColumn = new ExtractedColumn(ElementArray, column).GetColumn();
            int emptyPositionsAtTheEnd = extractedColumn.Reverse().TakeWhile(x => x == null).Count();

            int difference = positions - emptyPositionsAtTheEnd;

            if (difference > 0)
            {
                ElementArray = new ResizedElementArray(ElementArray, ElementArray.GetLength(0) + difference, ElementArray.GetLength(1)).GetArray();
            }

            for (int i = ElementArray.GetLength(0) - 1; i >= row; i--)
            {
                if (ElementArray[i, column] != null)
                {
                    if (ElementArray[i + positions, column] != null)
                    {
                        throw new InvalidOperationException("Cannot move. Space is not empty");
                    }

                    ElementArray[i + positions, column] = ElementArray[i, column];
                    ElementArray[i, column] = null;
                }
            }
        }

        public Element[,] Get()
        {
            LowerColumnInGrid();
            return ElementArray;
        }
    }
}