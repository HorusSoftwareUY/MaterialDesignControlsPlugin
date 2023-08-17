# MaterialButton
Buttons allow users to take actions, and make choices, with a single tap.
<br/>
[View Material Design documentation](https://m3.material.io/components/buttons/overview)

## Screenshot

<img src="https://github.com/HorusSoftwareUY/MaterialDesignControlsPlugin/blob/master/screenshots/button_preview.gif" width="300">

## Example MaterialButton
Using the control:
```XML
<material:MaterialButton
    Text="Save" 
    Icon="save.png" 
    Command="{Binding TapCommand}" 
    CommandParameter="Saved" />
```

## Documentation

### Property ButtonType:
#### Allowed values
- Elevated
- Filled (Default)
- Tonal
- Outlined
- Text
<br/>

### Property Command:
This property is to set the command to the button.
<br/>

### Property CommandParameter:
This property is to set the command parameter to the button.
<br/>

### Property HeadlineFontFamily:
This property is to set the headline text font family.
<br/>

### Property IsEnabled:
This property is to set if the button is enabled or disabled.
<br/>

### Property Animation:
This property is to set the animation when the button is tapped.
<br/>

#### Allowed values
- None
- Fade (Default)
- Scale
- Custom
<br/>

### Property AnimationParameter:
This property is to customize the animation when the button is tapped.
<br/>

### Property ButtonCustomAnimation:
This property is to set a custom animation when the button is tapped.
<br/>

### Property Text:
This property is to set the text of the button.
<br/>

### Property TextColor:
This property is to set the color of the button text.
<br/>

### Property DisabledTextColor:
This property is to set the disabled color of the button text.
<br/>

### Property BackgroundColor:
This property is to set the background color of the button.
<br/>

### Property DisabledBackgroundColor:
This property is to set the disabled background color of the button.
<br/>

### Property FontSize:
This property is to set the font size of the button text.
<br/>

### Property FontFamily:
This property is to set the font family of the button text.
<br/>

### Property ToUpper:
This property is to make the text uppercase or lowercase, the default is false.
<br/>

### Property CornerRadius:
This property is to set the corner radius of the button.
<br/>

### Property BorderColor:
This property is to set the border color of the button.
<br/>

### Property DisabledBorderColor:
This property is to set the disabled border color of the button.
<br/>

### Property BusyColor:
This property is to set the color of the busy indicator.

### Property IsBusy:
This property is to show a busy indicator in the button when a command is running.
<br/>

### Property LeadingIcon:
This property is to set the leading icon with support for view, you can use SVG, font icon, PNG, JPG or JPEG.
<br/>

### Property TrailingIcon:
This property is to set the trailing icon with support for view, you can use SVG, font icon, PNG, JPG or JPEG.
<br/>

### Property IconSize:
This property is to set the sizes to the trailing and leading icons.
<br/>

### Property CustomActivityIndicator:
This property is to set a view with a custom busy indicator.
<br/>

### Property ActivityIndicatorSize:
This property is to set the size to the busy indicator.
<br/>

### Property Padding:
This property is to set the padding of the button.
<br/>

### Property Spacing:
This property is to set the spacing of the stack that contains the button icons and button text.
<br/>

### Property ContentIsExpanded:
This property is to set if the content of the button is expanded, default is false
<br/>