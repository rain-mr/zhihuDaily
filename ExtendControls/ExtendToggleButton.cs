﻿using System;
using System.Collections.Generic;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;

namespace ExtendControls
{
    public sealed class ExtendToggleButton : ToggleButton
    {
        private ContentControl _symbol;
        private Viewbox _symbolView;
        private RelativePanel _visualPanel;
        private ContentPresenter _contentPresenter;

        private ExtendButtonCommon _common = new ExtendButtonCommon();

        public event ToggleEvent OnToggleChanged;

        #region property

        public IconElement Icon
        {
            get { return (IconElement)GetValue(IconProperty); }
            set { SetValue(IconProperty, value); }
        }
        public static readonly DependencyProperty IconProperty =
            DependencyProperty.Register("Icon", typeof(IconElement), typeof(ExtendToggleButton), null);

        public double IconSize
        {
            get { return (double)GetValue(IconSizeProperty); }
            set { SetValue(IconSizeProperty, value); }
        }
        public static readonly DependencyProperty IconSizeProperty =
            DependencyProperty.Register("IconSize", typeof(double), typeof(ExtendToggleButton), new PropertyMetadata(20d));

        public double IconInterval
        {
            get { return (double)GetValue(IconIntervalProperty); }
            set { SetValue(IconIntervalProperty, value); }
        }
        public static readonly DependencyProperty IconIntervalProperty =
            DependencyProperty.Register("IconInterval", typeof(double), typeof(ExtendToggleButton), new PropertyMetadata(5d));

        public IconPosition IconPosition
        {
            get { return (IconPosition)GetValue(IconPositionProperty); }
            set { SetValue(IconPositionProperty, value); }
        }
        public static readonly DependencyProperty IconPositionProperty =
            DependencyProperty.Register("IconPosition", typeof(IconPosition), typeof(ExtendToggleButton), new PropertyMetadata(IconPosition.Left));

        public Brush IconForeground
        {
            get { return (Brush)GetValue(IconForegroundProperty); }
            set { SetValue(IconForegroundProperty, value); }
        }
        public static readonly DependencyProperty IconForegroundProperty =
            DependencyProperty.Register("IconForeground", typeof(Brush), typeof(ExtendToggleButton), null);

        public CornerRadius CornerRadius
        {
            get { return (CornerRadius)GetValue(CornerRadiusProperty); }
            set { SetValue(CornerRadiusProperty, value); }
        }
        public static readonly DependencyProperty CornerRadiusProperty =
            DependencyProperty.Register("CornerRadius", typeof(CornerRadius), typeof(ExtendToggleButton), new PropertyMetadata(new CornerRadius(0)));

        public Brush PointerOverBackground
        {
            get { return (Brush)GetValue(PointerOverBackgroundProperty); }
            set { SetValue(PointerOverBackgroundProperty, value); }
        }
        public static readonly DependencyProperty PointerOverBackgroundProperty =
            DependencyProperty.Register("PointerOverBackground", typeof(Brush), typeof(ExtendToggleButton), null);

        public Brush PointerOverTextForeground
        {
            get { return (Brush)GetValue(PointerOverTextForegroundProperty); }
            set { SetValue(PointerOverTextForegroundProperty, value); }
        }
        public static readonly DependencyProperty PointerOverTextForegroundProperty =
            DependencyProperty.Register("PointerOverTextForeground", typeof(Brush), typeof(ExtendToggleButton), null);

        public Brush PointerOverIconForeground
        {
            get { return (Brush)GetValue(PointerOverIconForegroundProperty); }
            set { SetValue(PointerOverIconForegroundProperty, value); }
        }
        public static readonly DependencyProperty PointerOverIconForegroundProperty =
            DependencyProperty.Register("PointerOverIconForeground", typeof(Brush), typeof(ExtendToggleButton), null);

