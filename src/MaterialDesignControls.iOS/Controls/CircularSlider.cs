using CoreGraphics;
using Foundation;
using System;
using System.Collections.Generic;
using UIKit;

namespace Plugin.MaterialDesignControls.iOS.Controls
{
    public class CircularSlider : UIControl
    {
        //
        ////  EFCircularSlider.m
        ////  Awake
        ////
        ////  Created by Eliot Fowler on 12/3/13.
        ////  Copyright (c) 2013 Eliot Fowler. All rights reserved.
        ////

        ////#import "EFCircularSlider.h"
        ////#import <QuartzCore/QuartzCore.h>
        ////#import "EFCircularTrig.h"


        //@interface EFCircularSlider ()

        //@property (nonatomic) CGFloat radius;
        //@property (nonatomic) int     angleFromNorth;
        //@property (nonatomic, strong) NSMutableDictionary *labelsWithPercents;

        //@property (nonatomic, readonly) CGFloat handleWidth;
        //@property (nonatomic, readonly) CGFloat innerLabelRadialDistanceFromCircumference;
        //@property (nonatomic, readonly) CGPoint centerPoint;

        //@property (nonatomic, readonly) CGFloat radiusForDoubleCircleOuterCircle;
        //@property (nonatomic, readonly) CGFloat lineWidthForDoubleCircleOuterCircle;
        //@property (nonatomic, readonly) CGFloat radiusForDoubleCircleInnerCircle;
        //@property (nonatomic, readonly) CGFloat lineWidthForDoubleCircleInnerCircle;

        //@end

        public enum CircularSliderHandleType
        {
            CircularSliderHandleTypeSemiTransparentWhiteCircle,
            CircularSliderHandleTypeSemiTransparentBlackCircle,
            CircularSliderHandleTypeDoubleCircleWithOpenCenter,
            CircularSliderHandleTypeDoubleCircleWithClosedCenter,
            CircularSliderHandleTypeBigCircle
        };

        private static nfloat kFitFrameRadius = -1.0f;
        private nfloat _radius;
        private float _maximumValue;
        private float _minimumValue;
        private int _lineWidth;
        private UIColor _unfilledColor;
        private UIColor _filledColor;
        private UIFont _labelFont;
        private bool _snapToLabels;
        private CircularSliderHandleType _handleType;
        private UIColor _labelColor;
        private int _labelDisplacement;
        private int _angleFromNorth;
        private UIColor _handleColor;
        private List<string> _innerMarkingLabels;
        //private CGPoint _centerPoint;


        //@implementation EFCircularSlider

        //@synthesize radius = _radius;

        //#pragma mark - Initialisation
        public CircularSlider()
            : this(kFitFrameRadius)
        {

        }

        public CircularSlider(CGRect frame)
            : base(frame)
        {
            InitDefaultValuesWithRadius(kFitFrameRadius);
        }

        public CircularSlider(nfloat radius)
            : base()
        {
            InitDefaultValuesWithRadius(radius);

        }

        private void InitDefaultValuesWithRadius(nfloat radius)
        {
            _radius = radius;
            _maximumValue = 100.0f;
            _minimumValue = 0.0f;
            _lineWidth = 5;
            _unfilledColor = UIColor.Black;
            _filledColor = UIColor.Red;
            _labelFont = UIFont.SystemFontOfSize(10.0f);
            _snapToLabels = false;
            _handleType = CircularSliderHandleType.CircularSliderHandleTypeSemiTransparentWhiteCircle;
            _labelColor = UIColor.Red;
            _labelDisplacement = 0;

            _angleFromNorth = 0;
            _innerMarkingLabels = new List<string>();

            BackgroundColor = UIColor.Clear;
        }

        //#pragma mark - Public setter overrides
        public void SetLineWidth(int lineWidth)
        {
            _lineWidth = lineWidth;
            SetNeedsUpdateConstraints(); // This could affect intrinsic content size
            InvalidateIntrinsicContentSize(); // Need to update intrinsice content size
            SetNeedsDisplay();           // Need to redraw with new line width
        }

