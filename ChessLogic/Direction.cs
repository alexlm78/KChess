namespace ChessLogic;

public class Direction {
    public readonly static Direction North = new(-1, 0);
    public readonly static Direction South = new(1, 0);
    public readonly static Direction East = new(0, 1);
    public readonly static Direction West = new(0, -1);

    public readonly static Direction NorthEast = North + East;
    public readonly static Direction NorthWest = North + West;
    public readonly static Direction SouthEast = South + East;
    public readonly static Direction SouthWest = South + West;

    public int RowDelta { get; }
    public int ColumnDelta { get; }

    public Direction(int rowDelta, int columnDelta) {
        RowDelta = rowDelta;
        ColumnDelta = columnDelta;
    }

    public static Direction operator +(Direction dirA, Direction dirB) {
        return new Direction(dirA.RowDelta + dirB.RowDelta, dirA.ColumnDelta + dirB.ColumnDelta);
    }

    public static Direction operator *(Direction dir, int multiplier) {
        return new Direction(dir.RowDelta * multiplier, dir.ColumnDelta * multiplier);
    }


}
