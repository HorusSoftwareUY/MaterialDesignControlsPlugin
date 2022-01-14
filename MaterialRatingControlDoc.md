# MaterialRatingControl
This control allow to rate. You can customize some properties that we show in Documentation topic. To clear the rating, you can tap on the selected item.

## Screenshot
<img src="https://github.com/HorusSoftwareUY/MaterialDesignControlsPlugin/blob/master/screenshots/selection.jpg" width="300">

## how use?
```XML
 <material:MaterialRatingControl x:Name="mrcWithoutSelectionPng" LabelText="How do you rate the service?" ItemSize="5"
 ItemsByRow="5" SelectedIcon="startSelected.png" UnSelectedIcon="starUnselected.png"
TabIndex="1"  />
```

## Documentation

### Property SelectedIcon:
This property is to select the icon that the control will use to selected item. You can use image file types like png, jpg, etc.

### Property CustomSelectedIcon:
This property is to select the icon that the control will use to selected item. You can use svgs.

### Property UnSelectedIcon:
This property is to select the icon that the control will use to unselected items. You can use image file types like png, jpg, etc.

### Property CustomUnSelectedIcon:
This property is to select the icon that the control will use to unselected items. You can use svgs.

### Property ItemSize:
This property is to set the quantity of items that you want to use, by default is null.

### Property ItemsByRow:
This property is to set the quantity of items that you want to use by row, by default is null.


### Property IsEnabled:
This property is to set if the control is enabled or not.

### Property Value:
This property is to set the value of the control. This can use to get the value of rating.

### Property LabelText:
This property is to set the label text value on the control.

### Property LabelTextColor:
This property is to set the label text color value on the control. 

### Property LabelSize:
This property is to set the label text font size value on the control. 

### Property AssistiveText:
This property is to set the error text on the control. 


### Property AssistiveTextColor:
This property is to set the error text color value on the control. By default is gray. 

### Property AssistiveSize:
This property is to set the error text font size value on the control. By default is gray. 


### Property AnimateError:
This property is to set if you can show a ShakeAnimation when there is a error with control. If the user doesn't rate.

## Animations:
you can animate the efect on pressed a item of rating control: currently supports fade and scale.

### Property Animation:
This property is to set the animation type on touch the item.

### Property AnimationParameter:
This property is to set the parameter of the animation.

