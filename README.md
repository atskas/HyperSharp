# HyperSharp

![License](https://img.shields.io/github/license/atskas/HyperSharp?cacheSeconds=60)
![Status](https://img.shields.io/badge/status-in--development-yellow)

> A lightweight, modular C# to HTML converter library which takes raw C# and converts it to well-structured HTML.

## Getting started

### Requirements
- .NET 6.0 or later

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

> **Developer note:**  
> Currently, HyperSharp is an executable project to simplify testing and development. It is **not yet a library**, but will be converted into one soon.  
>   
> Meanwhile, if you want to use its functionality, you can create your own `Main` method and call the necessary functions directly from the code.
