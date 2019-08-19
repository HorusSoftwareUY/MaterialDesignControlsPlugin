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

            public string ControlId
            {
                get
                {
                    return $"{PageId}-{Control?.FieldName}";
                }
            }
        }

        private static List<FieldControl> FieldControls { get; set; } = new List<FieldControl>();

        private static List<IFieldControl> RegisteredControls { get; set; } = new List<IFieldControl>();

        internal static void RegisterControl(IFieldControl control)
        {
            if (RegisteredControls == null)
            {
                RegisteredControls = new List<IFieldControl>();
            }

            RegisteredControls.Add(control);

            System.Diagnostics.Debug.WriteLine($"Plugin.MaterialDesignControls.FieldsValidator - RegisterControl - {control.FieldName}");
        }

        public static void Initialize(object page)
        {
            if (FieldControls == null)
            {
                FieldControls = new List<FieldControl>();
            }

            var pageId = page.GetType().Name;

            if (RegisteredControls != null)
            {
                foreach (var control in RegisteredControls)
                {
                    var newControl = new FieldControl { PageId = pageId, Control = control };

                    if (FieldControls.Any(x => x.ControlId.Equals(newControl.ControlId)))
                    {
                        FieldControls.RemoveAll(x => x.ControlId.Equals(newControl.ControlId));
                    }

                    FieldControls.Add(newControl);

                    System.Diagnostics.Debug.WriteLine($"Plugin.MaterialDesignControls.FieldsValidator - Initialize - {newControl.ControlId}");
                }
            }

            RegisteredControls = new List<IFieldControl>();
        }

        public static bool Validate(object page)
        {
            var pageId = page.GetType().Name;

            var result = true;
            if (FieldControls != null)
            {
                foreach (var control in FieldControls.Where(x => x.PageId.Equals(pageId)))
                {
                    var controlIsValid = control.Control.Validate();
                    if (result)
                    {
                        result = controlIsValid;
                    }

                    System.Diagnostics.Debug.WriteLine($"Plugin.MaterialDesignControls.FieldsValidator - Validate - {control.ControlId} - IsValid: {controlIsValid}");
                }
            }
            return result;
        }

        public static Dictionary<string, string> GetInvalidFields(object page)
        {
            var pageId = page.GetType().Name;

            var result = new Dictionary<string, string>();
            if (FieldControls != null)
            {
                foreach (var control in FieldControls.Where(x => x.PageId.Equals(pageId)))
                {
                    var controlIsValid = control.Control.Validate();
                    if (!controlIsValid && !result.ContainsKey(control.Control.FieldName))
                    {
                        result.Add(control.Control.FieldName, control.Control.InvalidMessage);
                    }

                    System.Diagnostics.Debug.WriteLine($"Plugin.MaterialDesignControls.FieldsValidator - Validate - {control.ControlId} - IsValid: {controlIsValid} - Message: {control.Control.InvalidMessage}");
                }
            }
            return result;
        }

        public static void Dispose(object page)
        {
            var pageId = page.GetType().Name;

            if (FieldControls != null)
            {
                FieldControls.RemoveAll(x => x.PageId.Equals(pageId));
            }
        }
    }
}
