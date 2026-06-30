using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace CoreBase.Winform
{
    /// <summary>
    /// 開關型式
    /// </summary>
    [Description("開關型式，文字請另行放Label中")]
    public class Switch : CheckBox
    {
        // Fields
        private Color onBackColor = Color.MediumSlateBlue;
        private Color onToggleColor = Color.WhiteSmoke;
        private Color offBackColor = Color.White;
        private Color offToggleColor = Color.MediumSlateBlue;
        private bool solidStyle = true;

        /// <summary>
        /// 啟動時的背景色
        /// </summary>
        [Category("按鈕配色")]
        [Description("啟動時的背景色")]
        public Color OnBackColor
        {
            get { return onBackColor; }
            set
            {
                onBackColor = value;
                // 讓預設值失效
                this.Invalidate();
            }
        }

        /// <summary>
        /// 啟動時按鈕色
        /// </summary>
        [Category("按鈕配色")]
        [Description("啟動時按鈕色")]
        public Color OnToggleColor
        {
            get { return onToggleColor; }
            set
            {
                onToggleColor = value;
                // 讓預設值失效
                this.Invalidate();
            }
        }

        /// <summary>
        /// 關閉時的背景色
        /// </summary>
        [Category("按鈕配色")]
        [Description("關閉時的背景色")]
        public Color OffBackColor
        {
            get { return offBackColor; }
            set
            {
                offBackColor = value;
                // 讓預設值失效
                this.Invalidate();
            }
        }

        /// <summary>
        /// 關閉時的按鈕色
        /// </summary>
        [Category("按鈕配色")]
        [Description("關閉時的按鈕色")]
        public Color OffToggleColor
        {
            get { return offToggleColor; }
            set
            {
                offToggleColor = value;
                // 讓預設值失效
                this.Invalidate();
            }
        }

        
        [Browsable(false)] // 隱藏選項
        public override string Text
        {
            get { return base.Text; }
            set 
            {
            }
        }

        /// <summary>
        /// 框線
        /// </summary>
        [DefaultValue(true)]
        [Category("按鈕配色")]
        [Description("框線")]
        public bool SolidStyle
        {
            get { return solidStyle; }
            set
            {
                solidStyle = value;
                this.Invalidate();
            }
        }

        [DefaultValue(false)]
        public override bool AutoSize
        {
            get; set;
        }

        /// <summary>
        /// 初始宣告 
        /// </summary>
        public Switch()
        {
            this.MinimumSize = new Size(45, 22);
        }

        //Methods
        /// <summary>
        /// 取得底圖路徑
        /// </summary>
        /// <returns></returns>
        private GraphicsPath GetFigurePath()
        {
            // 指定底圖範圍
            int arcSize = this.Height - 1;
            Rectangle leftArc = new Rectangle(0, 0, arcSize, arcSize);
            Rectangle rightArc = new Rectangle(this.Width - arcSize - 2, 0, arcSize, arcSize);

            GraphicsPath path = new GraphicsPath();
            path.StartFigure();
            path.AddArc(leftArc, 90, 180);
            path.AddArc(rightArc, 270, 180);
            path.CloseFigure();

            return path;
        }

        /// <summary>
        /// 繪制元件
        /// </summary>
        /// <param name="pevent"></param>
        protected override void OnPaint(PaintEventArgs pevent)
        {
            // 按鈕尺吋
            int toggleSize = this.Height - 5;
            pevent.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            pevent.Graphics.Clear(getParentBackColor(this.Parent));
            // ON
            if (this.Checked)
            {
                //Draw the control surface
                // 畫底圖
                // 有框線
                if (solidStyle)
                {
                    pevent.Graphics.FillPath(new SolidBrush(onBackColor), GetFigurePath());
                }
                else
                {
                    pevent.Graphics.DrawPath(new Pen(onBackColor, 2), GetFigurePath());
                }
                //Draw the toggle
                // 畫按鈕
                pevent.Graphics.FillEllipse(new SolidBrush(onToggleColor),
                    new Rectangle(this.Width - this.Height + 1, 2, toggleSize, toggleSize));
            }
            // OFF
            else
            {
                //Draw the control surface
                // 畫底圖
                // 有框線
                if (solidStyle)
                {
                    pevent.Graphics.FillPath(new SolidBrush(offBackColor), GetFigurePath());
                }
                else
                {
                    pevent.Graphics.DrawPath(new Pen(offBackColor, 2), GetFigurePath());
                }
                //Draw the toggle
                // 畫按鈕
                pevent.Graphics.FillEllipse(new SolidBrush(offToggleColor),
                    new Rectangle(2, 2, toggleSize, toggleSize));
            }
        }

        /// <summary>
        /// 抓背景色
        /// </summary>
        /// <param name="control"></param>
        /// <returns></returns>
        protected Color getParentBackColor(Control control)
        {
            // Parent層的背景色如為透明時，會變很醜，須往上抓至有顏色的層級
            if (Color.Transparent == control.Parent.BackColor)
            {
                if (control.Parent.Parent is Control)
                {
                    return getParentBackColor(control.Parent);
                }
            }

            return control.Parent.BackColor;
        }
    }
}
