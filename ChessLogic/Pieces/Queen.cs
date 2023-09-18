namespace ChessLogic;

public class Queen : Piece {
    public override PieceType Type => PieceType.Queen;
    public override Player Color { get; }
        
    public Queen(Player color) {
        Color = color;
    }
    
    public override Piece Copy() {
        Queen copy = new(Color) {
            HasMoved = HasMoved
        };
        
        return copy;
    }
}
