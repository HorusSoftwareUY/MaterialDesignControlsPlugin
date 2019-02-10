using System;
namespace Plugin.MaterialDesignControls
{
    public interface IFieldControl
    {
        string FieldName { get; set; }
        string InvalidMessage { get; set; }
        bool Validate();
    }
}
