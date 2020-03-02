using Aurora.Controls;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace AuroraBorealis
{
    public static class Styles
    {
        public static Style ButtonStyle
        {
            get
            {
                var style = new Style(typeof(Button))
                {
                    ApplyToDerivedTypes = true
                };

                style.Setters.Add(VisualElement.BackgroundColorProperty, Colors.Primary);
                style.Setters.Add(Button.TextColorProperty, Colors.NearWhite);

                return style;
            }
        }

        public static Style FloatLabelContainerViewStyle
        {
            get
            {
                var style = new Style(typeof(FloatLabelContainerView))
                {
                    ApplyToDerivedTypes = true,
                    CanCascade = true
                };

                style.Setters.Add(FloatLabelContainerView.TitleFontSizeProperty, 15);
                style.Setters.Add(FloatLabelContainerView.EditingViewHeightProperty, 32);
                style.Setters.Add(FloatLabelContainerView.ErrorRowHeightProperty, 0);

                style.Setters.Add(FloatLabelContainerView.CornerRadiusProperty, 20d);
                style.Setters.Add(FloatLabelContainerView.ContentBackgroundColorProperty, Colors.NearWhite);

                style.Setters.Add(FloatLabelContainerView.BorderStyleProperty, FloatLabelContainerView.FloatingLabelContainerBorderStyle.RoundedRectangle);
                style.Setters.Add(FloatLabelContainerView.BorderSizeProperty, 6d);

                style.Setters.Add(FloatLabelContainerView.ActiveColorProperty, Colors.Accent);
                style.Setters.Add(FloatLabelContainerView.InactiveColorProperty, Colors.Primary);

                style.Setters.Add(FloatLabelContainerView.DisabledColorProperty, Colors.DarkGray);

                style.Setters.Add(FloatLabelContainerView.PlaceholderColorProperty, Colors.Accent);

                style.Setters.Add(FloatLabelContainerView.EditingViewMarginProperty, new Thickness(8, 4));

                var nonUserEditable = new Trigger(typeof(FloatLabelContainerView))
                {
                    Property = FloatLabelContainerView.UserEditableProperty,
                    Value = false
                };

                nonUserEditable.Setters.Add(FloatLabelContainerView.ContentBackgroundColorProperty, Colors.DarkGray);
                style.Triggers.Add(nonUserEditable);

                return style;
            }
        }

        public static Style FloatLabelEntryStyle
        {
            get
            {
                var style = new Style(typeof(FloatLabelEntry))
                {
                    BasedOn = FloatLabelContainerViewStyle,
                    ApplyToDerivedTypes = true,
                    CanCascade = true
                };

                return style;
            }
        }

        public static void ApplyApplicationTheme()
        {
            var app = Application.Current;

            app.Resources?.Clear();

            if (app.Resources == null)
                app.Resources = new ResourceDictionary();

            app.Resources.Add(ButtonStyle);
            app.Resources.Add(FloatLabelContainerViewStyle);
        }
    }
}
