# MaterialSegmentedControl
This control is a custom implementation of a segmented control. You can customize some properties that we show in Documentation topic. 

## Screenshot
<img src="https://github.com/HorusSoftwareUY/MaterialDesignControlsPlugin/blob/master/screenshots/segmented.gif" width="300">

## Example MaterialSegmented
```XML
 <material:MaterialSegmented 
    x:Name="segmented" 
    HeightRequest="40"
    BackgroundColor="#58555A"
    ItemsSource="{Binding Backlight}"
    UnselectedColor="#58555A"
    SelectedColor="#D9D277"
    UnselectedTextColor="#D9D277"
    CornerRadius="10"/>
```
<br/>

## Documentation
<br/>

### Property IsSelectedChanged
This property is to add an event when the value change on the control.
<br/>
<br/>

### Property BackgroundColor
This property is to set the color of the control when it is enabled. By default is white.
<br/>
<br/>

### Property DisabledBackgroundColor
This property is to set the color of the control when it is disabled. By default is white.
<br/>
<br/>

### Property SelectedColor
This property is to set the color of the selected segment when it is enabled.
<br/>
<br/>

### Property DisabledSelectedColor
This property is to set the color of the selected segment when it is disabled.
<br/>
<br/>

### Property UnselectedColor
This property is to set the color of the unselected segments when it is enabled.
<br/>
<br/>

### Property DisabledUnselectedColor
This property is to set the color of the unselected segments when it is disabled.
<br/>
<br/>

### Property ItemsSource
This property is for displaying list of data.
<br/>
<br/>

### Property SelectedItem
This property is the selected item of the control.
<br/>
<br/>

### Property CornerRadius
This property is to set cornerradius of the control. By default is 16.
<br/>
<br/>

### Property HeightRequest
This property is to set heightrequest of the control. By default is 32.
<br/>
<br/>

### Property SegmentMargin
This property is to set the separation of each segment inside the control, this applies to left, top, right and bottom. by default is 2.
<br/>
<br/>

### Property SelectedTextColor:
This property is to set the textcolor of the selected segment when it is enabled. By default is white.
<br/>
<br/>

### Property DisabledSelectedTextColor:
This property is to set the textcolor of the selected segment when it is disabled. By default is white.
<br/>
<br/>

### Property UnselectedTextColor:
This property is to set the textcolor of the unselected segments when it is enabled. By default is gray.
<br/>
<br/>

### Property DisabledUnselectedTextColor:
This property is to set the textcolor of the unselected segments when it is disabled. By default is lightgray.
<br/>
<br/>

### Property FontSize:
This property is to set the fontsize of the segment text.
<br/>
<br/>

### Property FontFamily
This propperty is to set the fontfamily of the segment text.
<br/>
<br/>

### Property IsEnabled
This property is to set if the control is enabled or not. By default is True.
<br/>
<br/>

### Property Command
This property is to bind on the viewmodel.
<br/>
<br/>

### Property CommandParameter
This property is to set the parameter of the Command property.