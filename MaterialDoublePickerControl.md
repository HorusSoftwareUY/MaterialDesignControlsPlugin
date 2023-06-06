# MaterialDoublePicker
Double pickers let users select two options in the same dialog.

## Screenshot
<!-- TODO: Change this  -->
<img src="https://github.com/HorusSoftwareUY/MaterialDesignControlsPlugin/blob/master/screenshots/double_picker.gif" width="300">

## Android Screenshot
<!-- TODO: Change this  -->
<img src="https://github.com/HorusSoftwareUY/MaterialDesignControlsPlugin/blob/master/screenshots/double_picker_android.png" width="300">

## Example MaterialDoublePickers

Using the control:

```XML
<material:MaterialDoublePicker 
    LabelText="Double Picker" 
    Separator=" - "
    ItemsSource="{Binding ItemsSource}" 
    SecondaryItemsSource="{Binding SecondaryItemsSource}"
    SelectedItem="{Binding SelectedItem}" 
    SecondarySelectedItem="{Binding SecondarySelectedItem}" />
```


## Documentation
We update this control to use VisualStateManager (See examble above). So we recommend use visual state to change the style of the control. 

### Allowed States:
- Normal
- Focused
- Disabled


#### Example:

Set style:

```XML
<Style TargetType="material3:MaterialDoublePicker">
        <Setter Property="AnimateError"
                Value="True" />
        <Setter Property="SupportingTextColor"
                Value="#c92726" />
        <Setter Property="SupportingSize"
                Value="12" />
        <Setter Property="FontSize"
                Value="16" />
        <Setter Property="PlaceholderColor"
                Value="#66839b" />
        <Setter Property="LabelSize"
                Value="12" />
        <Setter Property="BackgroundColor"
                Value="#0d2e85cc" />
        <Setter Property="TrailingIcon"
                Value="arrow_drop_down.png" />
        <Setter Property="VisualStateManager.VisualStateGroups">
        <VisualStateGroupList>
                <VisualStateGroup x:Name="CommonStates">
                <VisualState x:Name="Normal">
                        <VisualState.Setters>
                        <Setter Property="TextColor"
                                Value="#0d1a26" />
                        <Setter Property="LabelTextColor"
                                Value="#2e85cc" />
                        <Setter Property="IndicatorColor"
                                Value="#2e85cc" />
                        <Setter Property="BorderColor"
                                Value="#2e85cc" />
                        <Setter Property="BackgroundColor"
                                Value="#0d2e85cc" />
                        </VisualState.Setters>
                </VisualState>
                <VisualState x:Name="Disabled">
                        <VisualState.Setters>
                        <Setter Property="TextColor"
                                Value="#828282" />
                        <Setter Property="LabelTextColor"
                                Value="#828282" />
                        <Setter Property="IndicatorColor"
                                Value="#828282" />
                        <Setter Property="BorderColor"
                                Value="#828282" />
                        <Setter Property="BackgroundColor"
                                Value="#E3E3E3" />
                        </VisualState.Setters>
                </VisualState>
                <VisualState x:Name="Focused">
                        <VisualState.Setters>
                        <Setter Property="TextColor"
                                Value="#0d1a26" />
                        <Setter Property="LabelTextColor"
                                Value="#1f5988" />
                        <Setter Property="IndicatorColor"
                                Value="#1f5988" />
                        <Setter Property="BorderColor"
                                Value="#1f5988" />
                        <Setter Property="BackgroundColor"
                                Value="#1A2e85cc" />
                        </VisualState.Setters>
                </VisualState>
                </VisualStateGroup>
        </VisualStateGroupList>
        </Setter>
</Style>
``` 
<br/>
<br/>

### Property CornerRadius:
This property is to set the corner radius for the control. This is used only when you set HasBorder as true.
```XML
<material3:MaterialDoublePicker
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

### Property FontSize:
This property is to set the font size.
<br/>
<br/>

### Property FontFamily:
This property is to set the font family.
<br/>
<br/> 

### Property Placeholder:
This property is to set the placeholder.
<br/>
<br/>

### Property PlaceholderColor:
This property is to set the placeholder color.
<br/>
<br/>

### Property AnimatePlaceholder:
If you set this property to true the placeholder will be translated to label place. **you mustn't set Label Text**
<br/>
<br/>

### Property LabelText:
This property is to set the label.
<br/>
<br/>

### Property LabelTextColor:
This property is to set the label color.
<br/>
<br/>

### Property LabelSize:
This property is to set the label size.
<br/>
<br/>

### Property LabelFontFamily:
This property is to set the label font family.
<br/>
<br/>

### Property LabelMargin:
This property is to set the label margin family.. By default uses (16,0,16,0).
<br/>
<br/>

### Property SupportingText:
This property is to set the supporting text..
<br/>
<br/>

### Property SupportingTextColor:
This property is to set the supporting text..
<br/>
<br/>

### Property SupportingSize:
This property is to set the supporting text..
<br/>
<br/>

### Property SupportingFontFamily:
This property is to set the supporting text font family..
<br/>
<br/>

### Property SupportingMargin:
This property is to set the supporting text margin.. By default uses (16,4,16,0).
<br/>
<br/>

### Property BorderColor:
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

### Property SecondaryItemsSource:
This property is to set the secondary items source
#### If you use a custom object, we recommend set *PropertyPath* property with the name of the property that you want to show its value in the picker list. In other case you must override ToString method (use by default) or use a string list.
<br/>
<br/>

### Property SecondarySelectedItem:
This property is to set the secondary selected item. 
<br/>
<br/>

### Property PropertyPath:
This property is to set name of the property that you want to show its value in the picker list using *ItemsSource*.
<br/>
<br/>

### Property SecondaryPropertyPath:
This property is to set name of the property that you want to show its value in the picker list using *SecondaryItemsSource*.
<br/>
<br/>

### Property SelectedIndex:
This property is to get the selected index
<br/>
<br/>

### Property SecondarySelectedIndex:
This property is to get the selected index
<br/>
<br/>

### Property Separator:
This property is to set the separator. Ex. " - "
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



