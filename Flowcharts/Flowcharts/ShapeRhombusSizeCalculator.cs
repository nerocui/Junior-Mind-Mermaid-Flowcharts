﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Flowcharts
{
    class ShapeRhombusSizeCalculator
    {
        readonly string[] lines;

        public ShapeRhombusSizeCalculator(string[] lines)
        {
            this.lines = lines;
        }

        public double Calculate()
        {
            var sizeOfText = new TextSizeCalculator(lines).Calculate();
            var maxLineLength = lines.Max(x => x.Length);

            if (maxLineLength == 1)
            {
                return 40;
            }
            else if (maxLineLength > 1 && maxLineLength <= 3)
            {
                return sizeOfText * 11 + 5;
            }
            else if (maxLineLength > 3 && maxLineLength <= 6)
            {
                return sizeOfText * 8.5 + 5;
            }

            return sizeOfText * 7.5;
        }
    }
}