        public void SetHandleType(CircularSliderHandleType handleType)
        {
            _handleType = handleType;
            SetNeedsUpdateConstraints(); // This could affect intrinsic content size
            SetNeedsDisplay();           // Need to redraw with new handle type
        }

        public void SetFilledColor(UIColor filledColor)
        {
            _filledColor = filledColor;
            SetNeedsDisplay(); // Need to redraw with new filled color
        }

        public void SetUnfilledColor(UIColor unfilledColor)
        {
            _unfilledColor = unfilledColor;
            SetNeedsDisplay(); // Need to redraw with new unfilled color
        }


        public void SetLabelFont(UIFont labelFont)
        {
            _labelFont = labelFont;
            SetNeedsDisplay(); // Need to redraw with new label font
        }

        public void SetLabelColor(UIColor labelColor)
        {
            _labelColor = labelColor;
            SetNeedsDisplay(); // Need to redraw with new label color
        }

        public void SetInnerMarkingLabels(List<string> innerMarkingLabels)
        {
            _innerMarkingLabels = innerMarkingLabels;
            SetNeedsUpdateConstraints(); // This could affect intrinsic content size
            SetNeedsDisplay(); // Need to redraw with new label texts
        }

        public void SetMinimumValue(float minimumValue)
        {
            _minimumValue = minimumValue;
            SetNeedsDisplay(); // Need to redraw with updated value range
        }

        public void SetMaximumValue(float maximumValue)
        {
            _maximumValue = maximumValue;
            SetNeedsDisplay(); // Need to redraw with updated value range
        }

        ///**
        // *  There is no local variable currentValue - it is always calculated based on angleFromNorth
        // *
        // *  @param currentValue Value used to update angleFromNorth between minimumValue & maximumValue
        // */
        public void SetCurrentValue(nfloat currentValue)
        {
            //NSAssert(currentValue <= self.maximumValue && currentValue >= self.minimumValue,
            //         @"currentValue (%.2f) must be between self.minimuValue (%.2f) and self.maximumValue (%.2f)",
            //          currentValue, self.minimumValue, self.maximumValue);

            // Update the angleFromNorth to match this newly set value
            _angleFromNorth = (int)((currentValue * 360f) / (_maximumValue - _minimumValue));
            //sendActionsForControlEvents: UIControlEventValueChanged;
            SendActionForControlEvents(UIControlEvent.ValueChanged);
        }

        public void SetAngleFromNorth(int angleFromNorth)
        {
            _angleFromNorth = angleFromNorth;
            //NSAssert(_angleFromNorth >= 0, @"_angleFromNorth %d must be greater than 0", angleFromNorth);
        }

        public void SetRadius(nfloat radius)
        {
            _radius = radius;
            InvalidateIntrinsicContentSize(); // Need to update intrinsice content size
            SetNeedsDisplay(); // Need to redraw with new radius
        }

        //#pragma mark - Public getter overrides

        ///**
        // *  There is no local variable currentValue - it is always calculated based on angleFromNorth
        // *
        // *  @return currentValue Value between minimumValue & maximumValue derived from angleFromNorth
        // */
        public float CurrentValue
        {
            get { return (_angleFromNorth * (_maximumValue - _minimumValue)) / 360.0f; }
        }

        public nfloat Radius
        {
            get
            {
                if (_radius == kFitFrameRadius)
                {
                    // Slider is being used in frames - calculate the max radius based on the frame
                    //  (constrained by smallest dimension so it fits within view)
                    var minimumDimension = Math.Min(Bounds.Size.Height, Bounds.Size.Width);
                    int halfLineWidth = (int)Math.Ceiling(_lineWidth / 2.0);
                    int halfHandleWidth = (int)Math.Ceiling(HandleWidth / 2.0);
                    return (nfloat)(minimumDimension * 0.5 - Math.Max(halfHandleWidth, halfLineWidth));
                }
                return _radius;
            }
        }

