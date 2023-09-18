namespace ChessLogic;

public class Position {
    public int Row { get; }
    public int Column { get; }

    public Position(int row, int column) {
        Row = row;
        Column = column;
    }

    public Player SquareColor() {
        return (Row + Column) % 2 == 0 ? Player.White : Player.Black;
    }

    public override bool Equals(object obj) {
        return obj is Position position &&
               Row == position.Row &&
               Column == position.Column;
    }

    public override int GetHashCode() {
        return HashCode.Combine(Row, Column);
    }

    public static bool operator ==(Position left, Position right) {
        return EqualityComparer<Position>.Default.Equals(left, right);
    }

    public static bool operator !=(Position left, Position right) {
        return !(left == right);
    }

    public static Position operator +(Position left, Direction right) {
        return new Position(left.Row + right.RowDelta, left.Column + right.ColumnDelta);
    }
}
