# MaterialSearch
MaterialSearch receives a text and executes a search action.
<br/>
[View Material Design documentation](https://m3.material.io/components/search/overview)

## Screenshot

<img src="https://github.com/HorusSoftwareUY/MaterialDesignControlsPlugin/blob/master/screenshots/search_preview.gif" width="300">

## Example MaterialButton
Using the control:
```XML
<material:MaterialSearch
    LabelMargin="0"
    Text="{Binding TextSearch}"
    SearchCommand="{Binding SearchCommand}"
    SearchOnEveryTextChange="{Binding SearchOnEveryTextChange}"
    Placeholder="Write text to search">
    <material3:MaterialSearch.CustomTrailingIcon>
        <ffimageloadingsvg:SvgCachedImage Source="resource://ExampleMaterialDesignControls.Resources.Svg.ic_search_b_w.svg" />
    </material3:MaterialSearch.CustomTrailingIcon>
</material:MaterialSearch>
<StackLayout Margin="0,24" BindableLayout.ItemsSource="{Binding ListStrings}">
    <BindableLayout.ItemTemplate>
        <DataTemplate x:DataType="viewmodel:ItemSearchSample">
            <material3:MaterialLabel
                Type="BodyLarge"
                Margin="0,10"
                Text="{Binding ValueString}" />
        </DataTemplate>
    </BindableLayout.ItemTemplate>
</StackLayout>
```

## Documentation

### Property Text:
This property is to set the search text<br/>

### Property SearchOnEveryTextChange:
This property determines whether the search will be triggered by the keyboard action button (false) or if it will occur each time a character is typed (true).<br/>

### Property SearchCommand:
This property is to set that will execute the search.
<br/>

### Property CommandParameter:
This property is to set the command parameter to the SearchCommand.
<br/>

### Property IsEnabled:
This property is to set if the button is enabled or disabled.
<br/>

### Property ButtonCustomAnimation:
This property is to set a custom animation when the button is tapped.
<br/>

### Property Text:
This property is to set the text of the button.
<br/>

### Property TextColor:
This property is to set the color of the button text.
<br/>

### Property DisabledTextColor:
This property is to set the disabled color of the button text.
<br/>

### Property BackgroundColor:
This property is to set the background color of the button.
<br/>

### Property DisabledBackgroundColor:
This property is to set the disabled background color of the button.
<br/>

### Property FontSize:
This property is to set the font size of the button text.
<br/>

### Property FontFamily:
This property is to set the font family of the button text.
<br/>

### Property CornerRadius:
This property is to set the corner radius of the button.
<br/>

### Property BorderColor:
This property is to set the border color of the button.
<br/>

### Property DisabledBorderColor:
This property is to set the disabled border color of the button.
<br/>

### Property LeadingIcon:
This property is to set the leading icon with support for view, you can use SVG, font icon, PNG, JPG or JPEG.
<br/>

### Property TrailingIcon:
This property is to set the trailing icon with support for view, you can use SVG, font icon, PNG, JPG or JPEG.
<br/>