        public UIColor HandleColor
        {
            get
            {
                var newHandleColor = _handleColor;
                switch (_handleType)
                {
                    case CircularSliderHandleType.CircularSliderHandleTypeSemiTransparentWhiteCircle:
                        {
                            newHandleColor = UIColor.FromWhiteAlpha(white: 1.0f, alpha: 0.7f);
                            break;
                        }
                    case CircularSliderHandleType.CircularSliderHandleTypeSemiTransparentBlackCircle:
                        {
                            newHandleColor = UIColor.FromWhiteAlpha(0.0f, alpha: 0.7f);
                            break;
                        }
                    case CircularSliderHandleType.CircularSliderHandleTypeDoubleCircleWithClosedCenter:
                    case CircularSliderHandleType.CircularSliderHandleTypeDoubleCircleWithOpenCenter:
                    case CircularSliderHandleType.CircularSliderHandleTypeBigCircle:
                        {
                            if (newHandleColor == null)
                            {
                                // handleColor public property hasn't been set - use filledColor
                                newHandleColor = _filledColor;
                            }
                            break;
                        }
                }

                return newHandleColor;
            }

            set
            {
                _handleColor = value;
                SetNeedsDisplay(); // Need to redraw with new handle color
            }
        }

        //#pragma mark - Private getter overrides

        public nfloat HandleWidth
        {
            get
            {
                switch (_handleType)
                {
                    case CircularSliderHandleType.CircularSliderHandleTypeSemiTransparentWhiteCircle:
                    case CircularSliderHandleType.CircularSliderHandleTypeSemiTransparentBlackCircle:
                        {
                            return _lineWidth;
                        }
                    case CircularSliderHandleType.CircularSliderHandleTypeBigCircle:
                        {
                            return _lineWidth + 15; // 5 points bigger than standard handles
                        }
                    case CircularSliderHandleType.CircularSliderHandleTypeDoubleCircleWithClosedCenter:
                    case CircularSliderHandleType.CircularSliderHandleTypeDoubleCircleWithOpenCenter:
                        {
                            return 2 * Utils.outerRadiuOfUnfilledArcWithRadius(radiusForDoubleCircleOuterCircle(), lineWidthForDoubleCircleOuterCircle());
                        }
                }

                return _lineWidth;
            }
        }

        nfloat radiusForDoubleCircleOuterCircle()
        {
            return 0.5f * _lineWidth + 5;
        }

        nfloat lineWidthForDoubleCircleOuterCircle()
        {
            return 4.0f;
        }

        nfloat radiusForDoubleCircleInnerCircle()
        {
            return 0.5f * _lineWidth;
        }

        nfloat lineWidthForDoubleCircleInnerCircle()
        {
            return 2.0f;
        }

        float innerLabelRadialDistanceFromCircumference()
        {
            // Labels should be moved far enough to clear the line itself plus a fixed offset (relative to radius).
            int distanceToMoveInwards = (int)(0.1f * -(_radius) - 0.5f * _lineWidth);
            distanceToMoveInwards -= (int)(0.5 * _labelFont.PointSize); // Also account for variable font size.
            return distanceToMoveInwards;
        }

        CGPoint CenterPoint
        {
            get { return new CGPoint(Bounds.Size.Width * 0.5, Bounds.Size.Height * 0.5); }
        }

        //#pragma mark - Method overrides

        public override CGSize IntrinsicContentSize
        {
            get
            {
                // Total width is: diameter + (2 * MAX(halfLineWidth, halfHandleWidth))
                int diameter = (int)(_radius * 2);
                int halfLineWidth = (int)(Math.Ceiling(_lineWidth / 2.0));
                int halfHandleWidth = (int)(Math.Ceiling(HandleWidth / 2.0));

                int widthWithHandle = diameter + (2 * Math.Max(halfHandleWidth, halfLineWidth));

                return new CGSize(widthWithHandle, widthWithHandle);
            }
        }

        public override void Draw(CGRect rect)
        {
            base.Draw(rect);

            var ctx = UIGraphics.GetCurrentContext();

            // Draw the circular lines that slider handle moves along
            DrawLine(ctx);

            // Draw the draggable 'handle'
            DrawHandle(ctx);

            // Add the labels
            DrawInnerLabels(ctx);
        }

