namespace ChessLogic;

public class King : Piece {
    public override PieceType Type => PieceType.King;
    public override Player Color { get; }

    private static readonly Direction[] dirs = new Direction[] {
        Direction.North, 
        Direction.South, 
        Direction.West, 
        Direction.East,
        Direction.NorthWest, 
        Direction.NorthEast, 
        Direction.SouthWest, 
        Direction.SouthEast
    };
        
    public King(Player color) {
        Color = color;
    }
    
    public override Piece Copy() {
        King copy = new(Color) {
            HasMoved = HasMoved
        };
        
        return copy;
    }

    private IEnumerable<Position> MovePositions(Position pos, Board board) {
        foreach(Direction dir in dirs) {
            Position newPos = pos + dir;

            if(!Board.IsInside(newPos))
                continue;

            if ( (board.IsEmpty(newPos) || board[newPos].Color != Color) )
                yield return newPos;
        }
    }

    public override IEnumerable<Move> GetMoves(Position fromPos, Board board) {
        foreach(Position to in MovePositions(fromPos, board)) {
            yield return new NormalMove(fromPos, to);
        }
    }

    public override bool CanCaptureOpponentKing(Position fromPos, Board board) {
        return MovePositions(fromPos, board).Any(to => {
            Piece piece = board[to];
            return piece != null && piece.Type == PieceType.King;
        });
    }
}
