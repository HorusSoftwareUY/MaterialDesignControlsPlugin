# MaterialSnackBar
Snackbars show short updates about app processes at the bottom of the screen.
<br/>
Currently, this control only represents the UI and guidelines proposed by Material, it doesn't provide the popup/alert behavior, you could resolve it with Rg.Plugins.Popup or with a similar implementation.
<br/>
[View Material Design documentation](https://m3.material.io/components/snackbar/overview)

## Screenshot
<img src="https://github.com/HorusSoftwareUY/MaterialDesignControlsPlugin/blob/master/screenshots/snackbar_preview.png" width="300">

## Example
```XML
<material3:MaterialSnackBar
    Text="Lorem ipsum dolor sit amet"
    ActionText="Action"
    ActionCommand="{Binding ActionCommand}" />
```

## Documentation

### BackgroundColor:
This property is to set the background color of the snackbar.
<br/>

### ShadowColor:
This property is to set the background color of the snackbar shadow.
<br/>

### Property HasShadow 
This property is to set if the control will have shadow or not.
<br/>

### Property Text:
This property is to set the text of the label.
<br/>

### Property TextColor:
This property is to set the color text of the label.
<br/>

### Property FontSize:
This property is to the font size of the label.
<br/>

### Property FontFamily:
This property is to the font family of the label.
<br/>

### Property ActionText:
This property is to set the text of the action button.
<br/>

### Property ActionTextColor:
This property is to set the color text of the action button.
<br/>

### Property ActionFontSize:
This property is to the font size of the action button.
<br/>

### Property ActionFontFamily:
This property is to the font family of the action button.
<br/>

### Property ActionCommand:
This property is to the command of the action button.
<br/>

### Property ActionCommandParameter:
This property is to the command parameter of the action button.
<br/>

### Property BackgroundColor:
This property is to set the badge background color.
<br/>

### Property LeadingIcon:
This property is to set the leading icon with support for view, you can use PNG, JPG or JPEG.
<br/>

### Property TrailingIcon:
This property is to set the trailing icon with support for view, you can use PNG, JPG or JPEG.
<br/>

### Property CustomLeadingIcon:
This property is to set the leading icon with support to svg.
<br/>

### Property CustomTrailingIcon:
This property is to set the trailing icon with support to svg.
<br/>

### Property TrailingIconCommand:
This property is to set the trailing icon command.
<br/>

### Property LeadingIconCommand:
This property is to set the leading icon command.
<br/>

### Property IconSize:
This property is to set the sizes to the trailing and leading icons.
<br/>