        public override bool PointInside(CGPoint point, UIEvent uievent)
        {
            if (pointInsideHandle(point, uievent))
            {
                return true; // Point is indeed within handle bounds
            }
            return pointInsideCircle(point, uievent); // Return YES if point is inside slider's circle
        }

        private bool pointInsideCircle(CGPoint point, UIEvent uievent)
        {
            CGPoint p1 = CenterPoint;
            CGPoint p2 = point;
            nfloat xDist = (p2.X - p1.X);
            nfloat yDist = (p2.Y - p1.Y);
            double distance = Math.Sqrt((xDist * xDist) + (yDist * yDist));
            return distance < Radius + _lineWidth * 0.5;
        }

        private bool pointInsideHandle(CGPoint point, UIEvent uievent)
        {
            CGPoint handleCenter = pointOnCircleAtAngleFromNorth(_angleFromNorth);
            nfloat handleRadius = (nfloat)Math.Max(HandleWidth, 44.0) * 0.5f;
            // Adhere to apple's design guidelines - avoid making touch targets smaller than 44 points

            // Treat handle as a box around it's center
            var pointInsideHorzontalHandleBounds = (point.X >= handleCenter.X - handleRadius
                                                     && point.X <= handleCenter.X + handleRadius);
            var pointInsideVerticalHandleBounds = (point.Y >= handleCenter.Y - handleRadius
                                                     && point.Y <= handleCenter.Y + handleRadius);
            return pointInsideHorzontalHandleBounds && pointInsideVerticalHandleBounds;
        }

        //#pragma mark - Drawing methods

        private void DrawLine(CGContext ctx)
        {
            // Draw an unfilled circle (this shows what can be filled)
            //SetUnfilledColor(_unfilledColor);
            _unfilledColor.SetColor();

            Utils.drawUnfilledCircleInContext(ctx,
                                       center: CenterPoint,
                                       radius: Radius,
                                       lineWidth: _lineWidth);

            // Draw an unfilled arc up to the currently filled point
            //[self.filledColor set];
            //SetFilledColor(_filledColor);
            _filledColor.SetColor();
            Utils.drawUnfilledArcInContext(ctx,
                                              center: CenterPoint,
                                              radius: Radius,
                                           lineWidth: _lineWidth,
                                  fromAngleFromNorth: 0f,
                                    toAngleFromNorth: _angleFromNorth);
        }

        private void DrawHandle(CGContext ctx)
        {

            ctx.SaveState();
            CGPoint handleCenter = pointOnCircleAtAngleFromNorth(_angleFromNorth);

            // Ensure that handle is drawn in the correct color
            //[self.handleColor set];
            HandleColor.SetColor();

            switch (_handleType)
            {
                case CircularSliderHandleType.CircularSliderHandleTypeSemiTransparentWhiteCircle:
                case CircularSliderHandleType.CircularSliderHandleTypeSemiTransparentBlackCircle:
                case CircularSliderHandleType.CircularSliderHandleTypeBigCircle:
                    {
                        Utils.drawFilledCircleInContext(ctx,
                                                 center: handleCenter,
                        radius: 0.5f * HandleWidth);
                        break;
                    }
                case CircularSliderHandleType.CircularSliderHandleTypeDoubleCircleWithClosedCenter:
                case CircularSliderHandleType.CircularSliderHandleTypeDoubleCircleWithOpenCenter:
                    {
                        DrawUnfilledLineBehindDoubleCircleHandle(ctx);

                        // Draw unfilled outer circle
                        Utils.drawUnfilledCircleInContext(ctx,
                            center: new CGPoint(handleCenter.X, handleCenter.Y),
                            radius: radiusForDoubleCircleOuterCircle(),
                            lineWidth: lineWidthForDoubleCircleOuterCircle());

                        if (_handleType == CircularSliderHandleType.CircularSliderHandleTypeDoubleCircleWithClosedCenter)
                        {
                            // Draw filled inner circle
                            Utils.drawFilledCircleInContext(ctx, center: handleCenter,
                                                               radius: Utils.outerRadiuOfUnfilledArcWithRadius(radiusForDoubleCircleInnerCircle(),
                                                                                                              lineWidthForDoubleCircleInnerCircle()));
                        }
                        else if (_handleType == CircularSliderHandleType.CircularSliderHandleTypeDoubleCircleWithOpenCenter)
                        {
                            // Draw unfilled inner circle
                            Utils.drawUnfilledCircleInContext(ctx,
                                                            center: new CGPoint(handleCenter.X, handleCenter.Y),
                                                            radius: radiusForDoubleCircleInnerCircle(),
                                                            lineWidth: lineWidthForDoubleCircleInnerCircle());
                        }

                        break;
                    }
            }

            ctx.RestoreState();
        }

