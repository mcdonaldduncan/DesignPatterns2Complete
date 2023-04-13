using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static DesignPatterns2.Constant;
using ValidationResult = System.ComponentModel.DataAnnotations.ValidationResult;

namespace DesignPatterns2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Game<Player, Competitor> _Game;

        public MainWindow()
        {
            InitializeComponent();
            SetState(GameState.NEWGAME);

            SetupDropDowns();
        }

        private void SetupDropDowns()
        {
            dd_UniformSelector.ItemsSource = UniformColors;
            dd_GemSelector.ItemsSource = GemBank;
            dd_Item1Selector.ItemsSource = ItemBank;
            dd_Item2Selector.ItemsSource = ItemBank;
        }

        private void SetState(GameState state)
        {
            switch (state)
            {
                case GameState.NEWGAME:
                    grd_NewGame.Visibility = Visibility.Visible;
                    grd_Game.Visibility = Visibility.Hidden;
                    grd_GameOver.Visibility = Visibility.Hidden;

                    btn_NextTurn.Visibility = Visibility.Visible;
                    btn_SeeResult.Visibility = Visibility.Hidden;

                    break;
                case GameState.PLAYING:
                    grd_NewGame.Visibility = Visibility.Hidden;
                    grd_Game.Visibility = Visibility.Visible;
                    grd_GameOver.Visibility = Visibility.Hidden;
                    tb_Inventory.Text = _Game.DisplayPlayerInventory();

                    break;
                case GameState.GAMEOVER:
                    grd_NewGame.Visibility = Visibility.Hidden;
                    grd_Game.Visibility = Visibility.Hidden;
                    grd_GameOver.Visibility = Visibility.Visible;

                    break;
                default:
                    break;
            }
        }

        private bool ValidatePlayer(out Player player, out List<ValidationResult> errors)
        {
            player = new Player()
            {
                Name = tb_NameInput.Text,
                UniformColor = UniformColors[dd_UniformSelector.SelectedIndex],
                GemStone = GemBank[dd_GemSelector.SelectedIndex],
            };

            player.Inventory.Add(ItemBank[dd_Item1Selector.SelectedIndex]);
            player.Inventory.Add(ItemBank[dd_Item2Selector.SelectedIndex]);

            var context = new ValidationContext(player);
            errors = new List<ValidationResult>();

            return Validator.TryValidateObject(player, context, errors, true);
        }

        private string ErrorsToString(List<ValidationResult> errors)
        {
            string output = "";

            foreach (var error in errors)
            {
                foreach (var memName in error.MemberNames)
                {
                    output += $"ERROR: {error.ErrorMessage}\n";
                }
            }

            return output;
        }

        private void btn_Start_Click(object sender, RoutedEventArgs e)
        {
            if (ValidatePlayer(out Player player, out List<ValidationResult> errors))
            {
                _Game = new Game<Player, Competitor>(player, new Competitor());
                SetState(GameState.PLAYING);
            }
            else
            {

                tb_ErrorOutput.Foreground = Brushes.Red;
                tb_ErrorOutput.Text = ErrorsToString(errors);
            }
        }

        private void btn_NextTurn_Click(object sender, RoutedEventArgs e)
        {
            if (!_Game.ExecuteTurn(out string playerOutput, out string competitorOutput))
            {
                btn_NextTurn.Visibility = Visibility.Hidden;
                btn_SeeResult.Visibility = Visibility.Visible;
            }

            tb_PlayerOutput.Foreground = _Game.Player.UniformColor.Brush;
            tb_CompetitorOutput.Foreground = _Game.Competitor.UniformColor.Brush;

            tb_PlayerOutput.Text = playerOutput;
            tb_CompetitorOutput.Text = competitorOutput;
            
        }

        private void btn_UseItem_Click(object sender, RoutedEventArgs e)
        {
            _Game.UseFirstitem();
            tb_Inventory.Text = _Game.DisplayPlayerInventory();
        }

        private void btn_SeeResult_Click(object sender, RoutedEventArgs e)
        {
            SetState(GameState.GAMEOVER);
            tb_ResultOutput.Text = $"You lasted {_Game.Turn} turns and {_Game.GetWinner()} the contest!";
        }
    }

    enum GameState
    {
        NEWGAME,
        PLAYING,
        GAMEOVER
    }
}


