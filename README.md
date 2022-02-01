# MaterialDesignControls Plugin for Xamarin Forms

<img src="https://raw.githubusercontent.com/HorusSoftwareUY/MaterialDesignControlsPlugin/master/icon.png" width="128">

MaterialDesignControls Plugin for Xamarin Forms is a collection of Xamarin.Forms controls that apply the [Material Design Guidelines](https://material.io/design/components/selection-controls.html)

## Controls Index
- [MaterialButton](#materialbutton)
- [MaterialChips & MaterialChipsGroup](#materialchips_&_materialchipsgroup)
- [MaterialDatePicker](#materialdatepicker)
- [MaterialEditor](#materialeditor)
- [MaterialEntry](#materialentry)
- [MaterialCodeEntry](#materialcodeentry)
- [MaterialField](#materialfield)
- [MaterialPicker](#materialpicker)
- [MaterialDoublePicker](#materialdoublepicker)
- [MaterialSelection](#materialselection)
- [MaterialTimePicker](#materialtimepicker)
- [MaterialRatingControl](#materialratingcontrol)
- [MaterialSliderControl](#materialslidercontrol)
- [MaterialSegmented](#materialsegmented)
- [MaterialDivider](#materialdivider)
- [MaterialRadioButtons](#materialradiobuttons)
- [MaterialFloatingButton](#materialfloatingbutton)
- [MaterialCheckbox](#materialcheckbox)
- [MaterialSwitch](#materialswitch)

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
<img src="https://github.com/HorusSoftwareUY/MaterialDesignControlsPlugin/blob/master/screenshots/Controls_Final.gif" width="300">

## Controls

### MaterialButton
Buttons allow users to take actions, and make choices, with a single tap.
<br/>
<img src="https://github.com/HorusSoftwareUY/MaterialDesignControlsPlugin/blob/master/screenshots/button_preview.png" width="300">
<br/>
[View documentation](MaterialButtonControl.md)

---

### MaterialChips & MaterialChipsGroup
Chips are compact elements that represent an input, attribute, or action.
<br/>
<img src="https://github.com/HorusSoftwareUY/MaterialDesignControlsPlugin/blob/master/screenshots/chips_preview.png" width="300">
<br/>
[View documentation](MaterialChipsControl.md)

---

### MaterialDatePicker
Date pickers let users select a date.
<br/>
<img src="https://github.com/HorusSoftwareUY/MaterialDesignControlsPlugin/blob/master/screenshots/date_picker_preview.png" width="300">
<br/>
[View documentation](MaterialDatePickerControl.md)

---

### MaterialEditor
Text fields let users enter and edit text.
<br/>
<img src="https://github.com/HorusSoftwareUY/MaterialDesignControlsPlugin/blob/master/screenshots/editor_preview.png" width="300">
<br/>
[View documentation](MaterialEditorControl.md)

---

### MaterialEntry
Text fields let users enter and edit text.
<br/>
<img src="https://github.com/HorusSoftwareUY/MaterialDesignControlsPlugin/blob/master/screenshots/entry_preview.png" width="300">
<br/>
[View documentation](MaterialEntryControl.md)

---

### MaterialCodeEntry
Code fields let users enter and edit pin codes.
<br/>
<img src="https://github.com/HorusSoftwareUY/MaterialDesignControlsPlugin/blob/master/screenshots/code_preview.png" width="300">
<br/>
[View documentation](MaterialCodeEntryControl.md)

---

### MaterialField
Displays a value with its respective label in read-only format.
<br/>
<img src="https://github.com/HorusSoftwareUY/MaterialDesignControlsPlugin/blob/master/screenshots/field_preview.png" width="300">
<br/>
[View documentation](MaterialFieldControl.md)

---

### MaterialPicker
Pickers let users select an option.
<br/>
<img src="https://github.com/HorusSoftwareUY/MaterialDesignControlsPlugin/blob/master/screenshots/picker_preview.png" width="300">
<br/>
[View documentation](MaterialPickerControl.md)

---

### MaterialDoublePicker
Double pickers let users select two options in the same dialog.
<br/>
<img src="https://github.com/HorusSoftwareUY/MaterialDesignControlsPlugin/blob/master/screenshots/double_picker_preview.png" width="300">
<br/>
[View documentation](MaterialDoublePickerControl.md)

---

### MaterialSelection
Selection let users select an option.
<br/>
<img src="https://github.com/HorusSoftwareUY/MaterialDesignControlsPlugin/blob/master/screenshots/selection_preview.png" width="300">
<br/>
[View documentation](MaterialSelectionControl.md)

---

### MaterialTimePicker
Time pickers let users select a time.
<br/>
<img src="https://github.com/HorusSoftwareUY/MaterialDesignControlsPlugin/blob/master/screenshots/time_picker_preview.png" width="300">
<br/>
[View documentation](MaterialTimePickerControl.md)

---

### MaterialRatingControl
Displays a rating control
<br/>
<img src="https://github.com/HorusSoftwareUY/MaterialDesignControlsPlugin/blob/master/screenshots/rating_preview" width="300">
<br/>
[View documentation](MaterialRatingControl.md)

---

### MaterialSliderControl
Displays a slider control
<br/>
<img src="https://github.com/HorusSoftwareUY/MaterialDesignControlsPlugin/blob/master/screenshots/slider_preview.png" width="300">
<br/>
[View documentation](MaterialSliderControl.md)

---

### MaterialSegmented
Displays a segmented control
<br/>
<img src="https://github.com/HorusSoftwareUY/MaterialDesignControlsPlugin/blob/master/screenshots/segmented_preview.png" width="300">
<br/>
[View documentation](MaterialSegmentedControl.md)

---

### MaterialDivider
A divider is a thin line that groups content in lists and layouts.
<br/>
<img src="https://github.com/HorusSoftwareUY/MaterialDesignControlsPlugin/blob/master/screenshots/divider_preview.png" width="300">
<br/>
[View documentation](MaterialDividerControl.md)

---

### MaterialRadioButtons
Displays a radiobuttons control
<br/>
<img src="https://github.com/HorusSoftwareUY/MaterialDesignControlsPlugin/blob/master/screenshots/radio_preview.png" width="300">
<br/>
[View documentation](MaterialRadioButtonsControl.md)

---

### MaterialFloatingButton
Displays a floating button
<br/>
<img src="https://github.com/HorusSoftwareUY/MaterialDesignControlsPlugin/blob/master/screenshots/floating_button_preview.png" width="300">
<br/>
[View documentation](MaterialFloatingButton.md)

---

### MaterialCheckbox
Displays a checkbox control
<br/>
<img src="https://github.com/HorusSoftwareUY/MaterialDesignControlsPlugin/blob/master/screenshots/checkbox_preview.png" width="300">
<br/>
[View documentation](MaterialCheckboxControl.md)

---

### MaterialSwitch
Switches toggle the state of a single item on or off.
<br/>
<img src="https://github.com/HorusSoftwareUY/MaterialDesignControlsPlugin/blob/master/screenshots/switch_preview.png" width="300">
<br/>
[View documentation](MaterialSwitchControl.md)

---

<br/>

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
