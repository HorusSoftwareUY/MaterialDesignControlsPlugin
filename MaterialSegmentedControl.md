# MaterialSegmentedControl
This control is a custom implementation of a segmented control. You can customize some properties that we show in Documentation topic.
<br/>
[View Material Design documentation](https://m3.material.io/components/segmented-buttons/overview)

## Screenshot
<img src="https://github.com/HorusSoftwareUY/MaterialDesignControlsPlugin/blob/master/screenshots/segmented.gif" width="300">

## Example MaterialSegmented
```XML
<material3:MaterialSegmented BackgroundColor="White"
                            Command="{Binding SelectCommand}"
                            CornerRadius="20"
                            HeightRequest="50"
                            AllowMultiselect="True"
                            ItemsSource="{Binding Sizes}"
                            SelectedColor="#8959c0"
                            SelectedItem="{Binding SelectedSize}"
                            UnselectedColor="White"
                            UnselectedTextColor="#8959c0" />
```
<br/>


#### Example:

Set style:

```XML

<Style TargetType="material3:MaterialSegmented">
    <Setter Property="DisabledBackgroundColor"
            Value="#f2f2f2" />
    <Setter Property="DisabledSelectedColor"
            Value="#808080" />
    <Setter Property="DisabledUnselectedColor"
            Value="{StaticResource WhiteColor}" />
    <Setter Property="DisabledSelectedTextColor"
            Value="{StaticResource WhiteColor}" />
    <Setter Property="DisabledUnselectedTextColor"
            Value="#808080" />
    <Setter Property="DisabledBorderColor"
            Value="#808080" />
    <Setter Property="BackgroundColor"
            Value="#eaf3fa" />
    <Setter Property="SelectedColor"
            Value="#2e85cc" />
    <Setter Property="UnselectedColor"
            Value="#eaf3fa" />
    <Setter Property="SelectedTextColor"
            Value="{StaticResource WhiteColor}" />
    <Setter Property="UnselectedTextColor"
            Value="#2e85cc" />
    <Setter Property="BorderColor"
            Value="#2e85cc" />
</Style>
``` 
<br/>
<br/>

## Documentation
<br/>

### Property Type
This property is to select the type of the MaterialSegmented control. By default is Outlined
### Allowed Types:
- Filled
- Outlined
<br/>
<br/>

### Property IsSelectedChanged
This property is to add an event when the value change on the control.
<br/>
<br/>

### Property BorderColor
This property is to set the color of the border control when it is enabled. By default is gray. **This property only works with type Outlined**
<br/>
<br/>

### Property BackgroundColor
This property is to set the color of the control when it is enabled. By default is white. **This property only works with type Filled**
<br/>
<br/>

### Property DisabledBackgroundColor
This property is to set the color of the control when it is disabled. By default is white. **This property only works with type Filled**
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

### Property AllowMultiselect
This property is to set if you want to allow multiselect items.
<br/>
<br/>

### Property ItemsSource
This property is for displaying list of data. You should set a List of MaterialSegmentedItem.
Its definition is:
- Text (string) :  Text showed
- SelectedIcon (string): Icon used when item is selected
- CustomSelectedIcon (view): Custom view used the item is selected
- UnselectedIcon (string): Icon used when item is Unselected
- CustomUnselectedIcon (view): Custom view used when item is Unselected
- IsSelected (bool) : by default you can select an item or items in case multiple select is allowed.
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
This property is to set heightrequest of the control. By default is 42.
<br/>
<br/>

### Property SegmentMargin
This property is to set the separation of each segment inside the control, this applies to left, top, right and bottom. by default is 0.
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