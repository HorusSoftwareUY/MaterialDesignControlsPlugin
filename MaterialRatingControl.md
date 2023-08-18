# MaterialRating
This control allow to rate. You can customize some properties that we show in Documentation topic. To clear the rating, you can tap on the selected item.
<br/>

## Screenshot

<img src="https://github.com/HorusSoftwareUY/MaterialDesignControlsPlugin/blob/master/screenshots/rating.gif" width="300">

## Example MaterialRating
```XML
<material3:MaterialRating
    LabelText="How do you rate...?"
    SelectedIcon="starSelected.png" 
    UnSelectedIcon="starUnselected.png" />
```
<br/>

## Documentation
<br/>

### Property UseSameIcon:
This property is to set if use the same icon for all items or use a different icon for item.
<br/>
<br/>

### Property CustomSelectedIconsSource:
This property is to set the icons for all items when an item is selected, you can use svgs. (Icon from first item is the first icon in the collection)
<br/>
<br/>

### Property SelectedIconsSource:
This property is to set the icons for all items when an item is selected, You can use image file types like png, jpg, etc. (Icon from first item is the first icon in the collection)
<br/>
<br/>

### Property SelectedIcon:
This property is to select the icon that the control will use to selected item. You can use image file types like png, jpg, etc.
<br/>
<br/>

### Property CustomSelectedIcon:
This property is to select the icon that the control will use to selected item. You can use svgs.
<br/>
<br/>

### Property UnselectedIcon:
This property is to select the icon that the control will use to unselected items. You can use image file types like png, jpg, etc.
<br/>
<br/>

### Property CustomUnselectedIcon:
This property is to select the icon that the control will use to unselected items. You can use svgs.
<br/>
<br/>

### Property CustomUnselectedIconsSource:
This property is to set the icons for all items when an item is unselected, you can use svgs. (Icon from first item is the first icon in the collection)
<br/>
<br/>

### Property UnelectedIconsSource:
This property is to set the icons for all items when an item is unselected, You can use image file types like png, jpg, etc. (Icon from first item is the first icon in the collection)
<br/>
<br/>

### Property ItemSize:
This property is to set the quantity of items that you want to use, by default is 5.
<br/>
<br/>

### Property ItemsByRow:
This property is to set the quantity of items that you want to use by row, by default is 5.
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

### Property Animation:
This property is to set the animation type on touch the item.
<br/>
<br/>

### Property AnimationParameter:
This property is to set the parameter of the animation.