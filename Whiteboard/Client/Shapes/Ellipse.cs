﻿/**
 * Owned By: Parul Sangwan
 * Created By: Parul Sangwan
 * Date Created: 11/01/2021
 * Date Modified: 11/02/2021
**/


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Whiteboard
{
    public class Ellipse : MainShape
    {
        /// <summary>
        /// Constructor setting just the basic attributes of Ellipse.
        /// </summary>
        /// <param name="height">Hright of Ellipse.</param>
        /// <param name="width">Width of Ellipse.</param>
        /// <param name="start">The left botton coordinate of the smallest rectangle enclosing the shape.</param>
        public Ellipse(int height, int width, Coordinate start, Coordinate center) : base(ShapeType.ELLIPSE)
        {
            this.Height = height;
            this.Width = width;
            this.Center = center;
            this.Start = start.Clone();
        }

        /// <summary>
        /// Constructor to create an ellipse.
        /// </summary>
        /// <param name="height">Height of ellipse.</param>
        /// <param name="width">Width of ellipse.</param>
        /// <param name="strokeWidth">Stroke Width/</param>
        /// <param name="strokeColor">Stroke Color.</param>
        /// <param name="shapeFill">Fill color of the shape.</param>
        /// <param name="start">The left bottom coordinate of the smallest rectangle enclosing the shape.</param>
        /// <param name="points">List of points, if any.</param>
        /// <param name="angle">Angle of Rotation.</param>
        public Ellipse(int height, 
                       int width, 
                       float strokeWidth, 
                       BoardColor strokeColor, 
                       BoardColor shapeFill, 
                       Coordinate start,
                       Coordinate center,
                       List<Coordinate> points,
                       float angle) :
                       base(ShapeType.ELLIPSE, height, width, strokeWidth, strokeColor, shapeFill, start, center, points, angle)
        {
        }

        /// <summary>
        /// Default constructor.
        /// </summary>
        public Ellipse() : base(ShapeType.ELLIPSE)
        {
        }

        /// <summary>
        /// Creates/ modifies the previous shape.
        /// </summary>
        /// <param name="start">Start of mouse drag.</param>
        /// <param name="end">End of mouse drag.</param>
        /// <param name="prevEllipse">Previous ellipse object to modify.</param>
        /// <returns>Create/modified Ellipse object.</returns>
        public override MainShape ShapeMaker (Coordinate start, Coordinate end, MainShape prevEllipse = null)
        {
            if (prevEllipse == null)
            {
                int height = Math.Abs(start.R - end.R);
                int width = Math.Abs(start.C - end.C);
                Coordinate center = (end - start) / 2;
                return new Ellipse(height, width, start, center);
            }
            else
            {

                prevEllipse.Height = Math.Abs(end.R - prevEllipse.Start.R);
                prevEllipse.Width = Math.Abs(end.C - prevEllipse.Start.C);
                prevEllipse.Center = (end - prevEllipse.Start) / 2;
                return prevEllipse;
            }
        }

        /// <summary>
        /// Creating clone object of this class.
        /// </summary>
        /// <returns>Clone of shape.</returns>
        public override MainShape Clone()
        {
            return new Ellipse(Height, Width, StrokeWidth, StrokeColor, ShapeFill, Start, Center, new List<Coordinate> (), AngleOfRotation);
        }

    }
}
