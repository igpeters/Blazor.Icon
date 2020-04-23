[![Build Status](https://dev.azure.com/Mobsites-US/Blazor%20Icon/_apis/build/status/Build?branchName=master)](https://dev.azure.com/Mobsites-US/Blazor%20Icon/_build/latest?definitionId=15&branchName=master)

# Blazor Icon
by <a href="https://www.mobsites.com"><img align="center" src="./src/assets/mobsites-logo.png" width="36" height="36" style="padding-top: 20px;" />obsites</a>

A Blazor UI component for rendering an icon.

## Currently Supports
* Material Icons
* Images

## Future Plans
* Font Awesome
* Open Iconic

## [Demo](https://www.mobsites.com/Blazor.Icon/)
Tap the link above to go to a live demo. Try some of the options to get an idea of what's possible. Then reload the app in the browser and watch how the state was kept! 

Check out its source code [here](./demo).

## For
* Blazor WebAssembly
* Blazor Server

## Dependencies

###### .NETStandard 2.0
* Microsoft.AspNetCore.Components (>= 3.1.3)
* Microsoft.AspNetCore.Components.Web (>= 3.1.3)
* Mobsites.Blazor.BaseComponents (>= 1.0.0)

## Design and Development
The design and development of this Blazor component was heavily guided by Microsoft's [Steve Sanderson](https://blog.stevensanderson.com/). He outlines a superb approach to building and deploying a reusable component library in this [presentation](https://youtu.be/QnBYmTpugz0) and [example](https://github.com/SteveSandersonMS/presentation-2020-01-NdcBlazorComponentLibraries).

As for the non-C# implementation of this component library, obviously the Material Icon [docs](https://google.github.io/material-design-icons/#icon-font-for-the-web) were consulted carefully. We have elected to reference Google's CDN web font package directly instead of using npm to webpack them ourselves because Google packaged all the material icons into a single font that takes advantage of the typographic rendering capabilities of modern browsers, and Google correctly serve up the font specific to the browser.

## Getting Started
Check out our new [docs](https://www.mobsites.com/blazor/icon) to help you get started.