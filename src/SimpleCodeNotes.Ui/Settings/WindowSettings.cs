using ReactiveUI;

namespace SimpleCodeNotes.Ui.Settings;

public class WindowSettings : ReactiveObject
{
    private int _width = 1800;
    private int _height = 450;

    public string Title { get; set; } = "Simple Code Notes";

    public int Width
    {
        get => _width;
        set => this.RaiseAndSetIfChanged(ref _width, value);
    }

    public int Height
    {
        get => _height;
        set => this.RaiseAndSetIfChanged(ref _height, value);
    }

    public int PositionX { get; set; }

    public int PositionY { get; set; }
}
