using HyperSharp.Core;

namespace HyperSharp.Elements.Base.Elements;

internal class HtmlVideo : HtmlElement
{
    private readonly Stack<HtmlElement> elementStack;
    
    public HtmlVideo(Stack<HtmlElement> elementStack) : base("video")
    {
        this.elementStack = elementStack;
    }
    
    /// <summary>
    /// Embeds a video player to play video content.
    /// </summary>
    /// <param name="innerContent"></param>
    /// <param name="attributes"></param>
    public void Video(Action innerContent, AttributeBuilder attributes)
    {
        var video = new HtmlElement("video", attributes.Attributes);
        elementStack.Peek().AddChild(video);
        
        elementStack.Push(video);
        innerContent();
        elementStack.Pop();
    }
    
    /// <summary>
    /// Embeds a video player to play video content.
    /// </summary>
    /// <param name="attributes"></param>
    /// <param name="innerContent"></param>
    public void Video(AttributeBuilder attributes, Action innerContent)
    {
        var video = new HtmlElement("video", attributes.Attributes);
        elementStack.Peek().AddChild(video);
        
        elementStack.Push(video);
        innerContent();
        elementStack.Pop();
    }
    
    /// <summary>
    /// Embeds a video player to play video content.
    /// </summary>
    /// <param name="attributes"></param>
    public void Video(AttributeBuilder attributes)
    {
        var video = new HtmlElement("video", attributes.Attributes);
        elementStack.Peek().AddChild(video);
    }
    
    /// <summary>
    /// Embeds a video player to play video content.
    /// </summary>
    /// <param name="innerContent"></param>
    public void Video(Action innerContent)
    {
        var video = new HtmlElement("video");
        elementStack.Peek().AddChild(video);
        
        elementStack.Push(video);
        innerContent();
        elementStack.Pop();
    }
}