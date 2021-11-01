﻿using System.Windows.Input;
using ExampleMaterialDesignControls.Pages;
using Xamarin.Forms;

namespace ExampleMaterialDesignControls.ViewModels
{
    public class MaterialControlsPageViewModel : BaseViewModel
    {
        public ICommand GoMaterialButtonCommand => new Command (async () =>
        {
            await Navigation.PushAsync(new MaterialButtonPage());
        });

        public ICommand GoMaterialSliderCommand => new Command(async () =>
        {
            await Navigation.PushAsync(new MaterialSliderPage());
        });

        public ICommand GoMaterialRatingCommand => new Command(async () =>
        {
            await Navigation.PushAsync(new MaterialRatingControlPage());
        });

        public ICommand GoMaterialChipsCommand => new Command(async () =>
        {
            await Navigation.PushAsync(new MaterialChipsPage());
        });

        public ICommand GoMaterialDatePickerCommand => new Command(async () =>
        {
            await Navigation.PushAsync(new MaterialDatePickerPage());
        });

        public ICommand GoMaterialEditorCommand => new Command(async () =>
        {
            await Navigation.PushAsync(new MaterialEditorPage());
        });

        public ICommand GoMaterialEntryCommand => new Command(async () =>
        {
            await Navigation.PushAsync(new MaterialEntryPage());
        });

        public ICommand GoMaterialCodeEntryCommand => new Command(async () =>
        {
            await Navigation.PushAsync(new MaterialCodeEntryPage());
        });

        public ICommand GoMaterialFieldCommand => new Command(async () =>
        {
            await Navigation.PushAsync(new MaterialFieldPage());
        });

        public ICommand GoMaterialPickerCommand => new Command(async () =>
        {
            await Navigation.PushAsync(new MaterialPickerPage());
        });

        public ICommand GoMaterialSelectionCommand => new Command(async () =>
        {
            await Navigation.PushAsync(new MaterialSelectionPage());
        });

        public ICommand GoMaterialTimePickerCommand => new Command(async () =>
        {
            await Navigation.PushAsync(new MaterialTimePickerPage());
        });

        public ICommand GoMaterialCustomControlCommand => new Command(async () =>
        {
            await Navigation.PushAsync(new MaterialCustomControl());
        });
    }
}