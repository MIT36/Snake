using System.Drawing;
using System.Timers;
using System.Windows.Forms;

namespace Snake
{
    public partial class MainForm : Form
    {
        private readonly System.Timers.Timer timer;

        private int headX = 10, tailX = 10, headY = 50, tailY = 50;
        private int size = 20;

        private int direct = 0;

        //private Graphics graphic;

        public MainForm()
        {
            InitializeComponent();
            //graphic = panel.CreateGraphics();
            timer = new System.Timers.Timer(500);
            timer.Elapsed += Timer_Elapsed;
            timer.Start();
        }

        private void Timer_Elapsed(object? sender, ElapsedEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine(DateTimeOffset.Now);
            using var graphic = panel.CreateGraphics();
            using var pen = new Pen(Color.Black, 2);
            using var brush = new SolidBrush(Color.Aqua);

            RenderTail(graphic, pen, brush);

            RenderHead(graphic, pen, brush);

            if (headX + size >= panel.Width)
            {
                timer.Stop();
                MessageBox.Show("Game over!", "Game over!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void RenderHead(Graphics graphics, Pen pen, SolidBrush brush)
        {
            pen.Color = Color.Black;
            brush.Color = Color.Aqua;
            var headSquare = new Rectangle(headX, headY, size, size);
            graphics.DrawRectangle(pen, headSquare);
            graphics.FillRectangle(brush, headSquare);
        }

        void RenderTail(Graphics graphics, Pen pen, SolidBrush brush)
        {
            var tailSquare = new Rectangle(tailX, tailY, size, size);
            pen.Color = panel.BackColor;
            brush.Color = panel.BackColor;
            graphics.DrawRectangle(pen, tailSquare);
            graphics.FillRectangle(brush, tailSquare);
            tailX += size;
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            direct = e.KeyCode switch
            {
                Keys.Down => 1,
                Keys.Up => 2,
                Keys.Left => 3,
                _ => direct
            };
        }

        private void panel_Paint(object sender, PaintEventArgs e)
        {
            using var graphic = panel.CreateGraphics();
            using var pen = new Pen(Color.Black, 2);
            using var brush = new SolidBrush(Color.Aqua);
            for (int i = 0; i < 5; i++)
            {
                headX += size;
                var square = new Rectangle(headX, headY, size, size);
                graphic.DrawRectangle(pen, square);
                graphic.FillRectangle(brush, square);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Render()
        {
            
        }
    }
}