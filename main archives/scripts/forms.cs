using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;
using static sql_topicos_sc.datamethods;
using static sql_topicos_sc.procedure;


namespace sql_topicos_sc
{
    internal class forms
    {
        //formulario base
        public class mainForm : Form
        {
            public mainForm()
            {

            }

            public void ChangePanel(groups _panel)
            {

            }
        }
        //grupo de botones, labels y comboboxes
        public class groups : TableLayoutPanel
        {
            public groups()
            {

            }

            public void groupsSizeChange(mainForm _form)
            {

            }
        }
        //botón
        public class roundButton : Button
        {
            private Color hoverColor = Color.FromArgb(0,80,142);
            private Color normalColor = Color.FromArgb(0, 122, 204);
            private Color textColor = Color.FromArgb(0, 0, 0);

            private int borderRadius = 20;

            private Size originalSize;
            private Size targetSize;
            private Timer timer;
            private Size expansion = new Size(5,5);

            public roundButton()
            {
                this.Size = new Size(100, 40);
                this.FlatStyle = FlatStyle.Flat;
                this.FlatAppearance.BorderSize = 0;
                this.BackColor = normalColor;
                this.ForeColor = textColor;
                this.Font = new System.Drawing.Font(this.Font, FontStyle.Bold);

                originalSize = this.Size;
                targetSize = this.Size + expansion;

                this.Paint += roundButton_Paint;
                this.MouseEnter += roundButton_MouseEnter;
                this.MouseLeave += roundButton_MouseLeave;
            }
            private void roundButton_MouseEnter(object sender, EventArgs e)
            {
                this.BackColor = hoverColor;
                AnimateButton(targetSize);
                Console.WriteLine(this.Size);
            }
            private void roundButton_MouseLeave(object sender, EventArgs e)
            {
                this.BackColor = normalColor;
                AnimateButton(originalSize);
                Console.WriteLine(this.Size);
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

                Size deltaSize = new Size(targetSize.Width - this.Width, targetSize.Height - this.Height);

                timer.Tick += (sender, e) =>
                {
                    if (deltaSize.Width > 0 && this.Width < targetSize.Width ||
                        deltaSize.Width < 0 && this.Width > targetSize.Width ||
                        deltaSize.Height > 0 && this.Height < targetSize.Height ||
                        deltaSize.Height < 0 && this.Height > targetSize.Height)
                    {
                        this.Width += Math.Sign(deltaSize.Width);
                        this.Height += Math.Sign(deltaSize.Height);
                        this.Region = new Region(new Rectangle(0, 0, this.Width, this.Height));
                    }
                    else
                    {
                        this.Size = targetSize;
                        this.Region = new Region(new Rectangle(0, 0, this.Width, this.Height));
                        timer.Stop();
                        timer.Dispose();
                    }
                };

                timer.Start();
            }

            private void roundButton_Paint(object sender, PaintEventArgs e)
            {
                GraphicsPath path = new GraphicsPath();

                path.AddArc(0, 0, borderRadius * 2, borderRadius * 2, 180, 90);
                path.AddArc(this.Width - borderRadius * 2, 0, borderRadius * 2, borderRadius * 2, 270, 90);
                path.AddArc(this.Width - borderRadius * 2, this.Height - borderRadius * 2, borderRadius * 2, borderRadius * 2, 0, 90);
                path.AddArc(0, this.Height - borderRadius * 2, borderRadius * 2, borderRadius * 2, 90, 90);
                path.CloseFigure();

                e.Graphics.FillPath(new SolidBrush(this.BackColor), path);
                e.Graphics.DrawPath(new Pen(this.BackColor), path);

                StringFormat sf = new StringFormat();
                sf.LineAlignment = StringAlignment.Center;
                sf.Alignment = StringAlignment.Center;
                e.Graphics.DrawString(this.Text, this.Font, new SolidBrush(this.ForeColor), this.ClientRectangle, sf);
            }

            protected override void OnTextChanged(EventArgs e)
            {
                base.OnTextChanged(e);

                Size size = TextRenderer.MeasureText(this.Text, this.Font);
                this.Width = size.Width + 20;
                this.Height = size.Height + 25;
                this.Region = new Region(new Rectangle(0, 0, this.Width, this.Height));
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
            public ShowControlText()
            {

            }

        }
    }
}