        /**
 *  Draw unfilled line from left edge of handle to right edge of handle
 *  This is to ensure that the filled portion of the line doesn't show inside the double circle
 *  @param ctx Graphics Context within which to draw unfilled line behind handle
 */
        public void DrawUnfilledLineBehindDoubleCircleHandle(CGContext ctx)
        {
            nfloat degreesToHandleCenter = _angleFromNorth;
            // To determine where handle intersects the filledCircle, make approximation that arcLength ~ radius of handle outer circle.
            // This is a fine approximation whenever self.radius is sufficiently large (which it must be for this control to be usable)
            nfloat degreesDifference = Utils.DegreesForArcLength(radiusForDoubleCircleOuterCircle(), Radius);
            nfloat degreesToHandleLeftEdge = degreesToHandleCenter - degreesDifference;
            nfloat degreesToHandleRightEdge = degreesToHandleCenter + degreesDifference;

            ctx.SaveState();

            //[self.unfilledColor set];
            _unfilledColor.SetColor();

            Utils.drawUnfilledArcInContext(ctx, CenterPoint, Radius,
                                           _lineWidth,
                                  fromAngleFromNorth: degreesToHandleLeftEdge,
                                    toAngleFromNorth: degreesToHandleRightEdge);
            ctx.RestoreState();
        }

        public void DrawInnerLabels(CGContext ctx)
        {
            // Only draw labels if they have been set
            var labelsCount = _innerMarkingLabels.Count;
            if (labelsCount > 0)
            {
                //#if __IPHONE_OS_VERSION_MIN_REQUIRED >= __IPHONE_7_0
                NSDictionary attributes = NSDictionary.FromObjectAndKey(_labelFont, UIStringAttributeKey.Font);
                //#endif
                for (var i = 0; i < labelsCount; i++)
                {
                    // Enumerate through labels clockwise
                    var label = _innerMarkingLabels[i];

                    CGRect labelFrame = contextCoordinatesForLabelAtIndex(i);

                    //#if __IPHONE_OS_VERSION_MIN_REQUIRED >= __IPHONE_7_0
                    label.DrawString(labelFrame.Location, _labelFont);
                    //[label drawInRect:labelFrame withAttributes:attributes];
                    ////#else
                    //            _labelColor.SetFill();
                    //            //[self.labelColor setFill];
                    //            label.DrawString(labelFrame withFont:self.labelFont];
                    ////#endif
                }
            }
        }


        public CGRect contextCoordinatesForLabelAtIndex(int index)
        {
            var label = _innerMarkingLabels[index];

            // Determine how many degrees around the full circle this label should go
            nfloat percentageAlongCircle = (index + 1) / (nfloat)_innerMarkingLabels.Count;
            nfloat degreesFromNorthForLabel = percentageAlongCircle * 360;
            CGPoint pointOnCircle = pointOnCircleAtAngleFromNorth((nint)degreesFromNorthForLabel);

            CGSize labelSize = SizeOfString(new NSString(label), _labelFont);
            CGPoint offsetFromCircle = offsetFromCircleForLabelAtIndex((nint)index, labelSize);

            return new CGRect(pointOnCircle.X + offsetFromCircle.X, pointOnCircle.Y + offsetFromCircle.Y, labelSize.Width, labelSize.Height);
        }

