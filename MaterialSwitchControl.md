# MaterialSwitch
Switches toggle the state of a single item on or off.
<br/>
[View Material Design documentation](https://material.io/components/switches)

## Screenshot
<!-- TODO change this  -->
<img src="https://github.com/HorusSoftwareUY/MaterialDesignControlsPlugin/blob/master/screenshots/switch.gif" width="300">

## Example MaterialSwitch
```XML
 <material:MaterialSwitch   
    Text="Bluetooth *"
    IsToggled="False"
    TextColor="#0d1a26"
    SupportingTextColor="Red"
    SupportingText="Bluetooth is required"/>
```
<br/>

## Documentation
We update this control to use VisualStateManager (See examble above). So we recommend use visual state to change the style of the control. 
### Allowed States:
- Normal
- Disabled

#### Example:

Set style:

```XML
<Style TargetType="material3:MaterialSwitch">
    <Setter Property="AnimateError"
            Value="True" />
    <Setter Property="SupportingTextColor"
            Value="#c92726" />
    <Setter Property="SupportingSize"
            Value="12" />
    <Setter Property="TextColor"
            Value="#0d1a26" />
    <Setter Property="VisualStateManager.VisualStateGroups">
        <VisualStateGroupList>
            <VisualStateGroup x:Name="CommonStates">
                <VisualState x:Name="Normal">
                    <VisualState.Setters>
                        <Setter Property="TextColor"
                                Value="#0d1a26" />
                    </VisualState.Setters>
                </VisualState>
                <VisualState x:Name="Disabled">
                    <VisualState.Setters>
                        <Setter Property="TextColor"
                                Value="#828282" />
                    </VisualState.Setters>
                </VisualState>
            </VisualStateGroup>
        </VisualStateGroupList>
    </Setter>
</Style>
``` 
<br/>
<br/>

## Documentation
<br/>

### Property BackgroundOnUnselectedColor
This property is to set the backgroundcolor when the switch toggled is false.
<br/>
<br/>

### Property BackgroundSelectedColor
This property is to set the backgroundcolor when the switch toggled is true.
<br/>
<br/>

### Property IsToggled:
This property is to set the current toggled value.
<br/>
<br/>

### Property ToggledCommand:
This property is to set a command when the switch is toggled.
<br/>
<br/>

### Property ThumbUnselectedColor
This property is to set the thumb color when the switch toggled is false.
<br/>
<br/>

### Property ThumbSelectedColor
This property is to set the thumb color when the switch toggled is true.
<br/>
<br/>

### Property SelectedIcon
This property is to set the thumb icon when the switch toggled is true.
<br/>
<br/>

### Property CustomSelectedIcon
This property is to set the thumb icon (SVG) when the switch toggled is true.
<br/>
<br/>

### Property UnselectedIcon
This property is to set the thumb icon when the switch toggled is false. **To show this icon, you must set SelectedIcon**
<br/>
<br/>

### Property CustomUnselectedIcon
This property is to set the thumb icon (SVG) when the switch toggled is false.
<br/>
<br/>

### Property Text
This property is to set the text value.
<br/>
<br/>

### Property TextColor:
This property is to set the color of the text when the control is enabled.
<br/>
<br/>

### Property FontSize:
This property is to set the fontsize of the text.
<br/>
<br/>

### Property FontFamily
This propperty is to set the fontfamily of the text.
<br/>
<br/>

### Property SupportingText:
This property is to set the error text on the control. 
<br/>
<br/>

### Property SupportingTextColor:
This property is to set the error text color value on the control.
<br/>
<br/>

### Property SupportingSize:
This property is to set the error text font size value on the control. 
<br/>
<br/>

### Property SupportingFontFamily:
This property is to set the error text font family value on the control.
<br/>
<br/>

### Property SupportingMargin:
This property is to set the error text margin value on the control.
<br/>
<br/>

### Property AnimateError:
This property is to set if you can show a ShakeAnimation when there is a error with control.
<br/>
<br/>

### Property TextSide
This property is to set the side of the text, it could be: Right or Left. By default is Right.
<br/>
<br/>

### Property TextVerticalOptions
This property is to set the VerticalOptions of the text. By default is End.
<br/>
<br/>

### Property TextHorizontalOptions
This property is to set the HorizontalOptions of the text. By default is Start.
<br/>
<br/>

### Property SwitchHorizontalOptions
This property is to set the HorizonatlOptions of the switch. By default is start.
<br/>
<br/>

### Property Spacing
This property is to set the space between switch and text. By default is 10.
<br/>
<br/>

### Property IsToggled
This property is to set if the control is toggled or not. By default is False.
<br/>
<br/>

### Property IsEnabled
This property is to set if the control is enabled or not. By default is True.
<br/>
<br/>
