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
