using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MiksRadarDesktop
{
    class RadarPanel : Panel
    {
        double range = 1.0;
        private Color gridColor = Color.FromArgb(0, 211, 15);
        private int[] angles = { -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, };
        private int[] distances = { -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, };

        public RadarPanel()
        {

        }


        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = CreateGraphics();
            g.SmoothingMode = SmoothingMode.AntiAlias;
            DrawGrid(g);
        }

        protected override void OnPaintBackground(PaintEventArgs e) { }

        private void DrawGrid(Graphics g)
        {
            g.FillRectangle(new SolidBrush(Color.Black), new Rectangle(0, 0, Size.Width, Size.Height));
            Pen gridPen = new Pen(gridColor, 3);
            Rectangle rect = new Rectangle(12, 12, 1000, 1000);
            g.DrawArc(gridPen, rect, 0, -180);
            rect = new Rectangle(137, 137, 750, 750);
            g.DrawArc(gridPen, rect, 0, -180);
            rect = new Rectangle(262, 262, 500, 500);
            g.DrawArc(gridPen, rect, 0, -180);
            rect = new Rectangle(387, 387, 250, 250);
            g.DrawArc(gridPen, rect, 0, -180);

            g.DrawLine(gridPen, 512, 0, 512, 512);
            g.DrawLine(gridPen, 0, 510, 1024, 510);
            DrawAngledLine(g, gridPen, new Point(512, 512), -30, 512);
            DrawAngledLine(g, gridPen, new Point(512, 512), -60, 512);
            DrawAngledLine(g, gridPen, new Point(512, 512), -120, 512);
            DrawAngledLine(g, gridPen, new Point(512, 512), -150, 512);

            DrawLabel(g, 1);
            DrawLabel(g, 2);
            DrawLabel(g, 3);
            DrawLabel(g, 4);

            DrawRadarStripe(g, 10, gridColor);
        }

        private void DrawAngledLine(Graphics g, Pen pen, Point start, int angle, int length)
        {
            double angleRad = (angle * Math.PI) / 180;
            int endX = start.X + (int)(length * Math.Cos(angleRad));
            int endY = start.X + (int)(length * Math.Sin(angleRad));
            Point end = new Point(endX, endY);
            g.DrawLine(pen, start, end);
        }

        private void DrawLabel(Graphics g, int scale)
        {
            double value = range / 4 * (5 - scale);
            string str = value.ToString("0.00") + " m";
            Font font = new Font(FontFamily.GenericSansSerif, 10);
            SolidBrush brush = new SolidBrush(gridColor);
            int x = (scale - 1) * 125 + 15;
            g.DrawString(str, font, brush, new PointF(x, 492));
        }

        private void DrawRadarStripe(Graphics g, int angle, Color color)
        {
            SolidBrush brush = new SolidBrush(color);
            g.FillPie(brush, new Rectangle(0, 0, 1024, 1024), -1 + 0.125f, -1.75f);
            g.FillPie(brush, new Rectangle(0, 0, 1024, 1024), -3 + 0.125f, -1.75f);
            g.FillPie(brush, new Rectangle(0, 0, 1024, 1024), -5 + 0.125f, -1.75f);
            g.FillPie(brush, new Rectangle(0, 0, 1024, 1024), -7 + 0.125f, -1.75f);
            g.FillPie(brush, new Rectangle(0, 0, 1024, 1024), -9 + 0.125f, -1.75f);
            g.FillPie(brush, new Rectangle(0, 0, 1024, 1024), -11 + 0.125f, -1.75f);
            g.FillPie(brush, new Rectangle(0, 0, 1024, 1024), -13 + 0.125f, -1.75f);
            g.FillPie(brush, new Rectangle(0, 0, 1024, 1024), -15 + 0.125f, -1.75f);
            g.FillPie(brush, new Rectangle(0, 0, 1024, 1024), -17 + 0.125f, -1.75f);
            g.FillPie(brush, new Rectangle(0, 0, 1024, 1024), -19 + 0.125f, -1.75f);
            g.FillPie(brush, new Rectangle(0, 0, 1024, 1024), -21 + 0.125f, -1.75f);
            g.FillPie(brush, new Rectangle(0, 0, 1024, 1024), -23 + 0.125f, -1.75f);
            g.FillPie(brush, new Rectangle(0, 0, 1024, 1024), -25 + 0.125f, -1.75f);
            g.FillPie(brush, new Rectangle(0, 0, 1024, 1024), -27 + 0.125f, -1.75f);
            g.FillPie(brush, new Rectangle(0, 0, 1024, 1024), -29 + 0.125f, -1.75f);
            g.FillPie(brush, new Rectangle(0, 0, 1024, 1024), -31 + 0.125f, -1.75f);
            g.FillPie(brush, new Rectangle(0, 0, 1024, 1024), -33 + 0.125f, -1.75f);
            g.FillPie(brush, new Rectangle(0, 0, 1024, 1024), -35 + 0.125f, -1.75f);
            g.FillPie(brush, new Rectangle(0, 0, 1024, 1024), -37 + 0.125f, -1.75f);
            g.FillPie(brush, new Rectangle(0, 0, 1024, 1024), -39 + 0.125f, -1.75f);
        }

        public void AddMeasurement(string str)
        {
            Regex rgx = new Regex("(\\d+)\\:(\\d+)");
            GroupCollection groups = rgx.Match(str).Groups;
            int angle = Convert.ToInt32(groups[1].Value);
            int distance = Convert.ToInt32(groups[2].Value);
            for (int i = 19; i >= 1; i--)
            {
                angles[i] = angles[i - 1];
                distances[i] = distances[i - 1];
                angles[0] = angle;
                distances[0] = distance;
            }
        }
    }
}
