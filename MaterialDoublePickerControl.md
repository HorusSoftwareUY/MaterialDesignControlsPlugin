# MaterialDoublePicker
Double pickers let users select two options in the same dialog.

## Screenshot
<img src="https://github.com/HorusSoftwareUY/MaterialDesignControlsPlugin/blob/master/screenshots/double_picker.gif" width="300">
<img src="https://github.com/HorusSoftwareUY/MaterialDesignControlsPlugin/blob/master/screenshots/double_picker.png" width="300"><img src="https://github.com/HorusSoftwareUY/MaterialDesignControlsPlugin/blob/master/screenshots/double_picker_android.png" width="300">

## Example MaterialDoubleickers
```XML
<material:MaterialDoublePicker 
    Type="Filled" LabelText="Double Picker" 
    Separator=" - "
    ItemsSource="{Binding ItemsSource}" 
    SecondaryItemsSource="{Binding SecondaryItemsSource}"
    SelectedItem="{Binding SelectedItem}" 
    SecondarySelectedItem="{Binding SecondarySelectedItem}" />
```