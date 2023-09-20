namespace ChessLogic;

public class Knight : Piece {
    public override PieceType Type => PieceType.Knight;
    public override Player Color { get; }
            
    public Knight(Player color) {
        Color = color;
    }
    
    public override Piece Copy() {
        Knight copy = new(Color) {
            HasMoved = HasMoved
        };
        
        return copy;
    }

    private static IEnumerable<Position> PotentialToPositions(Position pos) {
        foreach(Direction vDir in new Direction[] { Direction.North, Direction.South }) {
            foreach(Direction hDir in new Direction[] { Direction.West, Direction.East }) {
                yield return pos + (vDir + vDir) + hDir;
                yield return pos + (hDir + hDir) + vDir;
            }
        }
    }

    private IEnumerable<Position> MovePositions(Position pos, Board board) {
        return PotentialToPositions(pos).Where(p => Board.IsInside(p) && (board.IsEmpty(p) || board[p].Color != Color));
    }

    public override IEnumerable<Move> GetMoves(Position fromPos, Board board) {
        return MovePositions(fromPos, board).Select(toPos => new NormalMove(fromPos, toPos));
    }
}
