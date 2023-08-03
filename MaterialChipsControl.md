# MaterialChips & MaterialChipsGroup
Chips are compact elements that represent an input, attribute, or action.
<br/>
[View Material Design documentation](https://material.io/components/chips)

## Screenshot
<img src="https://github.com/HorusSoftwareUY/MaterialDesignControlsPlugin/blob/master/screenshots/chips.gif" width="300">





## Documentation
 
### Example:

#### Example MaterialChips

```XML
<material:MaterialChips
    IsSelected="true"
    IsEnabled="true"
    Text="Option A"
    BackgroundColor="{StaticResource GradientColorTransparent2}"
    TextColor="{StaticResource GradientColor2}"
    SelectedBackgroundColor="{StaticResource GradientColor2}"
    SelectedTextColor="White" />
```

#### Example MaterialChipsGroup
```XML
<material:MaterialChipsGroup
    LabelText="Colors *"
    IsMultipleSelection="True"
    SelectedItems="{Binding SelectedColors}"
    ItemsSource="{Binding Colors}"
    ChipsPadding="16,0"
    ChipsHeightRequest="32"
    BackgroundColor="{StaticResource GradientColorTransparent2}"
    TextColor="{StaticResource GradientColor2}"
    SelectedBackgroundColor="{StaticResource GradientColor2}"
    SelectedTextColor="White"
    LabelTextColor="{StaticResource GradientColor2}"
    AssistiveText="Please select at least 4 colors"
    AssistiveTextColor="Red" />
```
<br/>
<br/>

### Property Type
Property to change the type of the MaterialChip.
#### Allowed Values:
- Assits
- Filter
- Input
- Suggestion
<br/>
<br/>

### Property Command
Command for MaterialChips when is selected or pressed.
<br/>
<br/>

### Property CommandParameter:
Command parameter for MaterialChips when is selected or pressed.
<br/>
<br/>

### Property IsEnabled:
This property is to set the if the MaterialChips control is enabled.
<br/>
<br/>

### Property IsSelected:
This property is to set the if the MaterialChips control is selected.
<br/>
<br/>

### Property Padding:
This property is to set the padding by default is 16 and 0 horizontally and vertically respectly.
<br/>
<br/>

### Property TextMargin:
This property is to set the TextMargin.
<br/>
<br/>

### Property BorderColor:
This property is to set the border color.
<br/>
<br/>

### Property LeadingIcon:
This property is to set the leading icon.
<br/>
<br/>

### Property CustomLeadingIcon:
This property is to set custom leading icon.
<br/>
<br/>

### Property LeadingIconIsVisible:
This property is to set if the leading icon is visible.
<br/>
<br/>

### Property TrailingIcon:
This property is to set the trailing icon.
<br/>
<br/>

### Property CustomTrailingIcon:
This property is to set custom trailing icon.
<br/>
<br/>

### Property TrailingIconIsVisible:
This property is to set if the trailing icon is visible.
<br/>
<br/>

### Property LeadingIconCommand:
This property is to set the leading command.
<br/>
<br/>

### Property LeadingIconCommandParameter:
This property is to set the leading command parameter.
<br/>
<br/>

### Property TrailingIconCommand:
This property is to set the trailing command.
<br/>
<br/>

### Property TrailingIconCommandParameter:
This property is to set the trailing command parameter.
<br/>
<br/>

### Property Text:
This property is to set the MaterialChips text.
<br/>
<br/>

### Property TextColor:
This property is to set the text color.
<br/>
<br/>

### Property SelectedTextColor:
This property is to set the selected text color.
<br/>
<br/>

### Property DisabledTextColor:
This property is to set the disabled selected text color.
<br/>
<br/>

### Property DisabledSelectedTextColor:
This property is to set the disabled selected text color.
<br/>
<br/>

### Property BackgroundColor:
This property is to set the background color.
<br/>
<br/>

### Property SelectedBackgroundColor:
This property is to set the selected background color.
<br/>
<br/>

### Property DisabledBackgroundColor:
This property is to set the disabled background color.
<br/>
<br/>

### Property DisabledSelectedBackgroundColor:
This property is to set the disabled selected background color.
<br/>
<br/>

### Property FontSize:
This property is to set the text font size.
<br/>
<br/>

### Property FontFamily:
This property is to set the text font family.
<br/>
<br/>

### Property CornerRadius:
This property is to set the corner radious.
<br/>
<br/>

### Property ToUpper:
This property is to set the if you wanna change the text to upper case.
<br/>
<br/>
