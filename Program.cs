using System;
using HypertextSharp.Core;

public class Program
{
    public static void Main(string[] args)
    {
        Html Html = new Html();

        Html.DOCTYPE();
        Html.Div(() =>
        {
            Html.Span("Text");
            Html.Span(() => Html.Span("Nested Text"));
        });
        
        Html.Compile(Html.GetHtml());
    }
}