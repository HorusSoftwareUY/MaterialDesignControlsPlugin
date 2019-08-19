# MaterialDesignControls Plugin for Xamarin Forms
Description

## Setup
* Available on NuGet: [Plugin.MaterialDesignControls](https://www.nuget.org/packages/Plugin.MaterialDesignControls/) [![NuGet](https://img.shields.io/nuget/v/Plugin.MaterialDesignControls.svg?label=NuGet)](https://www.nuget.org/packages/Plugin.MaterialDesignControls/)
* Install into your PCL project and Client projects.

**Platform Support**

|Platform|Version|
| ------------------- | :------------------: |
|Xamarin.iOS|iOS 8+|
|Xamarin.Android|API 16+|

## API Usage

You must add this line to your platform specific project (`AppDelegate.cs`, `MainActivity.cs`) before you use MaterialDesignControls:

if you're using **iOS**:
```C#
Plugin.MaterialDesignControls.iOS.Renderer.Init();           
```

or if you're using **Android**:
```C#
Plugin.MaterialDesignControls.Android.Renderer.Init();           
```
You must add this line to your xaml files:

```XML
xmlns:material="clr-namespace:Plugin.MaterialDesignControls;assembly=Plugin.MaterialDesignControls"
```

## Controls

### MaterialEntry
[Control description]

**Example**
```XML
<material:MaterialEntry FieldName="Name" Type="Filled" LabelText="Name" Placeholder="Enter your name"
                                        IsRequired="true" RequiredMessage="The name is required" MaxLength="12" />
```
**Screenshot**
[Screenshot]

[Documentation](https://github.com/HorusSoftwareUY/MaterialDesignControlsPlugin/wiki/MaterialEntry)

## Demo
https://github.com/HorusSoftwareUY/MaterialDesignControlsPlugin/tree/master/example

#### Contributions
Contributions are welcome! If you find a bug want a feature added please report it.

If you want to contribute code please file an issue, create a branch, and file a pull request.

#### License 
MIT License - see LICENSE.txt