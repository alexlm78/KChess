using System.Windows;
using System.Windows.Controls;
using ChessLogic;

namespace ChessUI;

public partial class MainWindow : Window {

    private readonly Image[,] pieceImages = new Image[8, 8];

    private GameState gamesState;

    public MainWindow() {
        InitializeComponent();
        InitializeBoard();

        gamesState = new GameState(Player.White, Board.Initial());
        DrawBoard(gamesState.Board);
    }

    private void InitializeBoard() {
        for(int r =0; r < 8; r++) {
            for(int c =0; c < 8; c++) {
                Image image = new Image();
                pieceImages[r, c] = image;
                PieceGrid.Children.Add(image);
            }
        }
    }

    private void DrawBoard(Board board) {
        for(int r =0; r < 8; r++) 
            for(int c =0; c < 8; c++) 
                pieceImages[r, c].Source = Images.GetImage(board[r, c]);
    }
}
