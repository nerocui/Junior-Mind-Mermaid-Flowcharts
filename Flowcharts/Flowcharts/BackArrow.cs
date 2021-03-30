﻿using System.Xml;

namespace Flowcharts
{
    class BackArrow : Arrow
    {
        public BackArrow(XmlWriter xmlWriter, Element fromElement, Element toElement, string text) : base(xmlWriter, fromElement, toElement, text)
        {
            this.xmlWriter = xmlWriter;
            this.fromElement = fromElement;
            this.toElement = toElement;
        }

        override public string[] GetArrowEnds()
        {
            string[] points = new string[6];

            points[0] = fromElement.In.x.ToString();
            points[1] = fromElement.In.y.ToString();

            double xMiddle = (fromElement.In.x + toElement.Out.x) / 2;
            double yMiddle = (fromElement.In.y + toElement.Out.y) / 2;

            double xDifference = (fromElement.In.x - toElement.Out.x);
            double yDifference = (toElement.Out.y - fromElement.In.y);

            double yAngleCorrection;
            double xAngleCorrection;

            if(typeof(OrientationLeftRight) == fromElement.orientation.GetType() || typeof(OrientationDownTop) == fromElement.orientation.GetType())
            {
                if(toElement.Row < fromElement.Row)
                {
                    yAngleCorrection = xDifference / 10;
                    xAngleCorrection = yDifference / 10;
                }
                else
                {
                    yAngleCorrection = - xDifference / 10;
                    xAngleCorrection = - yDifference / 10;
                }
            }
            else
            {
                if (toElement.Row >= fromElement.Row)
                {
                    yAngleCorrection = xDifference / 10;
                    xAngleCorrection = yDifference / 10;
                }
                else
                {
                    yAngleCorrection = -xDifference / 10;
                    xAngleCorrection = -yDifference / 10;
                }
            }

            points[2] = (xMiddle + xAngleCorrection).ToString();
            points[3] = (yMiddle + yAngleCorrection).ToString();

            if (typeof(OrientationLeftRight) == fromElement.orientation.GetType() || typeof(OrientationRightLeft) == fromElement.orientation.GetType())
            {
                points[4] = (toElement.Out.x + 5).ToString();
                points[5] = toElement.Out.y.ToString();
            }
            else
            {
                points[4] = toElement.Out.x.ToString();
                points[5] = (toElement.Out.y + 5).ToString();
            }


            return points;
        }

        override public void Draw()
        {
            new DrawnBackArrow(xmlWriter, fromElement, toElement, GetArrowEnds()).Draw();
        }
    }
}
