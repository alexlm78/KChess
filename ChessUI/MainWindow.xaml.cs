using System;
using System.Collections.Generic;
using System.Windows;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ChessLogic;

namespace ChessUI;

public partial class MainWindow : Window {

    private readonly Image[,] pieceImages = new Image[8, 8];
    private readonly Rectangle[,] highlights = new Rectangle[8, 8];
    private readonly Dictionary<Position, Move> moveCache = new Dictionary<Position, Move>();

    private GameState gamesState;
    private Position selectedPosition = null;

    public MainWindow() {
        InitializeComponent();
        InitializeBoard();

        gamesState = new GameState(Player.White, Board.Initial());
        DrawBoard(gamesState.Board);
        SetCursor(gamesState.CurrentPlayer);
    }

    private void InitializeBoard() {
        for(int r =0; r < 8; r++) {
            for(int c =0; c < 8; c++) {
                Image image = new Image();
                pieceImages[r, c] = image;
                PieceGrid.Children.Add(image);

                Rectangle highlight = new Rectangle();
                highlights[r, c] = highlight;
                HighlightGrid.Children.Add(highlight);
            }
        }
    }

    private void DrawBoard(Board board) {
        for(int r =0; r < 8; r++) 
            for(int c =0; c < 8; c++) 
                pieceImages[r, c].Source = Images.GetImage(board[r, c]);
    }

    private void BoardGrid_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e) {
        Point point = e.GetPosition(BoardGrid);
        Position position = ToSquarePosition(point);
        
        if(selectedPosition == null) 
            OnFromPositionSelected(position);
        else
            OnToPositionSelected(position);
    }

    private Position ToSquarePosition(Point point) {
        double squareSize = BoardGrid.ActualWidth / 8;
        int row = (int)(point.Y / squareSize);
        int col = (int)(point.X / squareSize);

        return new Position(row, col);
    }

    private void OnFromPositionSelected(Position position) {
        IEnumerable<Move> moves = gamesState.LegalMovesForPiece(position);
        if(moves.Any()) {
            selectedPosition = position;
            CacheMoves(moves);
            ShowHighlights();
        }
    }

    private void OnToPositionSelected(Position position) {
        selectedPosition = null;
        HideHighlights();

        if (moveCache.TryGetValue(position, out Move move)) 
            HandleMove(move);
    }

    private void HandleMove(Move move) {
        gamesState.MakeMove(move);
        DrawBoard(gamesState.Board);
        SetCursor(gamesState.CurrentPlayer);
    }

    private void CacheMoves(IEnumerable<Move> moves) {
        moveCache.Clear();
        foreach(Move move in moves) 
            moveCache[move.To] = move;
    }

    private void ShowHighlights() {
        Color color = Color.FromArgb(150, 125, 255, 125);
        foreach(Position position in moveCache.Keys) 
            highlights[position.Row, position.Column].Fill = new SolidColorBrush(color);
    }

    private void HideHighlights() {
        foreach(Position pos in moveCache.Keys) 
            highlights[pos.Row, pos.Column].Fill = Brushes.Transparent;
    }

    private void SetCursor(Player player) {
        Cursor = (player == Player.White ? ChessCursors.WhiteCursor : ChessCursors.BlackCursor);
    }
}
