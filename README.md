# HyperSharp

![License](https://img.shields.io/github/license/atskas/HyperSharp?cacheSeconds=60)
![Status](https://img.shields.io/badge/status-in--development-yellow)

<img src="Images/logo.png" alt="Logo" width="175"/>

> A lightweight, modular C# to HTML converter library which takes raw C# and converts it to well-structured HTML.

## Getting started

### Requirements
- .NET 6.0 or later

### Usage

To start working with HyperSharp, create a new ``HtmlDocument``:
```cs
private static HtmlDocument Document = new();
```
You can then use its methods to define HTML structure and elements programmatically.


### Configuration

You can customize the output by setting the following properties:

- **`OutputFileName`** — Name of the generated HTML file (default: e.g., `output.html`)  
- **`OutputPath`** — Directory where the output file is saved (default: `Documents/HyperSharp_Output`)  
- **`UserCssPath`** — Optional path to a custom CSS file or a directory holding CSS files to style the generated HTML

If you don't specify these, HyperSharp will save the output to your system's `Documents/HyperSharp_Output` folder by default.

### Installation

Clone the repository:

```bash
git clone https://github.com/atskas/HyperSharp
cd HyperSharp
dotnet build
```

> **Developer Note:**  
> HyperSharp is under **active development**. It’s functional, but not yet a complete library.
>  
> Currently, it runs as an executable project for easier testing. It will be converted into a standalone library soon.  
>  
> In the meantime, you can use its features by creating your own `Main` method and calling HyperSharp classes directly.  
>  
>  [See CONTRIBUTING.md](CONTRIBUTING.md) if you’d like to help out!
