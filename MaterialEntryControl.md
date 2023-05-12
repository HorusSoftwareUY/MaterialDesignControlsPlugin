# MaterialEntry
Text fields let users enter and edit text.
<br/>
[View Material Design documentation](https://material.io/components/text-fields)

## Screenshot
<!-- TODO: Improve this  -->
<img src="https://github.com/HorusSoftwareUY/MaterialDesignControlsPlugin/blob/master/screenshots/entry.gif" width="300">

## Example MaterialEntry
Using the control:

```XML
<material3:MaterialEntry
    LabelText="Name *"
    Placeholder="Enter your name"
    MaxLength="50"
    Text="{Binding Name}"
    SupportingText="Name is required"
    AnimateError="True"
    TabIndex="1"
    ReturnType="Next"
    SupportingTextColor="Red" />
```
<br/>

## Documentation
We update this control to use VisualStateManager (See examble above). So we recommend use visual state to change the style of the control. 
### Allowed States:
- Normal
- Focused
- Disabled
#### Example:

Set style:

```XML
<Style TargetType="material3:MaterialEntry">
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

### Property Keyboard
Default keyboard and base class for specialized keyboards, such as those for telephone numbers, email, URLs and others.
#### Allowed Values:
- Plain
- Chat
- Email
- Numeric
- Telephone
- Text
- URL
<br/>
<br/>

### Property KeyboardFlags
Enumerates keyboard option flags that controls capitalization, spellcheck, suggestion behavior and others. 
#### Allowed Values:
- CapitalizeSentence
- Spellcheck
- Suggestions
- CapitalizeWord
- CapitalizeCharacter
- CapitalizeNone
- All
- None
#### Usage Example
- Using only one flag
```XML
<material3:MaterialEntry
    LabelText="Name *"
    Placeholder="Enter your name"
    MaxLength="50"
    KeyboardFlags="CapitalizeWord"
    Text="{Binding Name}"
    SupportingText="Name is required"
    AnimateError="True"
    TabIndex="1"
    ReturnType="Next"
    SupportingTextColor="Red" />
```
- Using multiple flags
```XML
<material3:MaterialEntry
    LabelText="Name *"
    Placeholder="Enter your name"
    MaxLength="50"
    KeyboardFlags="CapitalizeWord|Suggestions"
    Text="{Binding Name}"
    SupportingText="Name is required"
    AnimateError="True"
    TabIndex="1"
    ReturnType="Next"
    SupportingTextColor="Red" />
```
<br/>
<br/>

### Property TextTransform:
This property is to set a text transform.
#### Allowed Values:
- Default
- Lowercase
- Uppercase
<br/>
<br/>

### Property ReturnType:
This property is to set the keyboard return button style,
#### Allowed Values:
- Done
- Go
- Next
- Search
- Send
<br/>
<br/>

### Property ReturnCommand:
This property is to set the behavior after click on return button.
<br/>
<br/>

### Property Text:
This property is to set the current text.
<br/>
<br/>

### Property MaxLength:
This property is to set the max length of the text.
<br/>
<br/>

### Property CursorPosition:
This property is to set the cursor position.
<br/>
<br/>

### Property TextChanged:
This property is to set the event after the text changed.
<br/>
<br/>

### Property FieldHeightRequest:
This property is to set the height of the Material Entry
<br/>
<br/>

### Property CornerRadius:
This property is to set the corner radius for the control. This is used only when you set HasBorder as true.
```XML
<material3:MaterialEntry
    LabelText="Name *"
    Placeholder="Enter your name"
    Text="{Binding Name}"
    SupportingText="Name is required"
    AnimateError="True"
    TabIndex="1"
    ReturnType="Next"
    HasBorder="True"
    CornerRadius="10"
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
This property is to set the placeholder of the material entry.
<br/>
<br/>

### Property PlaceholderColor:
This property is to set the placeholder color of the material entry.
<br/>
<br/>

### Property AnimatePlaceholder:
If you set this property to true the placeholder will be translated to label place.
<br/>
<br/>

### Property LabelText:
This property is to set the label of the material entry.
<br/>
<br/>

### Property LabelTextColor:
This property is to set the label color of the material entry.
<br/>
<br/>

### Property LabelSize:
This property is to set the label size of the material entry.
<br/>
<br/>

### Property LabelFontFamily:
This property is to set the label font family of the material entry.
<br/>
<br/>

### Property LabelMargin:
This property is to set the label margin family of the material entry. By default uses (16,0,16,0).
<br/>
<br/>

### Property SupportingText:
This property is to set the supporting text of the material entry.
<br/>
<br/>

### Property SupportingTextColor:
This property is to set the supporting text color of the material entry.
<br/>
<br/>

### Property SupportingSize:
This property is to set the supporting text size of the material entry.
<br/>
<br/>

### Property SupportingFontFamily:
This property is to set the supporting text font family of the material entry.
<br/>
<br/>

### Property SupportingMargin:
This property is to set the supporting text margin of the material entry. By default uses (16,4,16,0).
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

### Property IsPassword:
This property is to set if this control behaves as password entry.
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