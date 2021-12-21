# MaterialDesignControls Plugin for Xamarin Forms

<img src="https://raw.githubusercontent.com/HorusSoftwareUY/MaterialDesignControlsPlugin/master/icon.png" width="128">

MaterialDesignControls Plugin for Xamarin Forms is a collection of Xamarin.Forms controls that apply the [Material Design Guidelines](https://material.io/design/components/selection-controls.html)

## Setup
* Available on NuGet: [Plugin.MaterialDesignControls](https://www.nuget.org/packages/Plugin.MaterialDesignControls/) [![NuGet](https://img.shields.io/nuget/v/Plugin.MaterialDesignControls.svg?label=NuGet)](https://www.nuget.org/packages/Plugin.MaterialDesignControls/)
* Install into your PCL project and Client projects.

**Platform Support**

|Platform|Version|
| ------------------- | :------------------: |
|Xamarin.iOS|iOS 8+|
|Xamarin.Android|API 16+|
|Xamarin.Forms|>= 4.4.0.991864|

## API Usage

You must add this line to your platform specific project (`AppDelegate.cs`, `MainActivity.cs`) before you use MaterialDesignControls:

if you're using **iOS**:
```C#
Plugin.MaterialDesignControls.iOS.Renderer.Init();           
```

or if you're using **Android**:
```C#
Plugin.MaterialDesignControls.Android.Renderer.Init();           
```
You must add this namespace to your xaml files:

```XML
xmlns:material="clr-namespace:Plugin.MaterialDesignControls;assembly=Plugin.MaterialDesignControls"
```

## Sample
<img src="https://github.com/HorusSoftwareUY/MaterialDesignControlsPlugin/blob/master/screenshots/Controls.gif" width="300">
<img src="https://github.com/HorusSoftwareUY/MaterialDesignControlsPlugin/blob/master/screenshots/Controls_Final.gif" width="300">

## Controls

### MaterialButton
Buttons allow users to take actions, and make choices, with a single tap.

**Screenshot**

<img src="https://github.com/HorusSoftwareUY/MaterialDesignControlsPlugin/blob/master/screenshots/button.png" width="300">

**Example**
```XML
<material:MaterialButton Text="Save" Icon="save.png" Command="{Binding TapCommand}" CommandParameter="Saved" />
```

### MaterialChip
Chips are compact elements that represent an action.

**Screenshot**

<img src="https://github.com/HorusSoftwareUY/MaterialDesignControlsPlugin/blob/master/screenshots/chips.png" width="300">

**Example**
```XML
<material:MaterialChips IsSelected="true" IsEnabled="true" Text="Option A" />
```

### MaterialEntry
Text fields let users enter and edit text.

**Screenshot**

<img src="https://github.com/HorusSoftwareUY/MaterialDesignControlsPlugin/blob/master/screenshots/entry.png" width="300">

**Example**
```XML
<material:MaterialEntry Type="Filled" LabelText="Name" Placeholder="Enter your name"
                        IsRequired="true" RequiredMessage="The name is required" MaxLength="12" />
```

### MaterialCodeEntry
Code fields let users enter and edit pin codes.

**Screenshot**

<img src="https://github.com/HorusSoftwareUY/MaterialDesignControlsPlugin/blob/master/screenshots/code.png" width="300">

**Example**
```XML
<material:MaterialCodeEntry Type="Filled" LabelText="Code*" Length="6" Keyboard="Numeric" Text="{Binding Code}" />
```

### MaterialDatePicker
Date pickers let users select a date.

**Screenshot**

<img src="https://github.com/HorusSoftwareUY/MaterialDesignControlsPlugin/blob/master/screenshots/date_picker.png" width="300">

**Example**
```XML
<material:MaterialDatePicker Type="Filled" LabelText="Start date" Format="yyyy-MM-dd" LeadingIcon="calendar.png" />
```

### MaterialTimePicker
Time pickers let users select a time.

**Screenshot**

<img src="https://github.com/HorusSoftwareUY/MaterialDesignControlsPlugin/blob/master/screenshots/time_picker.png" width="300">

**Example**
```XML
<material:MaterialTimePicker Type="Filled" LabelText="Start time" Format="HH:mm" LeadingIcon="calendar.png" />
```

### MaterialPicker
Pickers let users select an option.

**Screenshot**

<img src="https://github.com/HorusSoftwareUY/MaterialDesignControlsPlugin/blob/master/screenshots/picker.png" width="300">

**Example**
```XML
<material:MaterialPicker Type="Filled" LabelText="Color"
                         IsRequired="true" RequiredMessage="The color is required" />
```

### MaterialDoublePicker
Double pickers let users select two options in the same dialog.

**Screenshot**

<img src="https://github.com/HorusSoftwareUY/MaterialDesignControlsPlugin/blob/master/screenshots/double_picker.png" width="300"><img src="https://github.com/HorusSoftwareUY/MaterialDesignControlsPlugin/blob/master/screenshots/double_picker_android.png" width="300">

**Example**
```XML
<material:MaterialDoublePicker Type="Filled" LabelText="Double Picker" Separator=" - "
                               ItemsSource="{Binding ItemsSource}" SecondaryItemsSource="{Binding SecondaryItemsSource}"
                               SelectedItem="{Binding SelectedItem}" SecondarySelectedItem="{Binding SecondarySelectedItem}" />
```

### MaterialEditor
Text fields let users enter and edit text.

**Screenshot**

<img src="https://github.com/HorusSoftwareUY/MaterialDesignControlsPlugin/blob/master/screenshots/editor.png" width="300">

**Example**
```XML
<material:MaterialEditor Type="Outlined" LabelText="Description" Placeholder="Enter your description" 
                         LeadingIcon="email.png" HeightRequest="200" />
```

### MaterialSelection
Selection let users select an option.

**Screenshot**

<img src="https://github.com/HorusSoftwareUY/MaterialDesignControlsPlugin/blob/master/screenshots/selection.png" width="300">

**Example**
```XML
<material:MaterialSelection Type="Filled" LeadingIcon="calendar.png" LabelText="User" Placeholder="Select user" Text="User A" 
                            Command="{Binding TapCommand}" CommandParameter="User selection" />
```


### MaterialSliderControl
Displays a slider control<br/>
[View documentation](MaterialSliderControl.md)

**Screenshot**

<img src="https://github.com/HorusSoftwareUY/MaterialDesignControlsPlugin/blob/master/screenshots/slider.png" width="300">

**Example**
```XML
 <material:MaterialSlider 
                    x:Name="slider" 
                    MinimumValue="0" 
                    MaximumValue="100" 
                    ThumbColor="BlueViolet"
                    LabelText="Slider"
                    ActiveTrackColor="BlueViolet"
                    InactiveTrackColor="LightPink"/>
```

### MaterialFloatingButton
Displays a floating button<br/>
[View documentation](MaterialFloatingButton.md)

**Screenshot**

<img src="https://github.com/HorusSoftwareUY/MaterialDesignControlsPlugin/blob/master/screenshots/floating_button.png" width="300">

**Example**
```XML
<material:MaterialFloatingButton
    Icon="add_b.png"
    BackgroundColor="#FAF9D5"
    Animation="Scale"
    FontSize="12"
    ShadowColor="Black"/>
```

### MaterialField
Displays a value with its respective label in read-only format.

**Screenshot**

<img src="https://github.com/HorusSoftwareUY/MaterialDesignControlsPlugin/blob/master/screenshots/field.png" width="300">

**Example**
```XML
<material:MaterialField LabelText="Mail" Text="michael.jordan@hotmail.com" LeadingIcon="email.png" />
```
### MaterialCheckbox
Displays a checkbox control<br/>
[View documentation](MaterialCheckboxControl.md)

**Screenshot**

<img src="https://github.com/HorusSoftwareUY/MaterialDesignControlsPlugin/blob/master/screenshots/checkbox.png" width="300">

**Example**
```XML
 <material:MaterialCheckbox 
                    x:Name="checkbox" 
                    Text="Pickles"
                    IsChecked="True" 
                    Color="Blue"
                    Animation="Scale"/>
```

### MaterialRadioButtons
Displays a radiobuttons control<br/>
[View documentation](MaterialRadioButtonsControl.md)

**Screenshot**

<img src="https://github.com/HorusSoftwareUY/MaterialDesignControlsPlugin/blob/master/screenshots/radiobuttons.png" width="300">

**Example**
```XML
 <material:MaterialRadioButtons
                    x:Name="radiobuttons" 
                    LabelText="Rigtones" 
                    ItemsSource="{Binding Rigtones}"
                    Animation="Scale"/>
```

### MaterialSwitch
Displays a switch control<br/>
[View documentation](MaterialSwitchControl.md)

**Screenshot**

<img src="https://github.com/HorusSoftwareUY/MaterialDesignControlsPlugin/blob/master/screenshots/switch.png" width="300">

**Example**
```XML
 <material:MaterialSwitch x:Name="switch" Text="Wifi" IsToggled="True"/>
```

## Effects

### TouchAndPressEffect
Effect to detect the different types of taps on a view: Pressing, Released and Canceled can be detected.

**Example**
```XML
<MyControl.Effects>
    <material:TouchAndPressEffect />
</MyControl.Effects>
```

```C#
public class MyControl : ContentView, ITouchAndPressEffectConsumer
{
    public void ConsumeEvent(EventType gestureType)
    {
        TouchAndPressAnimation.Animate(this, gestureType);
    }
}
```

## Demo
https://github.com/HorusSoftwareUY/MaterialDesignControlsPlugin/tree/master/example
 
## Developed by
<a href="http://horus.com.uy" ><img src="https://horus.com.uy/img/logo_horus.png" width="128"></a>

## Contributions
Contributions are welcome! If you find a bug want a feature added please report it.

If you want to contribute code please file an issue, create a branch, and file a pull request.

## License 
MIT License - see LICENSE.txt
