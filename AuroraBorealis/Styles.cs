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
