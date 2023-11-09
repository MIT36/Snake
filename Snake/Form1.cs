using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Reflection.Metadata;
using System.Timers;
using System.Windows.Forms;
using System.Xml.Serialization;
using Snake;
using Snake.Models;

namespace WinFormsSnake
{
    public partial class MainForm : Form
    {
        private readonly Game game;
        private readonly int sizeItem;

        public MainForm()
        {
            InitializeComponent();

            var settings = GetSettignsFromXmlFile();

            pbArea.Width = settings.Width;
            Width = pbArea.Width + 205;

            pbArea.Height = settings.Height;
            Height = pbArea.Height + 75;

            sizeItem = settings.SizeItem;

            game = new Game(settings);
            game.Notification += Game_Notification;
        }

        private void Game_Notification(object? sender, EventStatus e)
        {
            switch (e)
            {
                case EventStatus.Success:
                    game.Stop();
                    UpdateLabels();
                    MessageBox.Show("Success!", "Congratulations! You win!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Reset();
                    break;
                case EventStatus.Moved:
                    UpdateLabels();
                    pbArea.Invalidate();
                    break;
                case EventStatus.PreyEaten:
                    PreyEaten();
                    break;
                case EventStatus.GameOver:
                    GameOver();
                    break;
                default: return;
            }
        }

        private void PreyEaten() => UpdateLabels();

        private void GameOver()
        {
            MessageBox.Show("Game over!", "Game over!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            Reset();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            game.SetDirection(keyData switch
            {
                Keys.Right => Direction.Right,
                Keys.Left => Direction.Left,
                Keys.Up => Direction.Up,
                Keys.Down => Direction.Down,
                _ => game.Direction
            });

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void panel_Paint(object sender, PaintEventArgs e)
        {
            var graphic = e.Graphics;
            using var pen = new Pen(Color.Black, 2);
            using var brush = new SolidBrush(Color.Aqua);
            foreach (var item in game.Items)
            {
                var rectangle = new Rectangle(item.X, item.Y, sizeItem, sizeItem);
                graphic.DrawRectangle(pen, rectangle);
                graphic.FillRectangle(brush, rectangle);
            }

            var rectFood = new Rectangle(game.RandomFood.X, game.RandomFood.Y, sizeItem, sizeItem);
            graphic.DrawRectangle(pen, rectFood);
            brush.Color = game.RandomFood.Color;
            graphic.FillRectangle(brush, rectFood);
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyData)
            {
                case Keys.Back:
                    Reset();
                    break;
                case Keys.Escape:
                    game.Stop();
                    Close();
                    break;
                case Keys.Enter:
                    if (!game.IsRunning())
                        game.Start();
                    else
                        game.Stop();
                    break;
            }
        }

        void Reset()
        {
            game.Stop();
            game.Reset();
            pbArea.Invalidate();
            UpdateLabels();
        }

        private Settings GetSettignsFromXmlFile()
        {
            var serializer = new XmlSerializer(typeof(Settings));
            using var fs = new FileStream("settings.xml", FileMode.Open, FileAccess.Read);
            return (Settings)serializer.Deserialize(fs)!;
        }

        private void UpdateLabels()
        {
            if (lblCountLevel.InvokeRequired)
            {
                lblCountLevel.Invoke(PreyEaten);
                return;
            }
            lblCountLevel.Text = $"Level: {game.CurrentLevel.Id}";

            if (lblScore.InvokeRequired)
            {
                lblScore.Invoke(PreyEaten);
                return;
            }
            lblScore.Text = $"Score: {game.TotalScore}";
        }
    }
}