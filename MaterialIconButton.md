# MaterialIconButton
MaterialIconButton displays an icon and can execute a command.<br/>
[View Material Design documentation](https://m3.material.io/components/icon-buttons)

## Screenshot
<img src="https://github.com/HorusSoftwareUY/MaterialDesignControlsPlugin/blob/master/screenshots/material_icon_button_preview.png" >

## Example
```XML
<material3:MaterialIconButton Command="{Binding StandardCommand}">
    <material3:MaterialIconButton.CustomIcon>
        <ffimageloadingsvg:SvgCachedImage Source="resource://ExampleMaterialDesignControls.Resources.Svg.mute.svg" />
    </material3:MaterialIconButton.CustomIcon>
</material3:MaterialIconButton>
```

## Documentation

### Property ButtonType:
This property is to set the type of the IconButton.
<br/>
#### Allowed values
- Standard (Default)
- Filled
- Outlined
- Tonal
<br/>
<br/>

### Property IsEnabled:
This property is to set if the icon button is enabled or disabled.
<br/>

### Property Command:
This property is to set a command for execution when the control is tapped.<br/>

### Property CommandParameter:
This property is to specify a parameter for the command when the control is tapped.<br/>

### Property Animation:
This property is to set the animation of the control when is tapped.
<br/>
#### Allowed values
- None (Default)
- Fade 
- Scale
- Custom
<br/>

### Property AnimationParameter:
This property is to set the animation of the control when is tapped.
<br/>

### Property CustomAnimation:
This property is to set a custom animation of the control when is tapped.
<br/>

### Property BackgroundColor:
This property is to set the background color for the circle in the Filled and Tonal types, and for the border in the Outlined type.
<br/>

### Property DisabledBackgroundColor:
This property is to set the background color for the circle in the Filled and Tonal types when the icon button is disabled, and for the border in the Outlined type.
<br/>

### Property Icon:
This property is to set the icon.
<br/>

### Property DisabledIcon:
This property is to set the icon when the icon button is disabled.
<br/>

### Property CustomIcon:
This property is to set a custom icon.
<br/>

### Property CustomDisabledIcon:
This property is to set a custom icon when the icon button is disabled.
<br/>

### PaddingIcon:
This property is used to define the padding of the icon in relation to the circle.<br/>

### Property BusyColor:
This property is to set the color of the busy indicator.

### Property IsBusy:
This property is to show a busy indicator in the button when a command is running.
<br/>