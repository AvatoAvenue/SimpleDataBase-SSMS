using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;


namespace sql_topicos_sc
{
    internal class forms
    {
        //formulario base
        public class mainForm : Form
        {
            public mainForm()
            {
                this.WindowState = FormWindowState.Maximized;
                this.MinimumSize = new Size(1280, 720);
                this.BackColor = Color.Black;
            }
        }
        //grupo de botones, labels y comboboxes
        public class groups : TableLayoutPanel
        {
            private mainForm parentForm;
            public groups(mainForm form)
            {
                this.parentForm = form;
                this.Dock = DockStyle.None;
                this.Size = parentForm.ClientSize;
                this.parentForm.SizeChanged += MainForm_SizeChanged;
            }

            private void MainForm_SizeChanged(object sender, EventArgs e)
            {
                this.Size = parentForm.ClientSize;
            }
        }
        //botón
        public class roundButton : Button
        {
            private int diameter = 30;
            private Color hoverColor = Color.FromArgb(0,80,142);
            private Color normalColor = Color.FromArgb(0, 122, 204);
            private Color textColor = Color.FromArgb(255, 255, 255);

            private Size originalSize;
            private Size targetSize;
            private Timer timer;
            private Size expansion = new Size(5,5);

            public roundButton()
            {
                this.Size = new Size(100, 40);
                this.FlatStyle = FlatStyle.Flat;
                this.FlatAppearance.BorderSize = 0;
                this.TextAlign = ContentAlignment.MiddleCenter;
                this.AutoSize = true;
                this.BackColor = normalColor;
                this.ForeColor = textColor;
                this.Font = new Font(this.Font, FontStyle.Bold);

                originalSize = this.Size;
                targetSize = this.Size + expansion;

                this.MouseEnter += roundButton_MouseEnter;
                this.MouseLeave += roundButton_MouseLeave;
            }
            private void roundButton_MouseEnter(object sender, EventArgs e)
            {
                this.BackColor = hoverColor;
                AnimateButton(targetSize);
            }
            private void roundButton_MouseLeave(object sender, EventArgs e)
            {
                this.BackColor = normalColor;
                AnimateButton(originalSize);
            }

            private void AnimateButton(Size targetSize)
            {
                if (timer != null && timer.Enabled)
                {
                    timer.Stop();
                    timer.Dispose();
                }

                timer = new Timer();
                timer.Interval = 10;

                int deltaX = (targetSize.Width - originalSize.Width) / 2;
                int deltaY = (targetSize.Height - originalSize.Height) / 2;

                timer.Tick += (sender, e) =>
                {
                    int newWidth = this.Width + deltaX;
                    int newHeight = this.Height + deltaY;
                    int newLeft = this.Left - deltaX;
                    int newTop = this.Top - deltaY;

                    if (newWidth >= targetSize.Width)
                    {
                        newWidth = targetSize.Width;
                        newLeft = this.Left - (targetSize.Width - this.Width);
                    }

                    if (newHeight >= targetSize.Height)
                    {
                        newHeight = targetSize.Height;
                        newTop = this.Top - (targetSize.Height - this.Height);
                    }

                    this.Size = new Size(newWidth, newHeight);
                    this.Location = new Point(newLeft, newTop);
                    this.Region = new Region(new Rectangle(0, 0, this.Width, this.Height));

                    if (this.Size == targetSize)
                    {
                        timer.Stop();
                        timer.Dispose();
                    }
                };

                timer.Start();
            }

            protected override void OnPaint(PaintEventArgs pevent)
            {
                base.OnPaint(pevent);

                GraphicsPath path = new GraphicsPath();
                Rectangle rectangulo = new Rectangle(0, 0, diameter, diameter);
                path.AddArc(rectangulo, 180, 90);
                rectangulo.X = this.Width - diameter;
                path.AddArc(rectangulo, 270, 90);
                rectangulo.Y = this.Height - diameter;
                path.AddArc(rectangulo, 0, 90);
                rectangulo.X = 0;
                path.AddArc(rectangulo, 90, 90);
                this.Region = new Region(path);
            }
        }
        //combobox para insertar texto
        public class inserterText : TextBox
        {
            public inserterText()
            {

            }
        }
        //texto para aclaraciones
        public class ShowControlText : Label
        {
            private Color textColor = Color.FromArgb(255, 255, 255);
            public ShowControlText()
            {
                this.ForeColor = textColor;
            }

        }
        public class readerGrid : DataGridView
        {
            private mainForm parentForm;
            public readerGrid(mainForm form)
            {
                this.parentForm = form;
                this.Size = parentForm.ClientSize;
                this.parentForm.SizeChanged += MainForm_SizeChanged;
            }
            private void MainForm_SizeChanged(object sender, EventArgs e)
            {
                this.Size = parentForm.ClientSize;
            }
        }
    }
}
