# MaterialCheckboxControl
This control is a custom implementation of a Checkbox. You can customize some properties that we show in Documentation topic. 

## Screenshot
<img src="https://github.com/HorusSoftwareUY/MaterialDesignControlsPlugin/blob/master/screenshots/checkbox.jpg" width="300">

## how use?
```XML
 <material:MaterialSlider 
                    x:Name="checkbox" 
                    Text="Pickles"
                    IsChecked="True" 
                    Color="Blue"
                    Animation="Scale"/>
```

## Documentation

### Property IsCheckedChanged
This property is to add an event when the value change on the control

### Property Text:
This property is to set the text value

### Property TextColor:
This property is to set the color of the text when the control is enabled

### Property DisabledTextColor:
This property is to set the color of the text when the control is disabled

### Property FontSize:
This property is to set the fontsize of the text

### Property FontFamily
This propperty is to set the fontfamily of the text

### Property AssistiveText:
This property is to set the error text on the control. 

### Property AssistiveTextColor:
This property is to set the error text color value on the control.

### Property AssistiveSize:
This property is to set the error text font size value on the control. 

### Property AssistiveFontFamily:
This property is to set the error text font family value on the control.

### Property AssistiveMargin:
This property is to set the error text margin value on the control.

### Property AnimateError:
This property is to set if you can show a ShakeAnimation when there is a error with control.

### Property SelectedIcon
This property is to set the icon with .png when the control is enabled and it is checked

### Property UnselectedIcon
This property is to set the icon with .png when the control is enabled and it is unchecked

### Property DisabledSelectedIcon
This property is to set the icon with .png when the control is disabled and it is checked

### Property DisabledUnselectedIcon
This property is to set the icon with .png when the control is disabled and it is unchecked

### Property CustomSelectedIcon
This property is to set the icon with .svg when the control is enabled and it is checked

### Property CustomUnselectedIcon
This property is to set the icon with .svg when the control is enabled and it is unchecked

### Property CustomDisabledSelectedIcon
This property is to set the icon with .svg when the control is disabled and it is checked

### Property CustomDisabledUnselectedIcon
This property is to set the icon with .svg when the control is disabled and it is unchecked

### Property IconHeightRequest
This property is to set the HeightRequest of the icon. By default is 24

### Property IconWidthRequest
This property is to set the WidthRequest of the icon. By default is 24

### Property TextSide
This property is to set the side of the text, it could be: Right or Left. By default is Right

### Property TextHorizontalOptions
This property is to set the HorizontalOptions of the text. By default is Start

### Property SelectionHorizontalOptions
This property is to set the HorizonatlOptions of the icon. By default is start

### Property Spacing
This property is to set the space between icon and the text. By default is 10

### Property IsChecked
This property is to set if the control is checked or not. By default is False

### Property IsEnabled
This property is to set if the control is enabled or not. By default is True

### Property Animation
This property is to set the animation of the control: Scale, Fade, None. By default is None

### Property Color
This property is to set the color of the checkbox when it is enabled. It only applies when the Icon is not set.

### Property DisabledColor
This property is to set the color of the checkbox when it is disabled. It only applies when the Icon is not set.

### Property Command
This property is to bind to viewmodel when it the value changed.

### Property CommandParameter
This property is to send the parameter through Command.










