using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace AuroraBorealis
{
    public class Colors
    {
        public static Color Primary => Purple;
        public static Color Accent => Blue;

        public static readonly Color
            NearBlack = Color.FromHex("#333333"),
            NearWhite = Color.FromHex("#FCFCFC"),

            Gray = Color.FromHex("#BABABA"),
            DarkGray = Color.FromHex("#5E5E5E"),
            LightGray = Color.FromHex("#F9F9FC"),

            Orange = Color.FromHex("#E59850"),
            Yellow = Color.FromHex("#E8C547"),
            Green = Color.FromHex("#80E577"),
            Blue = Color.FromHex("#47A6E5"),
            Red = Color.FromHex("#E54444"),
            Purple = Color.FromHex("#976EE5"),
            Pink = Color.FromHex("#E592C7"),

            DarkOrange = Color.FromHex("#E58C39"),
            DarkYellow = Color.FromHex("#E5CE37"),
            DarkGreen = Color.FromHex("#60CE56"),
            DarkBlue = Color.FromHex("#309CE5"),
            DarkRed = Color.FromHex("#E52D2D"),
            DarkPurple = Color.FromHex("#8957E5"),
            DarkPink = Color.FromHex("#E57BBE"),

            LightOrange = Color.FromHex("#E5C0A0"),
            LightYellow = Color.FromHex("#E5DC9E"),
            LightGreen = Color.FromHex("#CAE5C7"),
            LightBlue = Color.FromHex("#97C6E5"),
            LightRed = Color.FromHex("#E59595"),
            LightPurple = Color.FromHex("#CBBEE5"),
            LightPink = Color.FromHex("#E5CCDB"),

            Success = Color.FromHex("#2D882D"),
            Warning = Color.FromHex("#AA6C39"),
            Alert = Color.FromHex("#AA3939"),

            SuccessLight = Color.FromHex("#88CC88"),
            WarningLight = Color.FromHex("#FFD8AA"),
            AlertLight = Color.FromHex("#FFAAAA");
    }
}