        private CGPoint offsetFromCircleForLabelAtIndex(nint index, CGSize labelSize)
        {
            // Determine how many degrees around the full circle this label should go
            nfloat percentageAlongCircle = (index + 1) / (nfloat)_innerMarkingLabels.Count;
            nfloat degreesFromNorthForLabel = percentageAlongCircle * 360;

            nfloat radialDistance = innerLabelRadialDistanceFromCircumference() + _labelDisplacement;
            CGPoint inwardOffset = Utils.pointOnRadius(radialDistance, degreesFromNorthForLabel);

            return new CGPoint(-labelSize.Width * 0.5 + inwardOffset.X, -labelSize.Height * 0.5 + inwardOffset.Y);
        }


        // #pragma mark - UIControl functions


        public override bool ContinueTracking(UITouch uitouch, UIEvent uievent)
        {
            base.ContinueTracking(uitouch, uievent);

            CGPoint lastPoint = uitouch.LocationInView(this);
            MoveHandle(lastPoint);

            SendActionForControlEvents(UIControlEvent.ValueChanged);

            return true;
        }

        public override void EndTracking(UITouch uitouch, UIEvent uievent)
        {
            base.EndTracking(uitouch, uievent);

            if (_snapToLabels && _innerMarkingLabels != null)
            {
                CGPoint bestGuessPoint = CGPoint.Empty;
                nfloat minDist = 360;
                int labelsCount = _innerMarkingLabels.Count;

                for (var i = 0; i < labelsCount; i++)
                {
                    nfloat percentageAlongCircle = i / (nfloat)labelsCount;
                    nfloat degreesForLabel = percentageAlongCircle * 360;
                    if (Math.Abs(_angleFromNorth - degreesForLabel) < minDist)
                    {
                        minDist = (nfloat)Math.Abs(_angleFromNorth - degreesForLabel);
                        bestGuessPoint = pointOnCircleAtAngleFromNorth((int)degreesForLabel);
                    }
                }
                _angleFromNorth = (int)Math.Floor(Utils.angleRelativeToNorthFromPoint(CenterPoint, toPoint: bestGuessPoint));
                SetNeedsDisplay();
            }
        }

        private void MoveHandle(CGPoint point)
        {
            _angleFromNorth = (int)Math.Floor(Utils.angleRelativeToNorthFromPoint(CenterPoint, point));
            SetNeedsDisplay();
        }

        //#pragma mark - Helper functions
        public bool IsDoubleCircleHandle
        {
            get
            {
                return _handleType == CircularSliderHandleType.CircularSliderHandleTypeDoubleCircleWithClosedCenter ||
                       _handleType == CircularSliderHandleType.CircularSliderHandleTypeDoubleCircleWithOpenCenter;
            }
        }

        private CGSize SizeOfString(NSString nsString, UIFont font)
        {
            NSDictionary attributes = NSDictionary.FromObjectAndKey(font, UIStringAttributeKey.Font);
            return new NSAttributedString(nsString, attributes).Size;
        }

        private CGPoint pointOnCircleAtAngleFromNorth(nint angleFromNorth)
        {
            CGPoint offset = Utils.pointOnRadius(Radius, angleFromNorth);
            return new CGPoint(CenterPoint.X + offset.X, CenterPoint.Y + offset.Y);
        }


    }

    internal class Utils
    {
        private static nfloat SQR(nfloat x)
        {
            return x * x;
        }

        private static double CartesianToCompass(double rad)
        {
            return (rad + Math.PI / 2);
        }

        private static double CompassToCartesian(double rad)
        {
            return (rad - Math.PI / 2);
        }

