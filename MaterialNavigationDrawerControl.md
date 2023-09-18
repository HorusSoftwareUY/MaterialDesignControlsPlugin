# MaterialNavigationDrawer
Navigation drawers let people switch between UI views on larger devices
<br/>
[View Material Design documentation](https://m3.material.io/components/navigation-drawer/overview)

## Screenshot
<img src="https://github.com/HorusSoftwareUY/MaterialDesignControlsPlugin/blob/master/screenshots/navigation_preview.png" width="300">

## Example
```XML
<material3:MaterialNavigationDrawer
    Headline="Mail"
    Command="{Binding TestCommand}"
    ItemsSource="{Binding Items}" />
```

## Documentation

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

### Property ActiveIndicatorBackgroundColor:
This property is to set the active indicator background color.
<br/>

### Property ActiveIndicatorLabelColor:
This property is to set the active indicator label color.
<br/>

### Property ActiveIndicatorCornerRadius:
This property is to set the active indicator corner radius. By default is 28.
<br/>

### Property LabelColor:
This property is to set the label text color.
<br/>

### Property LabelFontSize:
This property is to set the label text font size.
<br/>

### Property LabelFontFamily:
This property is to set the label text font family.
<br/>

### Property SectionLabelColor:
This property is to set the section label text color.
<br/>

### Property SectionLabelFontSize:
This property is to set the section label text font size.
<br/>

### Property SectionLabelFontFamily:
This property is to set the section label text font family.
<br/>

### Property DividerColor:
This property is to set the divider color.
<br/>

### Property BadgeType:
This property is to set the badge type.
<br/>

### Property BadgeTextColor:
This property is to the text color of the badge. ***it's only supported on Large type***
<br/>

### Property BadgeFontSize:
This property is to the font size of the badge. ***it's only supported on Large type***
<br/>

### Property BadgeFontFamily:
This property is to the font family of the badge. ***it's only supported on Large type***
<br/>

### Property BadgeBackgroundColor:
This property is to set the badge background color.
<br/>

### Property ItemsSource
This property is for displaying list of data. You should set a List of MaterialNavigationDrawerItem.
Its definition is:
- Text (string) :  Text showed
- BadgeText (string) :  Text showed in the badge
- Section (string) :  This property is to dive the items in sections
- SelectedIcon (string): Icon used when item is selected
- CustomSelectedIcon (view): Custom view used the item is selected
- UnselectedIcon (string): Icon used when item is Unselected
- CustomUnselectedIcon (view): Custom view used when item is Unselected
- IsSelected (bool) : by default you can select an item
- ShowActivityIndicator (bool) : show the activity indicator when the item is selected. By default is true.
- IsEnabled (bool) : enable or disabled the item. by default is true.
<br/>

### Property Command
This property is to bind on the viewmodel.
<br/>

### Property Animation:
This property is to set the animation when the item is tapped.
<br/>

#### Allowed values
- None
- Fade (Default)
- Scale
- Custom
<br/>

### Property AnimationParameter:
This property is to customize the animation when the item is tapped.
<br/>

### Property CustomAnimation:
This property is to set a custom animation when the item is tapped.
<br/>