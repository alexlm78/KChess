namespace ChessLogic;

public class Queen : Piece {
    public override PieceType Type => PieceType.Queen;
    public override Player Color { get; }

    public static readonly Direction[] dirs = {
        Direction.North,
        Direction.East,
        Direction.South,
        Direction.West,
        Direction.NorthWest,
        Direction.NorthEast,
        Direction.SouthEast,
        Direction.SouthWest
    };
        
    public Queen(Player color) {
        Color = color;
    }
    
    public override Piece Copy() {
        Queen copy = new(Color) {
            HasMoved = HasMoved
        };
        
        return copy;
    }

    public override IEnumerable<Move> GetMoves(Position fromPos, Board board) {
        return MovePositionsInDirs(fromPos, board, dirs)
            .Select(toPos => new NormalMove(fromPos, toPos));
    }
}
