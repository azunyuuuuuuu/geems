using Microsoft.AspNetCore.Components;

namespace minswep.Pages;

public partial class Game
{
    [Parameter, SupplyParameterFromQuery(Name = "width")]
    public int Width { get; set; }

    [Parameter, SupplyParameterFromQuery(Name = "height")]
    public int Height { get; set; }

    [Parameter, SupplyParameterFromQuery(Name = "mines")]
    public int Mines { get; set; }

    private bool[,]? playfield;

    private readonly Dictionary<string, string> gamemodes = new Dictionary<string, string>();

    private int minecount => playfield?.Cast<bool>().Where(x => x == true).Count() ?? 0;

    protected override void OnInitialized()
    {
        var modeeasy = new Dictionary<string, object?>() { { "width", 9 }, { "height", 9 }, { "mines", 10 } };
        var modemedium = new Dictionary<string, object?>() { { "width", 16 }, { "height", 16 }, { "mines", 40 } };
        var modeexpert = new Dictionary<string, object?>() { { "width", 30 }, { "height", 16 }, { "mines", 99 } };
        gamemodes.Add("Easy", _nav.GetUriWithQueryParameters(modeeasy));
        gamemodes.Add("Medium", _nav.GetUriWithQueryParameters(modemedium));
        gamemodes.Add("Expert", _nav.GetUriWithQueryParameters(modeexpert));
    }

    protected override void OnParametersSet()
    {
        Width = Width <= 0 ? 9 : Width;
        Height = Height <= 0 ? 9 : Height;
        Mines = Mines <= 0 ? 9 : Mines;

        playfield = new bool[Width, Height];
    }

    private void ToggleMine(int x, int y)
    {
        Console.WriteLine($"{x}, {y}, {playfield.ToString()}, {playfield.Length}");

        if ((x >= 0 && x < Width) == false) return;
        if ((y >= 0 && y < Height) == false) return;

        playfield[x, y] = !playfield[x, y];
        Console.WriteLine($"eyy {minecount.ToString()}");
    }

    private int? GetNeighbouringMineCount(int x, int y)
    {
        var count = 0;
        for (var fx = x - 1; fx <= x + 1; fx++)

            for (var fy = y - 1; fy <= y + 1; fy++)

                if ((fx >= 0 && fx < Width) && (fy >= 0 && fy < Height))

                    if (playfield[fx, fy])

                        count += 1;

        return count > 0 ? count : null;
    }
}