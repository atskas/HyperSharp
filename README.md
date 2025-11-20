# HyperSharp

![License](https://img.shields.io/github/license/atskas/HyperSharp?cacheSeconds=60)
![Status](https://img.shields.io/badge/status-in--development-yellow)

<img src="Images/logo.png" alt="Logo" width="175"/>

> A lightweight, modular C# to HTML converter library which takes raw C# and converts it to well-structured HTML.

## Getting started

### Requirements
- .NET 6.0 or later

### Installation

1. Clone the repository:

```bash
git clone https://github.com/atskas/HyperSharp
cd HyperSharp
```

2. Build the library:

```bash
dotnet build HyperSharp.Library/HyperSharp.Library.csproj
```
This produces `HyperSharp.Library.dll` in the `bin` folder.

3. Reference the library in your project:

```bash
dotnet add path/to/Project.csproj reference HyperSharp.Library/HyperSharp.Library.csproj
```

### Usage

Start working with HyperSharp by creating a new `HtmlDocument`:
```csharp
private static HtmlDocument Document = new();
```
Use its methods to define HTML structure and elements programmatically.

### Configuration

You can customize the output by setting the following properties:
- `OutputFileName` - Name of the generated HTML file (default: `output.html`)  
- `OutputPath` - Directory where the output file is saved (default: `Documents/HyperSharp_Output`)  
- `UserCssPath` - Optional path to a custom CSS file or directory for styling the generated HTML  

You can run the demo project to check out `HyperSharp`'s possibilities.
 ```bash
dotnet run --project HyperSharp.Testing/HyperSharp.Testing.csproj
```

>  [See GitHub's contribution guide](https://docs.github.com/en/get-started/exploring-projects-on-github/contributing-to-a-project) if you’d like to help out!
