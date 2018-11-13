using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DiscsMFAK
{
    public partial class MainForm : Form
    {
        private double elapsedTime = 0;
        public List<Disc> Discs { get; set; } = new List<Disc>();
        private Color[] _colors;
        private ForceField centerForceField;

        public MainForm()
        {
            InitializeComponent();
            DoubleBuffered = true;
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            elapsedTime += timer.Interval;
            Refresh();
        }

        private void InitializeTimer()
        {
            timer.Interval = 10;
            timer.Start();
        }

        private void MainForm_Paint(object sender, PaintEventArgs e)
        {
            string elapsedTimeText = $"time: {elapsedTime / 1000} [s]";
            TextRenderer.DrawText(e.Graphics, elapsedTimeText, this.Font,
                new Rectangle(0, 0, 100, 25), Color.Blue);
            

            DrawDiscs(Discs, e);
            UpdateDiscs(Discs, e);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            InitializeTimer();

            _colors = new Color[]
            {
                Color.Blue,
                Color.Brown,
                Color.Crimson,
                Color.DarkGoldenrod,
                Color.ForestGreen
            };

            int size = _colors.Length;

            Random rand = new Random();

            Disc disc1 = new Disc(200, 50, -0.5f, 0.3f,
                4, 0.1f, _colors[rand.Next(0, size)]);
            
            Discs.Add(disc1);

            Disc disc2 = new Disc(350, 80, 1.2f, 2,
                10, 0.2f, _colors[rand.Next(0, size)]);

            Discs.Add(disc2);


            centerForceField = new ForceField(300, 200, 30, 0.001f);
        }

        private void DrawDiscs(IList<Disc> discs, PaintEventArgs e)
        {
            // Draw ellipse to screen.
            foreach (Disc disc in discs)
            {
                //Console.WriteLine($"(x,y):({disc.X},{disc.X})");
                
                Brush brush = new SolidBrush(disc.DiscColor);
                e.Graphics.FillEllipse(brush, disc.Rectangle);
            }

            
                DrawCenterOfMass(e);
        }

        private void UpdateDiscs(List<Disc> discs, PaintEventArgs e)
        {
            foreach (Disc disc in discs)
            {
                disc.UpdatePosition(e.ClipRectangle.Width, e.ClipRectangle.Height, e.ClipRectangle.Left, e.ClipRectangle.Top, centerForceField);
            }
        }

        private void DrawCenterOfMass(PaintEventArgs e)
        {
            Pen pen = new Pen(Color.Black, 5);
            e.Graphics.DrawEllipse(pen, centerForceField.X, centerForceField.Y, 1, 1);
        }

        private void MainForm_MouseClick(object sender, MouseEventArgs e)
        {
            Console.WriteLine($"Mouse click\nx:{e.X}, y:{e.Y}");
            centerForceField = new ForceField(e.X, e.Y, 25, 1);
        }
    }
}