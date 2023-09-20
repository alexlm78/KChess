namespace ChessLogic;

public class Pawn : Piece {
    public override PieceType Type => PieceType.Pawn;
    public override Player Color { get; }

    private readonly Direction forward;
        
    public Pawn(Player color) {
        Color = color;

        if( color == Player.White)
            forward = Direction.North;
        else if (color == Player.Black)
            forward = Direction.South;
    }
    
    public override Piece Copy() {
        Pawn copy = new(Color) {
            HasMoved = HasMoved
        };
        
        return copy;
    }

    private static bool CanMoveTo(Position pos, Board board) {
        return Board.IsInside(pos) && board.IsEmpty(pos);
    }

    private bool CanCaptureAt(Position pos, Board board) {
        if ( Board.IsInside(pos) || board.IsEmpty(pos) )
            return false;

        return board[pos].Color != Color;
    }

    private IEnumerable<Move> ForwardMoves(Position pos, Board board) {
        Position forwardPos = pos + forward;

        if ( CanMoveTo(forwardPos, board)) {
            yield return new NormalMove(pos, forwardPos);

            Position doubleForwardPos = forwardPos + forward;

            if ( !HasMoved && CanMoveTo(doubleForwardPos, board) )
                yield return new NormalMove(pos, doubleForwardPos);
        }
    }

    private IEnumerable<Move> DiagonalMoves(Position pos, Board board) {
        foreach (Direction dir in new Direction[] { Direction.West, Direction.East }) {
            Position diagonalPos = pos + forward + dir;

            if (CanCaptureAt(diagonalPos, board))
                yield return new NormalMove(pos, diagonalPos);
        }
    }

    public override IEnumerable<Move> GetMoves(Position pos, Board board) {
        return ForwardMoves(pos, board).Concat(DiagonalMoves(pos, board));
    }
}
