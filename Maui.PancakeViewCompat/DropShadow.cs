﻿using System.Runtime.CompilerServices;

namespace PancakeView
{
    public class DropShadow : BindableObject
    {
        public static readonly BindableProperty BlurRadiusProperty = BindableProperty.Create(
            nameof(BlurRadius), typeof(float), typeof(DropShadow), 10.0f);

        public float BlurRadius
        {
            get => (float)GetValue(BlurRadiusProperty);
            set
            {
                if (value < 0)
                    throw new ArgumentException($"{nameof(BlurRadius)} must be a positive value.", nameof(BlurRadius));

                SetValue(BlurRadiusProperty, value);
            }
        }

        public static readonly BindableProperty OpacityProperty = BindableProperty.Create(
            nameof(Opacity), typeof(float), typeof(DropShadow), 0.4f);

        public float Opacity
        {
            get => (float)GetValue(OpacityProperty);
            set
            {
                if (value < 0 || value > 1)
                    throw new ArgumentException($"{nameof(Opacity)} must be a value between 0 and 1.", nameof(Opacity));

                SetValue(OpacityProperty, value);
            }
        }

        public static readonly BindableProperty ColorProperty = BindableProperty.Create(
            nameof(Color), typeof(Color), typeof(DropShadow), Colors.Black);

        public Color Color
        {
            get => (Color)GetValue(ColorProperty);
            set => SetValue(ColorProperty, value);
        }

        public static readonly BindableProperty OffsetProperty = BindableProperty.Create(
            nameof(Offset), typeof(Point), typeof(DropShadow), default(Point));

        public Point Offset
        {
            get => (Point)GetValue(OffsetProperty);
            set => SetValue(OffsetProperty, value);
        }

        protected override void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            base.OnPropertyChanged(propertyName);

            if (propertyName == OffsetProperty.PropertyName ||
                propertyName == ColorProperty.PropertyName ||
                propertyName == BlurRadiusProperty.PropertyName ||
                propertyName == OpacityProperty.PropertyName)
            {
                OnPropertyChanged(PancakeView.ShadowProperty.PropertyName);
            }
        }
    }
}
