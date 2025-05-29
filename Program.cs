using System;
using HypertextSharp.Core;

public class Program
{
    public static void Main(string[] args)
    {
        Html Html = new Html();

        Html.Div(() => Html.Span("Text"));
        
        Html.Compile(Html.GetHtml());
    }
}