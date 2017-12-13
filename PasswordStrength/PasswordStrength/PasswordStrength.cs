using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PasswordStrength
{
    /// <summary>
    /// 密码强度控件
    /// </summary>
    public partial class PasswordStrength : UserControl
    {
        /// <summary>
        /// 强度提示条默认背景颜色
        /// </summary>
        private Color _barBackColor = Color.Silver;
        /// <summary>
        /// 强度提示条默认背景颜色
        /// </summary>
        [Description("强度提示条默认背景颜色")]
        public Color BarBackColor
        {
            get
            {
                return this._barBackColor;
            }
            set
            {
                this._barBackColor = value;

                this.Refresh();
            }
        }
        /// <summary>
        /// 强度提示条高度
        /// </summary>
        private int _barHeight = 7;
        /// <summary>
        /// 强度提示条高度
        /// </summary>
        [Description("强度提示条高度")]
        public int BarHeight
        {
            get { return this._barHeight; }
            set
            {
                this._barHeight = value;

                this.Refresh();
            }
        }
        /// <summary>
        /// 强度提示条之间的间隔
        /// </summary>
        private int _gap = 5;
        /// <summary>
        /// 强度提示条之间的间隔
        /// </summary>
        [Description("强度提示条之间的间隔")]
        public int Gap
        {
            get
            {
                return this._gap;
            }
            set
            {
                this._gap = value;

                this.Refresh();
            }
        }
        /// <summary>
        /// 强度提示条内容
        /// </summary>
        private List<PasswordBar> _barContentList = new List<PasswordBar>();
        /// <summary>
        /// 强度提示条内容
        /// </summary>
        [Description("强度提示条内容")]
        [DesignerSerializationVisibilityAttribute(DesignerSerializationVisibility.Content)]
        public List<PasswordBar> BarContentList
        {
            get { return this._barContentList; }
            set
            {
                this._barContentList = value;
                this.Refresh();
            }
        }
        /// <summary>
        /// 当前密码强度
        /// </summary>
        private int _currentPasswordLevel = 0;
        /// <summary>
        /// 当前密码强度
        /// </summary>
        [Description("当前密码强度")]
        public int CurrentPasswordLevel
        {
            get
            {
                return this._currentPasswordLevel;
            }
            set
            {
                this._currentPasswordLevel = value;

                this.Refresh();
            }
        }
        /// <summary>
        /// 半径
        /// </summary>
        private int _radius = 12;
        /// <summary>
        /// 半径
        /// </summary>
        [Description("半径")]
        public int Radius
        {
            get { return this._radius; }
            set
            {
                this._radius = value;
                this.Refresh();
            }
        }
        /// <summary>
        /// 判断是否处在设计模式
        /// </summary>
        /// <returns></returns>
        private bool IsDesignMode()
        {
            return (this.GetService(typeof(System.ComponentModel.Design.IDesignerHost)) != null
                && LicenseManager.UsageMode == LicenseUsageMode.Designtime);
        }
        /// <summary>
        /// 构造函数
        /// </summary>
        public PasswordStrength()
        {
            InitializeComponent();
        }

        private void PasswordStrength_Load(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// 重绘
        /// </summary>
        /// <param name="e"></param>
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            this.InitializePasswordBar();

            this.Redraw(e.Graphics);
        }
        /// <summary>
        /// 初始化默认的密码强度
        /// </summary>
        private void InitializePasswordBar()
        {
            // 执行顺序：初始化属性 -> 构造函数 -> 设计器函数(父容器中的对此控件进行初始化的函数) ->  OnPaint函数
            if (this.BarContentList.Count == 0)
            {
                this.BarContentList.Add(new PasswordBar()
                {
                    Content = "弱",
                    BarColor = System.Drawing.Color.Red
                });
                this.BarContentList.Add(new PasswordBar()
                {
                    Content = "中",
                    BarColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(70)))))
                });
                this.BarContentList.Add(new PasswordBar()
                {
                    Content = "强",
                    BarColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))))
                });
            }
        }
        /// <summary>
        /// 重绘
        /// </summary>
        /// <param name="g"></param>
        public void Redraw(Graphics g)
        {
            //if ((null == g) && ((IntPtr.Zero == this.Handle) || (!this.IsHandleCreated)))
            //{
            //    return;
            //}

            //if (null == g)
            //{
            //    g = Graphics.FromHwnd(this.Handle);
            //}

            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            // 高度
            float nHeight = this.Height - this.Padding.Top - this.Padding.Bottom - this.BarHeight;
            // 宽度
            float nWidth = this.Width - this.Padding.Left - this.Padding.Right;

            float nX = this.Padding.Left;
            float nY = this.Padding.Top + nHeight / 2;
            if ((nWidth < 0) || (nY < 0))
            {
                return;
            }
            if (this.BarContentList.Count < 1)
            {
                return;
            }

            // 强度提示条宽度
            float nBarWidth = (nWidth - this.Gap * (this.BarContentList.Count - 1)) / ((float)this.BarContentList.Count);

            for (int i = 0; i < this.BarContentList.Count; i++)
            {
                using (Pen pen = new Pen(Color.Black))
                {
                    Color BrushColor = this.BarBackColor;
                    if (this.CurrentPasswordLevel > i)
                    {
                        BrushColor = this.BarContentList[i].BarColor;
                    }

                    g.FillRectangle(new SolidBrush(BrushColor), nX + (i * this.Gap + i * nBarWidth), nY, nBarWidth, this.BarHeight);
                    if ((this.CurrentPasswordLevel - 1) == i)
                    {
                        g.FillEllipse(new SolidBrush(BrushColor), nX + (i * this.Gap + i * nBarWidth) + nBarWidth / 2 - this.Radius, nY + this.BarHeight / 2 - this.Radius, 2 * this.Radius, 2 * this.Radius);
                        g.DrawString(this.BarContentList[i].Content,
                            new Font("宋体", 10),
                            new SolidBrush(Color.White),
                            new RectangleF(nX + (i * this.Gap + i * nBarWidth) + nBarWidth / 2 - this.Radius + 1.5F, nY + this.BarHeight / 2 - this.Radius, 2 * this.Radius, 2 * this.Radius + 5),
                            new StringFormat() { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center });
                    }
                }
            }
        }
    }
}
