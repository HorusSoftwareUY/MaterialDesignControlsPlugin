using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Platform.Tizen;

namespace Plugin.MaterialDesignControls.Tizen
{
    [Preserve(AllMembers = true)]
    public static class Effects
    {
        private static List<PlatformEffect> _allEffects = new List<PlatformEffect>();

        public static void Init()
        {
            _allEffects = new List<PlatformEffect>(typeof(Effects).Assembly.GetTypes()
                .Where(t => typeof(PlatformEffect).IsAssignableFrom(t))
                .Select(t => (PlatformEffect)Activator.CreateInstance(t)));
        }
    }
}
