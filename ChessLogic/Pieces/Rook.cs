namespace ChessLogic;

public class Rook : Piece {
    public override PieceType Type => PieceType.Rook;
    public override Player Color { get; }
        
    public Rook(Player color) {
        Color = color;
    }
    
    public override Piece Copy() {
        Rook copy = new(Color) {
            HasMoved = HasMoved
        };
        
        return copy;
    }
}
