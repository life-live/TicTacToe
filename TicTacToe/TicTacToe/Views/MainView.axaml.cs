using System.Collections.Generic;
using System.Linq;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Media;

namespace TicTacToe.Views;

public partial class MainView : UserControl
{
    private const string Cross = "X";
    private const string Zero = "O";
    private bool _playerChange = true;

    public MainView()
    {
        InitializeComponent();
    }

    private object? CheckWin()
    {
        if (FirstFirst.Content is not null && FirstFirst.Content == FirstSecond.Content &&
            FirstSecond.Content == FirstThird.Content)
        {
            /*
                * * *
                - - -
                - - -
            */
            WiningLine.StartPoint = new Point(0, 50);
            WiningLine.EndPoint = new Point(220, 50);
            WiningLine.Margin = new Thickness(0, -125, 0, 0);
            return FirstFirst.Content;
        }

        if (SecondFirst.Content is not null && SecondFirst.Content == SecondSecond.Content &&
            SecondSecond.Content == SecondThird.Content)
        {
            /*
                - - -
                * * *
                - - -
            */
            WiningLine.StartPoint = new Point(0, 50);
            WiningLine.EndPoint = new Point(220, 50);
            WiningLine.Margin = new Thickness(0, -50, 0, 0);
            return SecondFirst.Content;
        }

        if (ThirdFirst.Content is not null && ThirdFirst.Content == ThirdSecond.Content &&
            ThirdSecond.Content == ThirdThird.Content)
        {
            /*
                - - -
                - - -
                * * *
            */
            WiningLine.StartPoint = new Point(0, 50);
            WiningLine.EndPoint = new Point(220, 50);
            WiningLine.Margin = new Thickness(0, 100, 0, 0);
            return ThirdFirst.Content;
        }

        if (FirstFirst.Content is not null && FirstFirst.Content == SecondFirst.Content &&
            SecondFirst.Content == ThirdFirst.Content)
        {
            /*
                * - -
                * - -
                * - -
            */
            WiningLine.StartPoint = new Point(50, 220);
            WiningLine.EndPoint = new Point(50, 0);
            WiningLine.Margin = new Thickness(-125, 0, 0, 0);
            return FirstFirst.Content;
        }

        if (FirstSecond.Content is not null && FirstSecond.Content == SecondSecond.Content &&
            SecondSecond.Content == ThirdSecond.Content)
        {
            /*
                - * -
                - * -
                - * -
            */
            WiningLine.StartPoint = new Point(50, 220);
            WiningLine.EndPoint = new Point(50, 0);
            WiningLine.Margin = new Thickness(-50, 0, 0, 0);
            return FirstSecond.Content;
        }

        if (FirstThird.Content is not null && FirstThird.Content == SecondThird.Content &&
            SecondThird.Content == ThirdThird.Content)
        {
            /*
                - - *
                - - *
                - - *
            */
            WiningLine.StartPoint = new Point(50, 220);
            WiningLine.EndPoint = new Point(50, 0);
            WiningLine.Margin = new Thickness(100, 0, 0, 0);
            return FirstThird.Content;
        }

        if (FirstFirst.Content is not null && FirstFirst.Content == SecondSecond.Content &&
            SecondSecond.Content == ThirdThird.Content)
        {
            /*
                * - -
                - * -
                - - *
            */
            WiningLine.StartPoint = new Point(50, 0);
            WiningLine.EndPoint = new Point(260, 210);
            WiningLine.Margin = new Thickness(-50, 0, 0, 0);
            return FirstFirst.Content;
        }

        if (FirstThird.Content is not null && FirstThird.Content == SecondSecond.Content &&
            SecondSecond.Content == ThirdFirst.Content)
        {
            /*
                - - *
                - * -
                * - -
            */
            WiningLine.StartPoint = new Point(260, 0);
            WiningLine.EndPoint = new Point(50, 210);
            WiningLine.Margin = new Thickness(-50, 0, 0, 0);
            return FirstThird.Content;
        }

        return null;
    }

    private void FinishGame_OnClick(object? sender, RoutedEventArgs e)
    {
        ContentControl[] cells =
        {
            FirstFirst, FirstSecond, FirstThird,
            SecondFirst, SecondSecond, SecondThird,
            ThirdFirst, ThirdSecond, ThirdThird
        };
        ReturnInitialState(cells);
        FinishGame.Content = "Finish Game";
    }

    private void ReturnInitialState(IEnumerable<ContentControl> buttons)
    {
        _playerChange = true;
        WiningLine.IsVisible = false;
        AnnouncementWin.Text = null;
        foreach (var button in buttons)
        {
            button.Content = null;
            button.Foreground = Brushes.WhiteSmoke;
            button.IsEnabled = true;
        }
    }

    private void SelectingValue(RoutedEventArgs e, ContentControl? button)
    {
        if (button is null) return;
        ContentControl[] cells =
        {
            FirstFirst, FirstSecond, FirstThird,
            SecondFirst, SecondSecond, SecondThird,
            ThirdFirst, ThirdSecond, ThirdThird
        };
        button.Content = _playerChange ? Zero : Cross;
        button.IsEnabled = false;
        _playerChange = !_playerChange;
        if (CheckWin() is not null)
        {
            WiningLine.IsVisible = true;
            AnnouncementWin.Text = $"{button.Content} win!";
            FinishGame.Content = "Start new game";
            foreach (var cell in cells) cell.IsEnabled = false;
            return;
        }

        if (cells.Any(cell => cell.Content is null)) return;
        AnnouncementWin.Text = "Draw";
        FinishGame.Content = "Start new game";
    }

    private void FirstFirst_OnClick(object? sender, RoutedEventArgs e)
    {
        SelectingValue(e, sender as Button);
    }

    private void FirstSecond_OnClick(object? sender, RoutedEventArgs e)
    {
        SelectingValue(e, sender as Button);
    }

    private void FirstThird_OnClick(object? sender, RoutedEventArgs e)
    {
        SelectingValue(e, sender as Button);
    }

    private void SecondFirst_OnClick(object? sender, RoutedEventArgs e)
    {
        SelectingValue(e, sender as Button);
    }

    private void SecondSecond_OnClick(object? sender, RoutedEventArgs e)
    {
        SelectingValue(e, sender as Button);
    }

    private void SecondThird_OnClick(object? sender, RoutedEventArgs e)
    {
        SelectingValue(e, sender as Button);
    }

    private void ThirdFirst_OnClick(object? sender, RoutedEventArgs e)
    {
        SelectingValue(e, sender as Button);
    }

    private void ThirdSecond_OnClick(object? sender, RoutedEventArgs e)
    {
        SelectingValue(e, sender as Button);
    }

    private void ThirdThird_OnClick(object? sender, RoutedEventArgs e)
    {
        SelectingValue(e, sender as Button);
    }
}