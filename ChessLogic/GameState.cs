namespace ChessLogic;

public class GameState {
    public Board Board { get; }
    public Player CurrentPlayer { get; private set; }
    public Result Result { get; private set; } = null;

    /*public bool IsCheck { get; }
    public bool IsCheckmate { get; }
    public bool IsStalemate { get; }
    public bool IsDraw { get; }*/

    public GameState(Player player, Board board) {
        Board = board;
        CurrentPlayer = player;     
    }

    public IEnumerable<Move> LegalMovesForPiece(Position pos) {
        if(Board.IsEmpty(pos) || Board[pos].Color != CurrentPlayer ) 
            return Enumerable.Empty<Move>();

        Piece piece = Board[pos];
        IEnumerable<Move> moveCandidates = piece.GetMoves(pos, Board);
        return moveCandidates.Where(move => move.IsLegal(Board));
    }

    public void MakeMove(Move move) {
        move.Execute(Board);
        CurrentPlayer = CurrentPlayer.Opponent();
        CheckForGameOver();
    }

    public IEnumerable<Move> AllLegalMovesFor(Player player) {
        IEnumerable<Move> moveCandidates = Board.PiecePositionsFor(player).SelectMany(pos => {
            Piece piece = Board[pos];
            return piece.GetMoves(pos, Board);
        });
        return moveCandidates.Where(move => move.IsLegal(Board));
    }

    private void CheckForGameOver() {
        if(!AllLegalMovesFor(CurrentPlayer).Any()) {
            if(Board.IsInCheck(CurrentPlayer)) 
                Result = Result.Win(CurrentPlayer.Opponent());
            else 
                Result = Result.Draw(EndReason.Stalemate);
        }
    }

    public bool IsGameOver() {
        return Result != null;
    }

    /*public GameState(Board board, Player player, bool isCheck, bool isCheckmate, bool isStalemate, bool isDraw) {
        Board = board;
        Player = player;
        IsCheck = isCheck;
        IsCheckmate = isCheckmate;
        IsStalemate = isStalemate;
        IsDraw = isDraw;
    }*/

    /*public static GameState Initial() {
        return new GameState(Board.Initial(), Player.White, false, false, false, false);
    }*/

    /*public GameState Move(Position from, Position to) {
        if (Board.IsEmpty(from)) {
            throw new ArgumentException("No piece at " + from);
        }

        if (Board[from].Player != Player) {
            throw new ArgumentException("Not your piece at " + from);
        }

        if (!Board[from].CanMove(from, to, Board)) {
            throw new ArgumentException("Piece at " + from + " cannot move to " + to);
        }

        Board newBoard = Board.Move(from, to);
        Player newPlayer = Player.Other();
        bool newIsCheck = newBoard.IsCheck(newPlayer);
        bool newIsCheckmate = newIsCheck && newBoard.IsCheckmate(newPlayer);
        bool newIsStalemate = !newIsCheck && newBoard.IsStalemate(newPlayer);
        bool newIsDraw = newBoard.IsDraw(newPlayer);

        return new GameState(newBoard, newPlayer, newIsCheck, newIsCheckmate, newIsStalemate, newIsDraw);
    }*/
}
