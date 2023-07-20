# MaterialTopAppBar
TopAppBar displays information and actions at the top of a screen.
<br/>
[View Material Design documentation](https://m3.material.io/components/top-app-bar/overview)

## Screenshot
<img src="https://github.com/HorusSoftwareUY/MaterialDesignControlsPlugin/blob/master/screenshots/topappbar_preview.png" width="300">

## Example MaterialTopAppBar
```XML
 <material3:MaterialTopAppBar
    HeadlineColor="Black"
    Headline="Type - CenterAligned"
    LeadingIconCommand="{Binding BackCommand}"
    Type="CenterAligned">
    <material3:MaterialTopAppBar.LeadingIcon>
        <ffimageloadingsvg:SvgCachedImage Source="resource://ExampleMaterialDesignControls.Resources.Svg.ic_back_blue.svg" />
    </material3:MaterialTopAppBar.LeadingIcon>
</material3:MaterialTopAppBar>
```

## Documentation

### Property Type:
#### Allowed values
- CenterAligned (Default)
- Small
- Medium
- Large
<br/>
<br/>

### Property HeadLine:
This property is to set the headline text.
<br/>

### Property HeadlineColor:
This property is to set the headline text color.
<br/>

### Property HeadlineFontSize:
This property is to set the headline text font size.
<br/>

### Property HeadlineFontFamily:
This property is to set the headline text font family.
<br/>

### Property HeadlineMarginAdjustment:
This property is to set the headline text margin to adjust it.
<br/>

### Property Description:
This property is to set the description text.
<br/>

### Property DescriptionColor:
This property is to set the description text color.
<br/>

### Property DescriptionFontSize:
This property is to set the description text font size.
<br/>

### Property DescriptionFontFamily:
This property is to set the description text font family.
<br/>

### Property DescriptionMarginAdjustmentProperty:
This property is to set the description text margin to adjust it.
<br/>

### Property LeadingIcon:
This property is to set the leading icon with support for view, you can use SVG, font icon, PNG, JPG or JPEG.
<br/>

### Property TrailingIcon:
This property is to set the trailing icon with support for view, you can use SVG, font icon, PNG, JPG or JPEG.
<br/>

### Property IconSize:
This property is to set the sizes to the trailing and leading icons.
<br/>

### Property LeadingIconCommand:
This property is to set the leading icon command.
<br/>

### Property TrailingIconCommand:
This property is to set the trailing icon command.
<br/>

### Property ButtonAnimation:
This property is to set the animation of the leading and trailing icons.
<br/>

#### Allowed values
- None
- Fade (Default)
- Scale
- Custom
<br/>

### Property ButtonAnimationParameter:
This property is to customize the animation of the leading and trailing icons.
<br/>

### Property ButtonCustomAnimation:
This property is to set a custom animation to the leading and trailing icons.
<br/>

### Property ScrollViewName:
This property is to bind the control to a ScrollView and run an animation when scrolling down.
<br/>

### Property TrailingIconIsBusy:
This property is to show a busy indicator in the trailing icon.
<br/>

### Property LeadingIconIsBusy:
This property is to show a busy indicator in the leading icon.
<br/>

### Property BusyColor:
This property is to set the color of the busy indicators.
<br/>