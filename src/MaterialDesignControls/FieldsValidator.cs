using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;

namespace Plugin.MaterialDesignControls
{
    public static class FieldsValidator
    {
        private class FieldControl
        {
            public string PageId { get; set; }
            public IFieldControl Control { get; set; }
        }

        private static List<FieldControl> FieldControls { get; set; } = new List<FieldControl>();

        internal static void RegisterControl(IFieldControl control)
        {
            FieldControls.Add(new FieldControl { PageId = null, Control = control });
        }

        public static void Initialize(object page)
        {
            if (FieldControls != null)
            {
                var pageId = page.GetType().Name;

                foreach (var control in FieldControls)
                {
                    if (control.PageId == null)
                    {
                        control.PageId = pageId;
                    }
                }

                FieldControls.RemoveAll(x => !x.PageId.Equals(pageId));

                var fieldControl = new List<FieldControl>();
                for (int i = FieldControls.Count - 1; i >= 0; i--)
                {
                    var control = FieldControls[i];
                    if (!fieldControl.Any(x => x.Control.FieldName.Equals(control.Control.FieldName)))
                    {
                        fieldControl.Add(control);
                    }
                }

                FieldControls = fieldControl;
            }
        }

        public static bool Validate()
        {
            var result = true;
            if (FieldControls != null)
            {
                foreach (var control in FieldControls)
                {
                    var controlIsValid = control.Control.Validate();
                    if (result)
                    {
                        result = controlIsValid;
                    }
                }
            }
            return result;
        }

        public static Dictionary<string, string> GetInvalidFields()
        {
            var result = new Dictionary<string, string>();
            if (FieldControls != null)
            {
                foreach (var control in FieldControls)
                {
                    var controlIsValid = control.Control.Validate();
                    if (!controlIsValid && !result.ContainsKey(control.Control.FieldName))
                    {
                        result.Add(control.Control.FieldName, control.Control.InvalidMessage);
                    }
                }
            }
            return result;
        }
    }
}