        public Brush PointerOverBorderBrush
        {
            get { return (Brush)GetValue(PointerOverBorderBrushProperty); }
            set { SetValue(PointerOverBorderBrushProperty, value); }
        }
        public static readonly DependencyProperty PointerOverBorderBrushProperty =
            DependencyProperty.Register("PointerOverBorderBrush", typeof(Brush), typeof(ExtendToggleButton), null);

        public Brush PressedBackground
        {
            get { return (Brush)GetValue(PressedBackgroundProperty); }
            set { SetValue(PressedBackgroundProperty, value); }
        }
        public static readonly DependencyProperty PressedBackgroundProperty =
            DependencyProperty.Register("PressedBackground", typeof(Brush), typeof(ExtendToggleButton), null);

        public Brush PressedTextForeground
        {
            get { return (Brush)GetValue(PressedTextForegroundProperty); }
            set { SetValue(PressedTextForegroundProperty, value); }
        }
        public static readonly DependencyProperty PressedTextForegroundProperty =
            DependencyProperty.Register("PressedTextForeground", typeof(Brush), typeof(ExtendToggleButton), null);

        public Brush PressedIconForeground
        {
            get { return (Brush)GetValue(PressedIconForegroundProperty); }
            set { SetValue(PressedIconForegroundProperty, value); }
        }
        public static readonly DependencyProperty PressedIconForegroundProperty =
            DependencyProperty.Register("PressedIconForeground", typeof(Brush), typeof(ExtendToggleButton), null);

        public Brush PressedBorderBrush
        {
            get { return (Brush)GetValue(PressedBorderBrushProperty); }
            set { SetValue(PressedBorderBrushProperty, value); }
        }
        public static readonly DependencyProperty PressedBorderBrushProperty =
            DependencyProperty.Register("PresseddBorderBrush", typeof(Brush), typeof(ExtendToggleButton), null);

        public Brush DisabledBackground
        {
            get { return (Brush)GetValue(DisabledBackgroundProperty); }
            set { SetValue(DisabledBackgroundProperty, value); }
        }
        public static readonly DependencyProperty DisabledBackgroundProperty =
            DependencyProperty.Register("DisabledBackground", typeof(Brush), typeof(ExtendToggleButton), null);

        public Brush DisabledTextForeground
        {
            get { return (Brush)GetValue(DisabledTextForegroundProperty); }
            set { SetValue(DisabledTextForegroundProperty, value); }
        }
        public static readonly DependencyProperty DisabledTextForegroundProperty =
            DependencyProperty.Register("DisabledTextForeground", typeof(Brush), typeof(ExtendToggleButton), null);

        public Brush DisabledIconForeground
        {
            get { return (Brush)GetValue(DisabledIconForegroundProperty); }
            set { SetValue(DisabledIconForegroundProperty, value); }
        }
        public static readonly DependencyProperty DisabledIconForegroundProperty =
            DependencyProperty.Register("DisabledIconForeground", typeof(Brush), typeof(ExtendToggleButton), null);

        public Brush DisabledBorderBrush
        {
            get { return (Brush)GetValue(DisabledBorderBrushProperty); }
            set { SetValue(DisabledBorderBrushProperty, value); }
        }
        public static readonly DependencyProperty DisabledBorderBrushProperty =
            DependencyProperty.Register("DisabledBorderBrush", typeof(Brush), typeof(ExtendToggleButton), null);

        public string CheckedContent
        {
            get { return (string)GetValue(CheckedContentProperty); }
            set { SetValue(CheckedContentProperty, value); }
        }
        public static readonly DependencyProperty CheckedContentProperty =
            DependencyProperty.Register("CheckedContent", typeof(string), typeof(ExtendToggleButton), new PropertyMetadata(""));

        public Brush CheckedBackground
        {
            get { return (Brush)GetValue(CheckedBackgroundProperty); }
            set { SetValue(CheckedBackgroundProperty, value); }
        }
        public static readonly DependencyProperty CheckedBackgroundProperty =
            DependencyProperty.Register("CheckedBackground", typeof(Brush), typeof(ExtendToggleButton), null);

