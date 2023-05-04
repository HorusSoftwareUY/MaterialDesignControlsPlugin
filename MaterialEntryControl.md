# MaterialEntry
Text fields let users enter and edit text.
<br/>
[View Material Design documentation](https://material.io/components/text-fields)

## Screenshot
<!-- TODO: Improve this  -->
<img src="https://github.com/HorusSoftwareUY/MaterialDesignControlsPlugin/blob/master/screenshots/entry.gif" width="300">

## Example MaterialEntry
Use this style:

```XML
<Style TargetType="material3:MaterialEntry"
        x:Key="BaseMaterial3Style">
    <Setter Property="AnimateError"
            Value="True" />
    <Setter Property="SupportingTextColor"
            Value="{StaticResource SupportingTextColor}" />
    <Setter Property="SupportingSize"
            Value="{StaticResource Body3FontSize}" />
    <Setter Property="FontSize"
            Value="{StaticResource Body1FontSize}" />
    <Setter Property="PlaceholderColor"
            Value="{StaticResource PlaceholderColor}" />
    <Setter Property="LabelSize"
            Value="{StaticResource Body3FontSize}" />
    <Setter Property="BackgroundColor"
            Value="{StaticResource BackgroundMaterialColor}" />
    <Setter Property="CornerRadius"
            Value="15" />
</Style>

<!--MaterialEntry-->
<Style TargetType="material3:MaterialEntry"
        BasedOn="{StaticResource BaseMaterial3Style}">
    <Setter Property="VisualStateManager.VisualStateGroups">
        <VisualStateGroupList>
            <VisualStateGroup x:Name="CommonStates">
                <VisualState x:Name="Normal">
                    <VisualState.Setters>
                        <Setter Property="TextColor"
                                Value="{StaticResource TextColor}" />
                        <Setter Property="LabelTextColor"
                                Value="{StaticResource GradientColor1}" />
                        <Setter Property="IndicatorColor"
                                Value="{StaticResource GradientColor1}" />
                        <Setter Property="BorderColor"
                                Value="{StaticResource GradientColor1}" />
                        <Setter Property="BackgroundColor"
                                Value="{StaticResource BackgroundMaterialColor}" />
                    </VisualState.Setters>
                </VisualState>
                <VisualState x:Name="Disabled">
                    <VisualState.Setters>
                        <Setter Property="TextColor"
                                Value="{StaticResource DarkGrayColor}" />
                        <Setter Property="LabelTextColor"
                                Value="{StaticResource DarkGrayColor}" />
                        <Setter Property="IndicatorColor"
                                Value="{StaticResource DarkGrayColor}" />
                        <Setter Property="BorderColor"
                                Value="{StaticResource DarkGrayColor}" />
                        <Setter Property="BackgroundColor"
                                Value="{StaticResource GrayColor}" />
                    </VisualState.Setters>
                </VisualState>
                <VisualState x:Name="Focused">
                    <VisualState.Setters>
                        <Setter Property="TextColor"
                                Value="{StaticResource TextColor}" />
                        <Setter Property="LabelTextColor"
                                Value="{StaticResource BorderMaterialColor}" />
                        <Setter Property="IndicatorColor"
                                Value="{StaticResource BorderMaterialColor}" />
                        <Setter Property="BorderColor"
                                Value="{StaticResource BorderMaterialColor}" />
                        <Setter Property="BackgroundColor"
                                Value="{StaticResource GradientColorTransparent1}" />
                    </VisualState.Setters>
                </VisualState>
            </VisualStateGroup>
        </VisualStateGroupList>
    </Setter>
</Style>
``` 

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
<br/>

### Property ValueChanged
This property is to add an event when the value change on the control.
<br/>
<br/>

### Property LabelText:
This property is to set the label text value.
<br/>
<br/>

### Property LabelTextColor:
This property is to set the color of the label text when the control is enabled.
<br/>
<br/>

### Property DisabledLabelTextColor:
This property is to set the color of the label text when the control is disabled.
<br/>
<br/>

### Property LabelSize:
This property is to set the fontsize of the label text.
<br/>
<br/>

### Property LabelMinimumText:
This property is to set the label minimum value.
<br/>
<br/>

### Property LabelMinimumTextColor:
This property is to set the color of the label minimum when control is enabled.
<br/>
<br/>

### Property DisabledLabelMinimumTextColor:
This property is to set the color of the label minimum when control is disable.
<br/>
<br/>

### Property LabelMinimumSize:
This property is to set the font size of the label minimum.
<br/>
<br/>

### Property LabelMaximumText:
This property is to set the label maximum text value on the control.
<br/>
<br/>

### Property LabelMaximumTextColor:
This property is to set the label maximum text color value on the control enabled.
<br/>
<br/>

### Property DisabledLabelMaximumTextColor:
This property is to set the label text maximum color value on the control. When the control is disabled.
<br/>
<br/>

### Property AssistiveText:
This property is to set the error text on the control. 
<br/>
<br/>

### Property AssistiveTextColor:
This property is to set the error text color value on the control. By default is gray.
<br/>
<br/> 

### Property AssistiveSize:
This property is to set the error text font size value on the control. By default is gray. 
<br/>
<br/>

### Property AnimateError:
This property is to set if you can show a ShakeAnimation when there is a error with control.
<br/>
<br/>

### Property MinimumIcon:
This property is to set the image to minimum to types of images like png, jpg.
<br/>
<br/>

### Property CustomMinimumIcon:
This property is to set the image to minimum with support to svg. 
<br/>
<br/>

### Property MaximumIcon:
This property is to set the image to maximum to types of images like png, jpg.
<br/>
<br/>

### Property CustomMaximumIcon:
This property is to set the image to maximum with support to svg.
<br/>
<br/>

### Property BackgroundImage:
This property is to set the background image to control, this allow jpg, png.
<br/>
<br/>

### Property CustomBackgroundImage:
This property is to set the background image to control, this allow svg.
<br/>
<br/>

### Property ThumbImage:
This property is to set the thumb with a image.
<br/>
<br/>

### Property Value:
This property is to set the value of the control, by default is the minimum.
<br/>
<br/>

### Property MinimumValue:
This property is to set the minimum value, by default is 0.
<br/>
<br/>

### Property MaximumValue:
This property is to set the minimum value, by default is 1.
<br/>
<br/>

### Property ActiveTrackColor:
This property is to set the active tracker color.
<br/>
<br/>

### Property InactiveTrackColor:
This property is to set the inactive tracker color.
<br/>
<br/>

### Property ThumbColor:
This property is to set the color of thumb.
<br/>
<br/>

### Property TrackHeight:
This property is to set the height of the thumb.
<br/>
<br/>

### Property TrackCornerRadius:
This property is to set the corner radious of the track.
<br/>
<br/>

### Property UserInteractionEnabled:
This property is to set the if the interaction of the user is enabled.
<br/>
<br/>

### Property ShowIcons:
This property is to set if show or not the icons.
<br/>
<br/>

### Property DisabledActiveTrackColor:
This property is to set the disabled active track color, when the control is disabled.
<br/>
<br/>

### Property DisabledInactiveTrackColor:
This property is to set the disabled inactive track color, when the control is disabled.
<br/>
<br/>

### Property DisabledThumbColor:
This property is to set the disabled thumb color, whe the control is disabled.
