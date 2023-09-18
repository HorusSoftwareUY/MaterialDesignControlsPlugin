# MaterialCustomControl
This control provides a simple way to create custom controls with labels and support text that follow the Material Design Guidelines.
<br/>

## Screenshot

<img src="https://github.com/HorusSoftwareUY/MaterialDesignControlsPlugin/blob/master/screenshots/customcontrol_preview.png" width="300">

## Example
```XML
<material3:MaterialCustomControl
    AnimateError="True"
    SupportingText="{Binding AssistiveText}"
    LabelText="Value">
    <material3:MaterialCustomControl.CustomControl>
        <Slider />
    </material3:MaterialCustomControl.CustomControl>
</material3:MaterialCustomControl>
```
<br/>

## Documentation
<br/>

### Property LabelText:
This property is to set the label.
<br/>
<br/>

### Property LabelTextColor:
This property is to set the label color.
<br/>
<br/>

### Property DisabledLabelTextColor:
This property is to set the disabled label color.
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
This property is to set the label margin family. By default uses (16,0,16,0).
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

### Property SupportingText:
This property is to set the supporting text.
<br/>
<br/>

### Property SupportingTextColor:
This property is to set the supporting text color.
<br/>
<br/>

### Property SupportingSize:
This property is to set the supporting text size.
<br/>
<br/>

### Property SupportingFontFamily:
This property is to set the supporting text font family.
<br/>
<br/>

### Property SupportingMargin:
This property is to set the supporting text margin. By default uses (16,4,16,0).
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

### Property HorizontalTextAlignment:
This property is to set the horizontal text alignment.
#### Allowed Values:
- Start
- Center
- End
<br/>
<br/>

### Property AnimateError:
This property is to set if you can show a ShakeAnimation when there is a error with control. If the user doesn't rate.
<br/>
<br/>