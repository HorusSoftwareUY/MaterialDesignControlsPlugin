# MaterialFloatingButton
This control is a custom implementation of a floating action button. You can customize some properties that we show in Documentation topic. 

## Screenshot
<img src="https://github.com/HorusSoftwareUY/MaterialDesignControlsPlugin/blob/master/screenshots/floating_button.png" width="300">

## how use?
```XML
 <material:MaterialFloatingButton
    Icon="add_b.png"
    BackgroundColor="#FAF9D5"
    Animation="Scale"

    FontSize="14"
    ShadowColor="Black"/>
```

## Documentation

### Property ShadowColor:
This property is to set the shadow color

### Property Icon:
This property is to set the icon of the button with .png files

### Property DisabledIcon:
This property is to set the icon of the button when .png files when the property IsEnabled is False

### Property CustomIcon:
This property is to set the icon of the button with .svg files

### Property DisabledIcon:
This property is to set the icon of the button when .svg files when the property IsEnabled is False

### Property IconHeightRequest:
This property is to set the HeightRequest of the icon

### Property IconWidthRequest:
This property is to set the WidthRequest of the icon

### Property BackgroundColor:
This property is to set the color of the button

### Property DisabledBackgroundColor:
This property is to set the color of the button when property IsEnabled is False

### Property Animation:
This property is to set the button's animation. It could be: None, Fade or Scale

### Property FontSize:
This property is to set the fontsize of the text

### Property FontFamily:
This property is to set the fontfamily of the text

### Property FontAttributes:
This property is to set the fontattributes of the text

### Property ButtonSize:
This property is to set the size of button. It coulb be: Regular, Mini or Extended. By default is Regular

### Property Text:
This property is to set the text of the button. This only appears when ButtonSize is Extended

### Property TextColor:
This property is to set the color of the text

### Property DisabledTextColor:
This property is to set the color of the text when the property IsEnabled is False

### Property ToUpper:
This property is to convert text to uppercase

### Property IconSide:
This property is to set if the icon will be in the right or left side. This only applies when ButtonSize is extended

### Property CornerRadius:
This property is to set corner radius of the button

### Property HasShadow 
This property is to set if the button will have shadow or not

### Property HeightRequest
This property is to set HeightRequest of the button

### Property WidthRequest
This property is to set WidthRequest of the button

### Property Padding
This property is to set Padding of the button

### Property Clicked
This property is to add a event when button is clicked

### Property Command
This property is to bind on the viewmodel

### Property CommandParameter
This property is to set the parameter of the Command property








