# MaterialRatingControl
This control allow to rate. You can customize some properties that we show in Documentation topic. To clear the rating, you can tap on the selected item.
<br/>

## Screenshot

<img src="https://github.com/HorusSoftwareUY/MaterialDesignControlsPlugin/blob/master/screenshots/rating.gif" width="300">

## Example MaterialRating
```XML
<material:MaterialRatingControl 
    x:Name="mrcWithoutSelectionPng"    
    LabelText="How do you rate...?(png icons)"   
    ItemSize="5"                                             
    ItemsByRow="5" 
    Animation="Fade" 
    AnimationParameter="0.1" 
    SelectedIcon="starSelected.png" 
    UnSelectedIcon="starUnselected.png"  />
```
<br/>

## Documentation
<br/>

### Property SelectedIcon:
This property is to select the icon that the control will use to selected item. You can use image file types like png, jpg, etc.
<br/>
<br/>

### Property CustomSelectedIcon:
This property is to select the icon that the control will use to selected item. You can use svgs.
<br/>
<br/>

### Property UnSelectedIcon:
This property is to select the icon that the control will use to unselected items. You can use image file types like png, jpg, etc.
<br/>
<br/>

### Property CustomUnSelectedIcon:
This property is to select the icon that the control will use to unselected items. You can use svgs.
<br/>
<br/>

### Property ItemSize:
This property is to set the quantity of items that you want to use, by default is null.
<br/>
<br/>

### Property ItemsByRow:
This property is to set the quantity of items that you want to use by row, by default is null.
<br/>
<br/>

### Property IsEnabled:
This property is to set if the control is enabled or not.
<br/>
<br/>

### Property Value:
This property is to set the value of the control. This can use to get the value of rating.
<br/>
<br/>

### Property LabelText:
This property is to set the label text value on the control.
<br/>
<br/>

### Property LabelTextColor:
This property is to set the label text color value on the control. 
<br/>
<br/>

### Property LabelSize:
This property is to set the label text font size value on the control. 
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
This property is to set if you can show a ShakeAnimation when there is a error with control. If the user doesn't rate.
<br/>
<br/>
<br/>
<br/>

## Animations:
You can animate the efect on pressed a item of rating control: currently supports fade and scale.
<br/>
<br/>

### Property Animation:
This property is to set the animation type on touch the item.
<br/>
<br/>

### Property AnimationParameter:
This property is to set the parameter of the animation.