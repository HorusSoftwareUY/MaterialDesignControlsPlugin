# MaterialEntry
Text fields let users enter and edit text.

## Screenshot
<img src="https://github.com/HorusSoftwareUY/MaterialDesignControlsPlugin/blob/master/screenshots/entry.png" width="300">

## Example
```XML
<material:MaterialEntry
    Type="Filled"
    LabelText="Name *"
    Placeholder="Enter your name"
    MaxLength="50"
    Text="{Binding Name}"
    AssistiveText="Name is required"
    AnimateError="True"
    TabIndex="1"
    ReturnType="Next"
    LabelTextColor="{StaticResource GradientColor5}"
    TextColor="{StaticResource GradientColor5}"
    PlaceholderColor="{StaticResource GradientColor5}"
    BackgroundColor="{StaticResource GradientColorTransparent5}"
    BorderColor="{StaticResource GradientColor5}"
    AssistiveTextColor="Red" />
```
