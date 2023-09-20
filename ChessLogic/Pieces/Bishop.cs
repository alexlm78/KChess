namespace ChessLogic;

public class Bishop : Piece {
    public override PieceType Type => PieceType.Bishop;
    public override Player Color { get; }

    public static readonly Direction[] dirs = {
        Direction.NorthWest,
        Direction.NorthEast,
        Direction.SouthEast,
        Direction.SouthWest
    };
        
    public Bishop(Player color) {
        Color = color;
    }
    
    public override Piece Copy() {
        Bishop copy = new(Color) {
            HasMoved = HasMoved
        };
        
        return copy;
    }

    public override IEnumerable<Move> GetMoves(Position fromPos, Board board) {
        return MovePositionsInDirs(fromPos, board, dirs)
            .Select(toPos => new NormalMove(fromPos, toPos));
    }
}
