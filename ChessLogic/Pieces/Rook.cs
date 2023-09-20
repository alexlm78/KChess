namespace ChessLogic;

public class Rook : Piece {
    public override PieceType Type => PieceType.Rook;
    public override Player Color { get; }

    private static readonly Direction[] dirs = {
        Direction.North,
        Direction.East,
        Direction.South,
        Direction.West
    };
        
    public Rook(Player color) {
        Color = color;
    }
    
    public override Piece Copy() {
        Rook copy = new(Color) {
            HasMoved = HasMoved
        };
        
        return copy;
    }

    public override IEnumerable<Move> GetMoves(Position fromPos, Board board) {
        return MovePositionsInDirs(fromPos, board, dirs)
            .Select(toPos => new NormalMove(fromPos, toPos));
    }
}
