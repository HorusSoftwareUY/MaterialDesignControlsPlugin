# MaterialRadioButtonsControl
This control is a custom implementation of a radiobuttons. You can customize some properties that we show in Documentation topic. 

## Screenshot
<img src="https://github.com/HorusSoftwareUY/MaterialDesignControlsPlugin/blob/master/screenshots/radiobuttons.jpg" width="300">

## how use?
```XML
 <material:MaterialRadioButtons
                    x:Name="radiobuttons" 
                    LabelText="Rigtones" 
                    ItemsSource="{Binding Rigtones}"
```

## Documentation

### Property Toggled
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

### Property TextSide
This property is to set the side of the text, it could be: Right or Left. By default is Right

### Property TextVerticalOptions
This property is to set the VerticalOptions of the text. By default is End

### Property TextHorizontalOptions
This property is to set the HorizontalOptions of the text. By default is Start

### Property SwitchHorizontalOptions
This property is to set the HorizonatlOptions of the switch. By default is start

### Property Spacing
This property is to set the space between switch and text. By default is 10

### Property IsToggled
This property is to set if the control is toggled or not. By default is False

### Property IsEnabled
This property is to set if the control is enabled or not. By default is True

### Property Animation
This property is to set the animation of the control: Scale, Fade, None. By default is None

### Property OnColor
This property is to set the color when the switch is toggled

### Property ThumbColor
This property is to define the switch color when it is toggled

