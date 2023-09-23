using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;

namespace ChessUI;

public static class ChessCursors {
    public static readonly Cursor WhiteCursor = LoadCursor("Assets/WhiteCursor.cur");
    public static readonly Cursor BlackCursor = LoadCursor("Assets/BlackCursor.cur");

    private static Cursor LoadCursor(string filePath) {
        Stream stream = Application.GetResourceStream(new Uri(filePath, UriKind.Relative)).Stream;
        return new Cursor(stream, true);
    }
}
