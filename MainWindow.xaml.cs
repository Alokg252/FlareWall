using FlareWall.Models;
using FlareWall.Services;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FlareWall;

public partial class MainWindow : Window
{
    private Challenge? _challenge;

    public MainWindow()
    {
        InitializeComponent();

        GenerateChallenge();
    }

    private void GenerateChallenge()
    {
        _challenge = ChallengeFactory.Generate();

        FunctionText.Text =
            $"Function: {_challenge.FunctionName}";

        ParameterText.Text =
            $"a = {_challenge.A}    b = {_challenge.B}";
    }

    private void Unlock_Click(
        object sender,
        RoutedEventArgs e)
    {
        if (_challenge == null)
            return;

        if (int.TryParse(
            AnswerBox.Text,
            out int answer))
        {
            if (answer ==
                _challenge.ExpectedAnswer)
            {
                MessageBox.Show(
                    "Unlocked");

                Application.Current.Shutdown();
            }
            else
            {
                MessageBox.Show(
                    "Wrong answer");

                GenerateChallenge();
            }
        }
    }

    protected override void OnClosing(
    System.ComponentModel.CancelEventArgs e)
    {
        e.Cancel = true;
    }
}