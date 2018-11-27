using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
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
        private Liquid liquid;
        private Attractor attractor;
        private float dt;

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
            dt = timer.Interval;
            timer.Start();
        }

        private void MainForm_Paint(object sender, PaintEventArgs e)
        {
            string elapsedTimeText = $"time: {(elapsedTime / 1000).ToString("F1")} [s]";
            TextRenderer.DrawText(e.Graphics, elapsedTimeText, this.Font,
                new Rectangle(0, 0, 100, 25), Color.Blue);

            DrawLiquid(e);
            DrawAttractor(e);
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
                Color.ForestGreen,
                Color.Chartreuse,
                Color.Coral,
                Color.BlueViolet, 
                Color.DarkCyan,
                Color.DarkKhaki
            };

            int size = _colors.Length;

            Random rand = new Random();

            int N = 50;
            for (int i = 0; i < N; i++)
            {
                Discs.Add(
                    new Disc(
                        new Vector(rand.Next(0,500), rand.Next(0,400)),
                        new Vector((float)rand.NextDouble() * rand.Next(0,5), (float) rand.NextDouble() * rand.Next(0, 4)),
                        rand.Next(2,10),
                        rand.Next(5,20),
                        _colors[rand.Next(0,size)]
                        )
                    );
            }


            liquid = new Liquid(new RectangleF(100,100,50,50), Color.Aquamarine, 0.00025f);
            attractor = new Attractor();

            massSlider.Value = (int) attractor.Mass;
            attractorMassLabel.Text = "M: " + attractor.Mass.ToString("F") + " [kg]";
            gLabel.Text = "G: " + attractor.G.ToString("F");
            cLabel.Text = "c: " + liquid.C.ToString("F");
        }

        private void DrawDiscs(IList<Disc> discs, PaintEventArgs e)
        {
            
            foreach (Disc disc in discs)
            {
                
                Brush brush = new SolidBrush(disc.DiscColor);
                e.Graphics.FillEllipse(brush, disc.Rectangle);

                if (disc.IsInside(liquid))
                {
                    disc.Drag(liquid);
                }

                Vector force = attractor.Attract(disc);
                disc.ApplyForce(force);

            }

        }


        private void DrawLiquid(PaintEventArgs e)
        {
            Brush brush = new SolidBrush(liquid.Color);
            e.Graphics.FillRectangle(brush, liquid.Rectangle);
        }

        private void DrawAttractor(PaintEventArgs e)
        {
            Brush brush = new SolidBrush(Color.Black);
            e.Graphics.FillEllipse(brush, new RectangleF(attractor.Location.X, attractor.Location.Y, 10, 10));
        }

        private void UpdateDiscs(List<Disc> discs, PaintEventArgs e)
        {
            foreach (Disc disc in discs)
            {
                disc.UpdatePosition(
                    e.ClipRectangle.Width, 
                    e.ClipRectangle.Height,
                    e.ClipRectangle.Left,
                    e.ClipRectangle.Top
                    );
            }
        }

        private void MainForm_MouseClick(object sender, MouseEventArgs e)
        {
            Console.WriteLine($"Mouse click\nx:{e.X}, y:{e.Y}");
            
            attractor.ChangeLocation(e.Location);
        }

        private void massSlider_Scroll(object sender, EventArgs e)
        {
            attractor.ChangeMass(massSlider.Value);
            attractorMassLabel.Text = "M: " + attractor.Mass.ToString("F") + " [kg]";
        }

        private void gSlider_Scroll(object sender, EventArgs e)
        {
            float value = 0.01f * gSlider.Value;
            attractor.ChangeGConstant(value);
            gLabel.Text = "G: " + attractor.G.ToString("F");
        }

        private void cSlider_Scroll(object sender, EventArgs e)
        {
            float value = 0.001f * cSlider.Value;
            liquid.C = value;
            cLabel.Text = "c: " + liquid.C.ToString("F");
        }
    }
}