        public Brush CheckedTextForeground
        {
            get { return (Brush)GetValue(CheckedTextForegroundProperty); }
            set { SetValue(CheckedTextForegroundProperty, value); }
        }
        public static readonly DependencyProperty CheckedTextForegroundProperty =
            DependencyProperty.Register("CheckedTextForeground", typeof(Brush), typeof(ExtendToggleButton), null);

        public Brush CheckedIconForeground
        {
            get { return (Brush)GetValue(CheckedIconForegroundProperty); }
            set { SetValue(CheckedIconForegroundProperty, value); }
        }
        public static readonly DependencyProperty CheckedIconForegroundProperty =
            DependencyProperty.Register("CheckedIconForeground", typeof(Brush), typeof(ExtendToggleButton), null);

        public Brush CheckedBorderBrush
        {
            get { return (Brush)GetValue(CheckedBorderBrushProperty); }
            set { SetValue(CheckedBorderBrushProperty, value); }
        }
        public static readonly DependencyProperty CheckedBorderBrushProperty =
            DependencyProperty.Register("CheckedBorderBrush", typeof(Brush), typeof(ExtendToggleButton), null);

        public Brush CheckedPointerOverBackground
        {
            get { return (Brush)GetValue(CheckedPointerOverBackgroundProperty); }
            set { SetValue(CheckedPointerOverBackgroundProperty, value); }
        }
        public static readonly DependencyProperty CheckedPointerOverBackgroundProperty =
            DependencyProperty.Register("CheckedPointerOverBackground", typeof(Brush), typeof(ExtendToggleButton), null);

        public Brush CheckedPointerOverTextForeground
        {
            get { return (Brush)GetValue(CheckedPointerOverTextForegroundProperty); }
            set { SetValue(CheckedPointerOverTextForegroundProperty, value); }
        }
        public static readonly DependencyProperty CheckedPointerOverTextForegroundProperty =
            DependencyProperty.Register("CheckedPointerOverTextForeground", typeof(Brush), typeof(ExtendToggleButton), null);

        public Brush CheckedPointerOverIconForeground
        {
            get { return (Brush)GetValue(CheckedPointerOverIconForegroundProperty); }
            set { SetValue(CheckedPointerOverIconForegroundProperty, value); }
        }
        public static readonly DependencyProperty CheckedPointerOverIconForegroundProperty =
            DependencyProperty.Register("CheckedPointerOverIconForeground", typeof(Brush), typeof(ExtendToggleButton), null);

        public Brush CheckedPointerOverBorderBrush
        {
            get { return (Brush)GetValue(CheckedPointerOverBorderBrushProperty); }
            set { SetValue(CheckedPointerOverBorderBrushProperty, value); }
        }
        public static readonly DependencyProperty CheckedPointerOverBorderBrushProperty =
            DependencyProperty.Register("CheckedPointerOverBorderBrush", typeof(Brush), typeof(ExtendToggleButton), null);

        public Brush CheckedPressedBackground
        {
            get { return (Brush)GetValue(CheckedPressedBackgroundProperty); }
            set { SetValue(CheckedPressedBackgroundProperty, value); }
        }
        public static readonly DependencyProperty CheckedPressedBackgroundProperty =
            DependencyProperty.Register("CheckedPressedBackground", typeof(Brush), typeof(ExtendToggleButton), null);

        public Brush CheckedPressedTextForeground
        {
            get { return (Brush)GetValue(CheckedPressedTextForegroundProperty); }
            set { SetValue(CheckedPressedTextForegroundProperty, value); }
        }
        public static readonly DependencyProperty CheckedPressedTextForegroundProperty =
            DependencyProperty.Register("CheckedPressedTextForeground", typeof(Brush), typeof(ExtendToggleButton), null);

