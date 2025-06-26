using HyperSharp.Elements.Base;
using HyperSharp.Elements.Base.Elements;

namespace HyperSharp.Core;

public class ElementInit
{
    internal readonly Stack<HtmlElement> ElementStack = new Stack<HtmlElement>();
    
    internal readonly HtmlDiv HtmlDiv;
    internal readonly HtmlSpan HtmlSpan;
    internal readonly HtmlHead HtmlHead;
    internal readonly HtmlBody HtmlBody;
    internal readonly HtmlLink HtmlLink;
    internal readonly HtmlButton HtmlButton;
    internal readonly HtmlTitle HtmlTitle;
    internal readonly HtmlMeta HtmlMeta;
    internal readonly HtmlIFrame HtmlIFrame;
    internal readonly HtmlVideo HtmlVideo;
    internal readonly HtmlSource HtmlSource;
    internal HtmlRoot Root;

    public ElementInit()
    {
        // Pass all elements to the document
        HtmlDiv = new HtmlDiv(ElementStack);
        HtmlSpan = new HtmlSpan(ElementStack);
        Root = new HtmlRoot(ElementStack);
        HtmlHead = new HtmlHead(ElementStack);
        HtmlBody = new HtmlBody(ElementStack);
        HtmlLink = new HtmlLink(ElementStack);
        HtmlButton = new HtmlButton(ElementStack);
        HtmlTitle = new HtmlTitle(ElementStack);
        HtmlMeta = new HtmlMeta(ElementStack);
        HtmlIFrame = new HtmlIFrame(ElementStack);
        HtmlVideo = new HtmlVideo(ElementStack);
        HtmlSource = new HtmlSource(ElementStack);
    }

}