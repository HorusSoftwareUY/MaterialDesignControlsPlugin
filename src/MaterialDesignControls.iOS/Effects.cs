using System;
using System.Collections.Generic;
using System.Linq;
using Foundation;
using Xamarin.Forms.Platform.iOS;

namespace Plugin.MaterialDesignControls.iOS
{
    [Preserve(AllMembers = true)]
    public static class Effects
    {
        private static List<PlatformEffect> _allEffects = new List<PlatformEffect>();

        public static void Init()
        {
            // Prevent stripping by linker
            new TouchAndPressEffect();

            _allEffects = new List<PlatformEffect>(typeof(Effects).Assembly.GetTypes()
                .Where(t => typeof(PlatformEffect).IsAssignableFrom(t))
                .Select(t => (PlatformEffect)Activator.CreateInstance(t)));
        }
    }
}
