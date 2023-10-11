# MaterialPicker
Pickers let users select an option.

## Screenshot
<img src="https://github.com/HorusSoftwareUY/MaterialDesignControlsPlugin/blob/master/screenshots/picker.gif" width="300">

## Example
```XML
    <material3:MaterialPicker x:Name="pckColors"
        AnimateError="True"
        PlaceholderColor="{StaticResource PlaceholderColor}"
        ItemsSource="{Binding ItemsSourceColors}"
        AnimatePlaceholder="True"
        Placeholder="Select a Color"
        SelectedItem="{Binding SelectedItemColor}" />
```

## Documentation

### Property CornerRadius:
This property is to set the corner radius for the control. This is used only when you set HasBorder as true.
```XML
<material3:MaterialPicker
    Placeholder="Select the color"
    SupportingText="Color is required"
    AnimateError="True"
    TabIndex="1"
    ReturnType="Next"
    HasBorder="True"
    CornerRadius="10"
    CornerRadiusTopLeft="True"
    SupportingTextColor="Red" />
```
<br/>
<br/>

### Property CornerRadiusTopLeft:
This property is to set if you wanna top left rounded.
<br/>
<br/>

### Property CornerRadiusTopRight:
This property is to set if you wanna top right rounded.
<br/>
<br/>

### Property CornerRadiusBottomRight:
This property is to set if you wanna bottom right rounded.
<br/>
<br/>

### Property CornerRadiusBottomLeft:
This property is to set if you wanna bottom left rounded.
<br/>
<br/>

### Property AnimateError:
This property is to set the if you want or not animate the control on error.
<br/>
<br/>

### Property HorizontalTextAlignment:
This property is to set the horizontal text alignment.
#### Allowed Values:
- Start
- Center
- End
<br/>
<br/>

### Property TextColor:
This property is to set the text color.
<br/>
<br/>

### Property FocusedTextColor:
This property is to set the focused text color.
<br/>
<br/>

### Property DisabledTextColor:
This property is to set the disabled text color.
<br/>
<br/>

### Property FontSize:
This property is to set the font size.
<br/>
<br/>

### Property FontFamily:
This property is to set the font family.
<br/>
<br/> 

### Property Placeholder:
This property is to set the placeholder of the material picker.
<br/>
<br/>

### Property PlaceholderColor:
This property is to set the placeholder color of the material picker.
<br/>
<br/>

### Property AnimatePlaceholder:
If you set this property to true the placeholder will be translated to label place. **you mustn't set Label Text**
<br/>
<br/>

### Property LabelText:
This property is to set the label of the material picker.
<br/>
<br/>

### Property LabelTextColor:
This property is to set the label color of the material picker.
<br/>
<br/>

### Property FocusedLabelTextColor:
This property is to set the focused label color.
<br/>
<br/>

### Property DisabledLabelTextColor:
This property is to set the disabled label color.
<br/>
<br/>

### Property LabelSize:
This property is to set the label size of the material picker.
<br/>
<br/>

### Property LabelFontFamily:
This property is to set the label font family of the material picker.
<br/>
<br/>

### Property LabelMargin:
This property is to set the label margin family of the material picker. By default uses (16,0,16,0).
<br/>
<br/>

### Property SupportingText:
This property is to set the supporting text of the material picker.
<br/>
<br/>

### Property SupportingTextColor:
This property is to set the supporting text color of the material picker.
<br/>
<br/>

### Property SupportingSize:
This property is to set the supporting text size of the material picker.
<br/>
<br/>

### Property SupportingFontFamily:
This property is to set the supporting text font family of the material picker.
<br/>
<br/>

### Property SupportingMargin:
This property is to set the supporting text margin of the material picker. By default uses (16,4,16,0).
<br/>
<br/>

### Property BorderColor:
This property is to set the border color. This is enabled when you set the property HasBorder equals true.
<br/>
<br/>

### Property FocusedBorderColor:
This property is to set the focused border color. This is enabled when you set the property HasBorder equals true.
<br/>
<br/>

### Property DisabledBorderColor:
This property is to set the border color. This is enabled when you set the property HasBorder equals true.
<br/>
<br/>

### Property HasBorder:
This property is to set if this control has border or not.
<br/>
<br/>

### Property iOSBorderWidth:
This property is to set the border width. **Only supported on iOS**
<br/>
<br/>

### Property IndicatorColor:
This property is to set the indicator color.
<br/>
<br/>

### Property BackgroundColor:
This property is to set the background color.
<br/>
<br/>

### Property LeadingIcon:
This property is to set the leading icon. This can be png or jpg.
<br/>
<br/>

### Property CustomLeadingIcon:
This property is to set the leading icon with support to svg.
<br/>
<br/>

### Property LeadingIconCommand:
This property is to set the leading icon command.
<br/>
<br/>

### Property LeadingIconCommandParameter:
This property is to set the leading icon command parameter.
<br/>
<br/>

### Property TrailingIcon:
This property is to set the trailing icon. This can be png or jpg.
<br/>
<br/>

### Property CustomTrailingIcon:
This property is to set the trailing icon with support to svg.
<br/>
<br/>

### Property TrailingIconCommand:
This property is to set the trailing icon command.
<br/>
<br/>

### Property TrailingIconCommandParameter:
This property is to set the trailing icon command parameter.
<br/>
<br/>

### Property ItemsSource:
This property is to set the items source
#### If you use a custom object, we recommend set *PropertyPath* property with the name of the property that you want to show its value in the picker list. In other case you must override ToString method (use by default) or use a string list.
<br/>
<br/>

### Property SelectedItem:
This property is to set the selected item. 
<br/>
<br/>

### Property PropertyPath:
This property is to set name of the property that you want to show its value in the picker list.
<br/>
<br/>

### Property LabelLineBreakMode:
This property is to set the Label Line Break Mode
#### Allowed values
- NoWrap,
- WordWrap,
- CharacterWrap,
- HeadTruncation,
- TailTruncation,
- MiddleTruncation
<br/>
<br/>

### Property SupportingLineBreakMode:
This property is to set the Supporting LineBreakMode.
#### Allowed values
- NoWrap,
- WordWrap,
- CharacterWrap,
- HeadTruncation,
- TailTruncation,
- MiddleTruncation
<br/>
<br/>

### Property MultilineEnabled:
This property is to set the Multiline Enabled
<br/>
<br/>

### Property PickerRowHeight:
This property is to set the picker row height.
<br/>
<br/>

### Property SelectedIndex:
This property is to get the selected index
<br/>
<br/>

