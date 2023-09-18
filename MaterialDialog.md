# MaterialDialog
Dialogs provide important prompts in a user flow.
<br/>
Currently, this control only represents the UI and guidelines proposed by Material, it doesn't provide the popup/alert behavior, you could resolve it with Rg.Plugins.Popup or with a similar implementation.
<br/>
[View Material Design documentation](https://m3.material.io/components/dialogs/overview)

## Screenshot
<img src="https://github.com/HorusSoftwareUY/MaterialDesignControlsPlugin/blob/master/screenshots/dialogs_preview.png" width="300">

## Example
```XML
<material3:MaterialDialog
    HeadlineText="Basic dialog"
    SupportingText="Basic dialog with an accept button and cancel button."
    AcceptText="Accept"
    AcceptCommand="{Binding AcceptCommand}"
    CancelText="Cancel"
    CancelCommand="{Binding CancelCommand}" />
```

## Documentation

