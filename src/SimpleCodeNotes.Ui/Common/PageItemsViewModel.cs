using Avalonia.Collections;
using ReactiveUI;

namespace SimpleCodeNotes.Ui.Common;

public class PageItemsViewModel<TItem> : BaseViewModel
{
    private TItem? _selectedItem;

    public AvaloniaList<TItem> Collection { get; } = new();

    public TItem? SelectedItem
    {
        get => _selectedItem;
        set => this.RaiseAndSetIfChanged(ref _selectedItem, value);
    }

    public void Clear()
    {
        Collection.Clear();
        SelectedItem = default;
    }

    public void RemoveItem(TItem? item)
    {
        if (item == null)
        {
            return;
        }

        Collection.Remove(item);
    }
}
