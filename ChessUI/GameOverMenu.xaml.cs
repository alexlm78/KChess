using ChessLogic;
using System;
using System.Windows;
using System.Windows.Controls;

namespace ChessUI;
/// <summary>
/// Interaction logic for GameOverMenu.xaml
/// </summary>
public partial class GameOverMenu : UserControl {
    public event Action<Option> OptionSelected;

    public GameOverMenu(GameState gameState) {
        InitializeComponent();

        Result result = gameState.Result;
        WinnerText.Text = GetWinnerText(result.Winner);
        ReasonText.Text = GetReasonText(result.Reason, gameState.CurrentPlayer);
    }

    private static string GetWinnerText(Player winner) {
        // Get the winner text
        return winner switch {
            Player.White => "White Wins!",
            Player.Black => "Black Wins!",
            _ => "It's a Draw!"
        };
    }

    private static string PlayerString(Player player) {
        // Get the player string
        return player switch {
            Player.White => "White",
            Player.Black => "Black",
            _ => ""
        };
    }

    private static string GetReasonText(EndReason reason, Player currentPlayer) {
        // Get the reason text
        return reason switch {
            EndReason.Checkmate => $"{PlayerString(currentPlayer)} Checkmated",
            EndReason.Stalemate => $"{PlayerString(currentPlayer)} Stalemated",
            EndReason.FiftyMoveRule => "FiftyMove Rule",
            EndReason.ThreefoldRepetition => "Threefold Repetition",
            EndReason.InsufficientMaterial => "Insufficient Material",
            _ => ""
        };
    }

    private void Restart_Click(object sender, RoutedEventArgs e) {
        // Restart Method
        OptionSelected?.Invoke(Option.Restart);
    }

    private void Exit_Click(object sender, RoutedEventArgs e) {
        // Exit method
        OptionSelected?.Invoke(Option.Exit);
    }
}
