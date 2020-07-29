using Xamarin.Forms;

namespace ExampleMaterialDesignControls.Tizen
{
    class Program : global::Xamarin.Forms.Platform.Tizen.FormsApplication
    {
        protected override void OnCreate()
        {
            base.OnCreate();
            LoadApplication(new App());
        }

        static void Main(string[] args)
        {
            var app = new Program();
            Forms.Init(app, true);
            Plugin.MaterialDesignControls.Tizen.Renderer.Init();
            app.Run(args);
        }
    }
}