        public Brush CheckedPressedIconForeground
        {
            get { return (Brush)GetValue(CheckedPressedIconForegroundProperty); }
            set { SetValue(CheckedPressedIconForegroundProperty, value); }
        }
        public static readonly DependencyProperty CheckedPressedIconForegroundProperty =
            DependencyProperty.Register("CheckedPressedIconForeground", typeof(Brush), typeof(ExtendToggleButton), null);

        public Brush CheckedPressedBorderBrush
        {
            get { return (Brush)GetValue(CheckedPressedBorderBrushProperty); }
            set { SetValue(CheckedPressedBorderBrushProperty, value); }
        }
        public static readonly DependencyProperty CheckedPressedBorderBrushProperty =
            DependencyProperty.Register("CheckedPresseddBorderBrush", typeof(Brush), typeof(ExtendToggleButton), null);

        #endregion


        public ExtendToggleButton()
        {
            this.DefaultStyleKey = typeof(ExtendToggleButton);
            Loaded += XPToggleButton_Loaded;
        }

        private void XPToggleButton_Loaded(object sender, RoutedEventArgs e)
        {
            InitPropertyForNull();

            _common.HorizontalCenterElements(this, _symbolView, _contentPresenter, IconPosition, IconInterval);
        }

        private void InitPropertyForNull()
        {
            if (IconForeground == null) IconForeground = Foreground;

            if (PointerOverBackground == null) PointerOverBackground = Background;
            if (PointerOverTextForeground == null) PointerOverTextForeground = Foreground;
            if (PointerOverIconForeground == null) PointerOverIconForeground = Foreground;
            if (PointerOverBorderBrush == null) PointerOverBorderBrush = BorderBrush;

            if (PressedBackground == null) PressedBackground = Background;
            if (PressedTextForeground == null) PressedTextForeground = Foreground;
            if (PressedIconForeground == null) PressedIconForeground = Foreground;
            if (PressedBorderBrush == null) PressedBorderBrush = BorderBrush;

            if (DisabledBackground == null) DisabledBackground = Background;
            if (DisabledTextForeground == null) DisabledTextForeground = Foreground;
            if (DisabledIconForeground == null) DisabledIconForeground = Foreground;
            if (DisabledBorderBrush == null) DisabledBorderBrush = BorderBrush;

            if (CheckedPointerOverBackground == null) CheckedPointerOverBackground = CheckedBackground;
            if (CheckedPointerOverTextForeground == null) CheckedPointerOverTextForeground = CheckedTextForeground;
            if (CheckedPointerOverIconForeground == null) CheckedPointerOverIconForeground = CheckedIconForeground;
            if (CheckedPointerOverBorderBrush == null) CheckedPointerOverBorderBrush = CheckedBorderBrush;

            if (CheckedPressedBackground == null) CheckedPressedBackground = CheckedBackground;
            if (CheckedPressedTextForeground == null) CheckedPressedTextForeground = CheckedTextForeground;
            if (CheckedPressedIconForeground == null) CheckedPressedIconForeground = CheckedIconForeground;
            if (CheckedPressedBorderBrush == null) CheckedPressedBorderBrush = CheckedBorderBrush;

            if (CheckedContent == null && Content != null) CheckedContent = Content.ToString();
        }

        protected override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            _visualPanel = (RelativePanel)GetTemplateChild("VisualPanel");
            _symbol = (ContentControl)GetTemplateChild("Symbol");
            _symbolView = (Viewbox)GetTemplateChild("SymbolView");
            _contentPresenter = (ContentPresenter)GetTemplateChild("ContentPresenter");
        }

        protected override void OnToggle()
        {
            IsChecked = !IsChecked;

            if (OnToggleChanged != null)
            {
                var eventArgs = new ToggleEventArgs(IsChecked.HasValue ? IsChecked.Value : false);
                OnToggleChanged(this, eventArgs);
                if (eventArgs.IsCancel)
                {
                    IsChecked = !IsChecked;
                }
            }
        }
    }
}
