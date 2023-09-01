# MaterialIconButton
MaterialIconButton displays an icon and can execute a command.<br/>
[View Material Design documentation](https://m3.material.io/components/icon-buttons)

## Screenshot
<img src="https://github.com/HorusSoftwareUY/MaterialDesignControlsPlugin/blob/master/screenshots/material_icon_button_preview.png" >

## Example MaterialTopAppBar
```XML
<material3:MaterialLabel FontFamily="{StaticResource SemiBoldFont}"
                        HorizontalTextAlignment="Center"
                        Text="Outlined Type" />
<material3:MaterialIconButton BackgroundColor="Green" ButtonType="Outlined" Animation="Scale" Command="{Binding OutlinedCommand}">
    <material3:MaterialIconButton.CustomIcon>
        <ffimageloadingsvg:SvgCachedImage Source="resource://ExampleMaterialDesignControls.Resources.Svg.mute.svg" />
    </material3:MaterialIconButton.CustomIcon>
</material3:MaterialIconButton>
```

## Documentation

### Property ButtonType:
#### Allowed values
- Standard (Default)
- Filled
- Outlined
- Tonal
<br/>
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

### Property Icon:
This property is to set the icon.
<br/>

### Property CustomIcon:
This property is to set a custom icon.
<br/>

### MarginIcon:
This property is used to define the margin of the icon in relation to the circle.<br/>

### MarginIcon:
This property is used to define the margin of the icon in relation to the circle.<br/>

