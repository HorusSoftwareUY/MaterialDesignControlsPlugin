# MaterialSegmentedControl
This control is a custom implementation of a segmented control. You can customize some properties that we show in Documentation topic. 

## Screenshot
<img src="https://github.com/HorusSoftwareUY/MaterialDesignControlsPlugin/blob/master/screenshots/segmented.jpg" width="300">

## how use?
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

## Documentation

### Property IsSelectedChanged
This property is to add an event when the value change on the control

### Property BackgroundColor
This property is to set the color of the control when it is enabled. By default is white

### Property DisabledBackgroundColor
This property is to set the color of the control when it is disabled. By default is white

### Property SelectedColor
This property is to set the color of the selected segment when it is enabled.

### Property DisabledSelectedColor
This property is to set the color of the selected segment when it is disabled.

### Property UnselectedColor
This property is to set the color of the unselected segments when it is enabled.

### Property DisabledUnselectedColor
This property is to set the color of the unselected segments when it is disabled.

### Property ItemsSource
This property is for displaying list of data.

### Property SelectedItem
This property is the selected item of the control.

### Property CornerRadius
This property is to set cornerradius of the control. By default is 16

### Property HeightRequest
This property is to set heightrequest of the control. By default is 32

### Property SegmentMargin
This property is to set the separation of each segment inside the control, this applies to left, top, right and bottom. by default is 2

### Property SelectedTextColor:
This property is to set the textcolor of the selected segment when it is enabled. By default is white

### Property DisabledSelectedTextColor:
This property is to set the textcolor of the selected segment when it is disabled. By default is white

### Property UnselectedTextColor:
This property is to set the textcolor of the unselected segments when it is enabled. By default is gray

### Property DisabledUnselectedTextColor:
This property is to set the textcolor of the unselected segments when it is disabled. By default is lightgray

### Property FontSize:
This property is to set the fontsize of the segment text

### Property FontFamily
This propperty is to set the fontfamily of the segment text

### Property IsEnabled
This property is to set if the control is enabled or not. By default is True

### Property Command
This property is to bind on the viewmodel

### Property CommandParameter
This property is to set the parameter of the Command property