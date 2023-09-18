namespace ChessLogic;

public class Pawn : Piece {
    public override PieceType Type => PieceType.Pawn;
    public override Player Color { get; }
        
    public Pawn(Player color) {
        Color = color;
    }
    
    public override Piece Copy() {
        Pawn copy = new(Color) {
            HasMoved = HasMoved
        };
        
        return copy;
    }
}

