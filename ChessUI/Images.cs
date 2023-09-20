using System;
using System.Collections.Generic;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using ChessLogic;

namespace ChessUI;

public static class Images {

    private static readonly Dictionary<PieceType, ImageSource> whiteSources = new() {
        {PieceType.Pawn, LoadImage("Assets/WhitePawn.png")},
        {PieceType.Rook, LoadImage("Assets/WhiteRook.png")},
        {PieceType.Knight, LoadImage("Assets/WhiteKnight.png")},
        {PieceType.Bishop, LoadImage("Assets/WhiteBishop.png")},
        {PieceType.Queen, LoadImage("Assets/WhiteQueen.png")},
        {PieceType.King, LoadImage("Assets/WhiteKing.png")}
    };

    private static readonly Dictionary<PieceType, ImageSource> blackSources = new() {
        {PieceType.Pawn, LoadImage("Assets/BlackPawn.png")},
        {PieceType.Rook, LoadImage("Assets/BlackRook.png")},
        {PieceType.Knight, LoadImage("Assets/BlackKnight.png")},
        {PieceType.Bishop, LoadImage("Assets/BlackBishop.png")},
        {PieceType.Queen, LoadImage("Assets/BlackQueen.png")},
        {PieceType.King, LoadImage("Assets/BlackKing.png")}
    };

    private static ImageSource LoadImage(string filePath) {
        return new BitmapImage(new Uri(filePath, UriKind.Relative));
    }

    public static ImageSource GetImage(Player color, PieceType type) {
        return color switch {
            Player.White => whiteSources[type],
            Player.Black => blackSources[type],
            _ => null
        };
    }

    public static ImageSource GetImage(Piece piece) {
        return (piece==null) ? null : GetImage(piece.Color, piece.Type);
    }
}
