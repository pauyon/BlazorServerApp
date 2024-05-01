using Humanizer;
using MudBlazor;
using System.Globalization;

namespace BlazorServerApp.Configurations;

public static class UIConstants
{
    private const Variant _buttonVariation = Variant.Filled;
    private const Variant _formFieldVariation = Variant.Outlined;

    public static Dictionary<string, object> AutoComplete(string label)
    {
        Dictionary<string, object> attributes = new()
        {
            { "label", label },
            { "id", $"autocomplete_{GenerateHtmlId(label)}" },
            { "variant", _formFieldVariation },
            { "RequiredError", $"{label} is required." },
            { "OnlyValidateIfDirty", true },
        };

        return attributes;
    }

    public static Dictionary<string, object> DataGrid(string label)
    {
        Dictionary<string, object> attributes = new()
        {
            { "id", $"datagrid_{GenerateHtmlId(label.Pluralize())}" },
            { "SortMode", SortMode.Multiple },
            { "Filterable", true },
            { "FilterMode", DataGridFilterMode.Simple },
            { "FilterCaseSensitivity", DataGridFilterCaseSensitivity.CaseInsensitive },
            { "Dense", true },
            { "Striped", true },
        };

        return attributes;
    }

    public static Dictionary<string, object> DataGridColumn()
    {
        Dictionary<string, object> attributes = new()
        {
            { "Sortable", true },
            { "Filterable", true },
        };

        return attributes;
    }

    public static Dictionary<string, object> ButtonDelete()
    {
        Dictionary<string, object> attributes = new()
        {
            { "id", $"button_delete" },
            { "Variant", _buttonVariation },
            { "Color", Color.Error },
            { "StartIcon", Icons.Material.Filled.Delete },
        };

        return attributes;
    }
    public static Dictionary<string, object> ButtonNew()
    {
        Dictionary<string, object> attributes = new()
        {
            { "id", $"button_new" },
            { "Variant", _buttonVariation },
            { "Color", Color.Success },
            { "StartIcon", Icons.Material.Filled.Add },
        };

        return attributes;
    }

    public static Dictionary<string, object> ButtonEdit()
    {
        Dictionary<string, object> attributes = new()
        {
            { "id", $"button_edit" },
            { "Variant", _buttonVariation },
            { "Color", Color.Primary },
            { "StartIcon", Icons.Material.Filled.Edit },
        };

        return attributes;
    }

    public static Dictionary<string, object> ButtonRefresh()
    {
        Dictionary<string, object> attributes = new()
        {
            { "id", $"button_refresh" },
            { "Variant", _buttonVariation },
            { "Color", Color.Info },
            { "StartIcon", Icons.Material.Filled.Refresh },
        };

        return attributes;
    }

    public static Dictionary<string, object> ButtonSave()
    {
        Dictionary<string, object> attributes = new()
        {
            { "id", $"button_save" },
            { "Variant", _buttonVariation },
            { "Color", Color.Success },
            { "StartIcon", Icons.Material.Filled.Save },
        };

        return attributes;
    }

    public static Dictionary<string, object> ButtonCancel()
    {
        Dictionary<string, object> attributes = new()
        {
            { "id", $"button_cancel" },
            { "Variant", _buttonVariation },
            { "Color", Color.Dark },
            { "StartIcon", Icons.Material.Filled.Cancel },
        };

        return attributes;
    }

    public static Dictionary<string, object> Button(string label, Color buttonColor = Color.Info)
    {
        Dictionary<string, object> attributes = new()
        {
            { "id", $"button_{GenerateHtmlId(label)}" },
            { "Variant", _buttonVariation },
            { "Color", buttonColor },
        };

        return attributes;
    }

    public static Dictionary<string, object> FieldSearch()
    {
        Dictionary<string, object> attributes = new()
        {
            { "id", "field_keywordsearch" },
            { "Placeholder", "Search" },
            { "Adornment", Adornment.Start },
            { "AdornmentIcon", Icons.Material.Filled.Search },
            { "IconSize", Size.Medium },
            { "Immediate", true },
        };

        return attributes;
    }

    public static Dictionary<string, object> Field(string value)
    {
        var label = value.Humanize().Titleize();

        Dictionary<string, object> attributes = new()
        {
            { "id", $"field_{GenerateHtmlId(label)}" },
            { "Label", label},
            { "Immediate", true },
            { "Variant", _formFieldVariation },
            { "OnlyValidateIfDirty", true },
            { "RequiredError", $"{label} is required!" }
        };

        return attributes;
    }

    public static string GenerateHtmlId(string label)
    {
        return label.ToLower().Underscore().ToLower(CultureInfo.CurrentCulture);
    }
}
