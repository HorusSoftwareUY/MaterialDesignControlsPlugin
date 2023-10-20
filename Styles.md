# Defining Styles
At the start of your app, for instance, in the App.cs file, you can override any styles to apply them to all the Material controls. You can also use some of these styles as your global styles.

We strongly recommend overriding the color palette since, by default, it utilizes a palette employed in Material Design samples. Therefore, you should replace the colors with your custom color palette.

Exercise caution when overriding the font size definitions, as a significant number of controls rely on them, and making substantial changes could result in visual issues.

```C#
private void SetMaterialStyles()
{
    MainThread.BeginInvokeOnMainThread(() =>
    {
        var currentTheme = Application.Current.RequestedTheme;

        MaterialColor.Primary = currentTheme == OSAppTheme.Dark ? Color.FromHex("#8976BC") : Color.FromHex("#6750A4");
        MaterialColor.OnPrimary = currentTheme == OSAppTheme.Dark ? Color.FromHex("#1A1A1A") : Color.FromHex("#FFFFFF");
        ...
        MaterialColor.DisableContainer = currentTheme == OSAppTheme.Dark ? Color.FromHex("#B1ABBA") : Color.FromHex("#E5E3E8");
    });

    MaterialAnimation.Parameter = 0.7;
    MaterialAnimation.Type = AnimationTypes.Fade;
    MaterialAnimation.AnimateOnError = true;

    MaterialFontFamily.Default = "RegularFont";
    MaterialFontFamily.Regular = "MediumFont";
    MaterialFontFamily.Medium = "BoldFont";

    MaterialFontSize.DisplayLarge = 70;
    MaterialFontSize.DisplayMedium = 50;
    ...
    MaterialFontSize.BodySmall = 15;
}
         
```

## MaterialAnimation
MaterialAnimation exposes the properties used for the control's animations.

### Type 
Defines the animation type that the control will use for animation (allowed values: None, Fade, and Scale).

#### Allowed values
- Fade (Default)
- Scale
- None

### Parameter
Defines the animation parameter that the control will use for animation (e.g., opacity percentage or scale value up to which the animation is executed). The default value is 0.7.

### AnimateOnError
Determines whether the input control animates when supporting text is set for the control (indicating an error). Currently, the only supported animation is a control shake. The default value is True.

## MaterialFontFamily
MaterialFontFamily exposes various font families utilized by the controls.

By default, these font families are empty, resulting in the controls using the default OS font family.

### Properties
- Default
- Regular
- Medium

## MaterialColor
MaterialColor provides access to a color palette containing all the colors used by the controls, as defined by Material Design guidelines.

This color palette can also be applied as a global style throughout the entire app.

By default, the color palette aligns with the one used in Material Design samples, so you may need to customize the colors to match your own color palette.

<img src="https://github.com/HorusSoftwareUY/MaterialDesignControlsPlugin/blob/master/screenshots/colorPalette.png" width="600">

### Properties
- Primary
- OnPrimary
- PrimaryContainer
- OnPrimaryContainer
- Secondary
- OnSecondary
- SecondaryContainer
- OnSecondaryContainer
- Error
- OnError
- ErrorContainer
- OnErrorContainer
- SurfaceDim
- Surface
- SurfaceBright
- SurfaceContainerLowest
- SurfaceContainerLow
- SurfaceContainer
- SurfaceContainerHigh
- SurfaceContainerHighest
- OnSurface
- OnSurfaceVariant
- Outline
- OutlineVariant
- InverseSurface
- InverseOnSurface
- InversePrimary
- Scrim
- Shadow
- Text
- Disable
- DisableContainer

## MaterialFontSize
MaterialFontSize presents the definitions for font sizes, encompassing all the font sizes prescribed by Material Design guidelines. 

This font size definition can also serve as a global style throughout the entire app. 

MaterialFontSize includes default adjustments for tablet devices (which can be overridden as needed) by slightly increasing the default font sizes when the app runs on a tablet to maintain better text-to-screen size proportions.

### Default font size definitions
|Properties|Tablet|Phone|
| ------------------- | :------------------: | :------------------: |
|DisplayLarge|80|57|
|DisplayMedium|62|45|
|DisplaySmall|50|36|
|HeadlineLarge|44|32|
|HeadlineMedium|38|28|
|HeadlineSmall|32|24|
|TitleLarge|26|22|
|TitleMedium|19|16|
|TitleSmall|17|14|
|LabelLarge|17|14|
|LabelMedium|15|12|
|LabelSmall|14|11|
|BodyLarge|19|16|
|BodyMedium|17|14|
|BodySmall|15|12|
