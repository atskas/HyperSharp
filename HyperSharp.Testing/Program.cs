using HyperSharp.Core;

public class Program
{
    private static HtmlDocument Document = new();

    public static void Main()
    {
        string cssFolderPath = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..", "..", "..", "Testing", "css"));
        Document.SetUserCssPath(cssFolderPath);
        
        Document.Html(() =>
        {
            Document.Link("stylesheet", "CSS/style.css");
            Document.Div( () =>
            {
                Document.Heading("Hello, world!", 1);
                Document.Heading("What's up, people!!",4, Document.Attributes.Class("greeting"));
                Document.Span("The HTML of this website was fully made in C#. Click below for cookies:");
                Document.Div(() =>
                {
                    Document.Button("HERE!");
                });
            }, Document.Attributes.Class("container"));
        });
        
        Document.SetFileName("Greetings");
        Document.Compile();
    }
}