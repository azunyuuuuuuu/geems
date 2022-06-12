using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace geems.Pages;

public partial class TwoZeroFourEight
{
    private int?[,] playfield = new int?[4, 4];

    private void KeyDownEventHandler(KeyboardEventArgs e)
        => Console.WriteLine($"{nameof(KeyDownEventHandler)}: {GetLogString(e)}");

    private void KeyUpEventHandler(KeyboardEventArgs e)
        => Console.WriteLine($"{nameof(KeyUpEventHandler)}: {GetLogString(e)}");
        
    private void KeyPressEventHandler(KeyboardEventArgs e)
        => Console.WriteLine($"{nameof(KeyPressEventHandler)}: {GetLogString(e)}");

    private static string GetLogString(KeyboardEventArgs e)
        => $"Key: {e.Key}, Code: {e.Code}, Location: {e.Location}, Repeat: {e.Repeat}, CtrlKey: {e.CtrlKey}, ShiftKey: {e.ShiftKey}, AltKey: {e.AltKey}, MetaKey: {e.MetaKey}, Type: {e.Type}";
}