        public static double angleRelativeToNorthFromPoint(CGPoint fromPoint, CGPoint toPoint)
        {
            CGPoint v = new CGPoint(toPoint.X - fromPoint.X, toPoint.Y - fromPoint.Y);
            var vmag = (nfloat)Math.Sqrt(SQR(v.X) + SQR(v.Y));
            v.X /= vmag;
            v.Y /= vmag;
            var cartesianRadians = Math.Atan2(v.Y, v.X);
            // Need to convert from cartesian style radians to compass style
            double compassRadians = CartesianToCompass(cartesianRadians);
            if (compassRadians < 0)
            {
                compassRadians += 2 * Math.PI;
            }
            //NSAssert(compassRadians >= 0 && compassRadians <= 2*Math.PI, @"angleRelativeToNorth should be always positive");
            return ConvertToDegrees(compassRadians);
        }

        private static double ConvertToRadians(double angle)
        {
            return (Math.PI / 180) * angle;
        }


        public static double ConvertToDegrees(double val)
        {

            return val * (180.0 / Math.PI);

        }

        public static CGPoint pointOnRadius(nfloat radius, nfloat angleFromNorth)
        {
            //Get the point on the circle for this angle

            // Need to adjust from 'compass' style angle to cartesian angle
            var cartesianAngle = CompassToCartesian(ConvertToRadians(angleFromNorth));
            CGPoint result = new CGPoint();
            result.X = (nfloat)Math.Round(radius * Math.Cos(cartesianAngle));
            result.Y = (nfloat)Math.Round(radius * Math.Sin(cartesianAngle));

            return result;
        }

#pragma mark - Draw arcs

        public static void drawFilledCircleInContext(CGContext ctx, CGPoint center, nfloat radius)
        {
            ctx.FillEllipseInRect(new CGRect(center.X - (radius), center.Y - (radius), 2 * radius, 2 * radius));
        }

        public static void drawUnfilledCircleInContext(CGContext ctx, CGPoint center, nfloat radius, nfloat lineWidth)
        {
            drawUnfilledArcInContext(ctx, center, radius: radius, lineWidth: lineWidth, fromAngleFromNorth: 0, toAngleFromNorth: 360); // 0 - 360 is full circle
        }

        public static void drawUnfilledArcInContext(CGContext ctx, CGPoint center, nfloat radius, nfloat lineWidth, nfloat fromAngleFromNorth, nfloat toAngleFromNorth)
        {
            var cartesianFromAngle = (nfloat)CompassToCartesian(ConvertToRadians(fromAngleFromNorth));
            var cartesianToAngle = (nfloat)CompassToCartesian(ConvertToRadians(toAngleFromNorth));

            ctx.AddArc(center.X,   // arc start point x
                            center.Y,   // arc start point y
                            radius,     // arc radius from center
                            cartesianFromAngle, cartesianToAngle,
                            false); // iOS flips the y coordinate so anti-clockwise (specified here by 0) becomes clockwise (desired)!

            ctx.SetLineWidth(lineWidth);
            ctx.SetLineCap(CGLineCap.Butt);
            ctx.DrawPath(CGPathDrawingMode.Stroke);
        }

        public static nfloat DegreesForArcLength(nfloat arcLength, nfloat radius)
        {
            var totalCircumference = 2 * Math.PI * radius;

            var arcRatioToCircumference = arcLength / totalCircumference;

            return (nfloat)(360 * arcRatioToCircumference); // If arcLength is exactly half circumference, that is exactly half a circle in degrees
        }


        #region - Calculate radii of arcs with line widths
        /*
 *  For an unfilled arc.
 *
 *  Radius of outer arc (center to outside edge)  |          ---------
 *      = radius + 0.5 * lineWidth                |      +++++++++++++++
 *                                                |    /++/++++ --- ++++\++\
 *  Radius of inner arc (center to inside edge)   |   /++/++/         \++\++\
 *      = radius - (0.5 * lineWidth)              |  |++|++|     .     |++|++|
 *                                         outer edge^  ^-radius-^     ^inner edge
 *
 */
        public static nfloat outerRadiuOfUnfilledArcWithRadius(nfloat radius, nfloat lineWidth)
        {
            return radius + 0.5f * lineWidth;
        }

        public static nfloat innerRadiusOfUnfilledArcWithRadius(nfloat radius, nfloat lineWidth)
        {
            return radius - 0.5f * lineWidth;
        }
        #endregion

    }
}