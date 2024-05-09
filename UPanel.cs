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

namespace WinStoreWaterSystem
{
    /// <summary>
    /// 圆角面板
    /// </summary>
    public partial class UPanel : Panel
    {
        public UPanel()
        {
            InitializeComponent();
            SetStyle(ControlStyles.AllPaintingInWmPaint, true); // 忽略窗口消息 减少闪烁
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true); // 双缓冲 '事先绘制到缓冲存而不是屏幕' 减少闪烁
            SetStyle(ControlStyles.UserPaint, true); // 控件由其自身绘制而不是操作系统绘制
            SetStyle(ControlStyles.ResizeRedraw, true); // 控件调整其大小时重绘
            SetStyle(ControlStyles.SupportsTransparentBackColor, true); // 支持透明背景
            SetStyle(ControlStyles.Selectable, false); // 不可以接受焦点
        }
        private Color bgColor = Color.LightGray;
        /// <summary>
        /// 背景色1（渐变颜色1）
        /// </summary>
        [DefaultValue(typeof(Color), "LightGray"), Description("控件的背景色1")]
        public Color BgColor
        {
            get { return bgColor; }
            set
            {
                bgColor = value;
                Refresh(); // 立即重绘
                // Invalidate(); // 引发重绘，不会立即执行
            }
        }
        private Color bgColor2 = Color.Transparent;
        /// <summary>
        /// 背景色2（渐变颜色2）
        /// </summary>
        [DefaultValue(typeof(Color), "Transparent"), Description("控件的背景色2")]
        public Color BgColor2
        {
            get { return bgColor2; }
            set
            {
                bgColor2 = value;
                Refresh(); // 立即重绘
                // Invalidate(); // 引发重绘，不会立即执行
            }
        }

        private Color borderColor = Color.Gray;
        /// <summary>
        /// 边框颜色
        /// </summary>
        [DefaultValue(typeof(Color), "Gray"), Description("控件的边框颜色")]
        public Color BorderColor
        {
            get { return borderColor; }
            set
            {
                borderColor = value;
                Refresh(); // 立即重绘
                // Invalidate(); // 引发重绘，不会立即执行
            }
        }

        private int borderWidth = 0;
        /// <summary>
        /// 边框粗细
        /// </summary>
        [DefaultValue(typeof(int), "0"), Description("控件的边框粗细")]
        public int BorderWidth
        {
            get { return borderWidth; }
            set
            {
                borderWidth = value;
                Refresh(); // 立即重绘
                // Invalidate(); // 引发重绘，不会立即执行
            }
        }

        private int radius = 5;
        /// <summary>
        /// 边框圆角半径
        /// </summary>
        [DefaultValue(typeof(int), "5"), Description("控件的边框圆角半径")]
        public int Radius
        {
            get { return radius; }
            set
            {
                radius = value;
                Refresh(); // 立即重绘
                // Invalidate(); // 引发重绘，不会立即执行
            }
        }
        private LinearGradientMode gradientMode = LinearGradientMode.Vertical;
        /// <summary>
        /// 背景渐变模式
        /// </summary>
        [DefaultValue(typeof(LinearGradientMode), ".Vertical"), Description("控件的背景渐变模式")]
        public LinearGradientMode GradientMode
        {
            get { return gradientMode; }
            set
            {
                gradientMode = value;
                Refresh(); // 立即重绘
                // Invalidate(); // 引发重绘，不会立即执行
            }
        }
        Rectangle r; // 绘制区域
        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            // 获取工作区域 重新绘制
            r = this.ClientRectangle;
            this.Region = new Region(r);
            r.Width -= 1;
            r.Height -= 1;
        }
        /// <summary>
        /// 重写绘制事件
        /// </summary>
        /// <param name="e"></param>
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            // 绘制工作 边框 背景
            Graphics g = e.Graphics; // 绘图对象
            // 呈现质量 
            g.SmoothingMode = SmoothingMode.AntiAlias;
            GraphicsPath path1 = new GraphicsPath(); // 边框的圆角
            GraphicsPath path2 = new GraphicsPath(); // 背景部分的圆角矩形
            Rectangle rect;// 内部填充的矩形
            if (radius > 0)
            {
                // 生成外部矩形的圆角矩形路径
                path1 = PaintClass.GetRoundRectangle(r, radius);
                if (borderWidth > 0)
                {
                    g.FillPath(new SolidBrush(borderColor), path1);// 填充外边框矩形区域
                    // 定义内部矩形结构
                    rect = new Rectangle(r.X + borderWidth, r.Y + borderWidth, r.Width - 2 * borderWidth, r.Height - 2 * borderWidth);
                    // 生成内部矩形的圆角矩形路径
                    path2 = PaintClass.GetRoundRectangle(rect, radius - 1);
                }
                else
                {
                    path2 = path1;
                    rect = r;
                }
                // g.FillPath(new SolidBrush(borderColor), path1); // 填充边框矩形
                if (bgColor2 != Color.Transparent)
                {
                    // 渐变画刷
                    LinearGradientBrush bgBrush = new LinearGradientBrush(rect, bgColor, bgColor2, gradientMode);
                    g.FillPath(bgBrush, path2); // 填充背景
                }
                else
                {
                    Brush b = new SolidBrush(borderColor);
                    g.FillPath(b, path2);
                }
            }
            else
            {
                if (borderWidth > 0)
                {
                    g.FillRectangle(new SolidBrush(borderColor), r);// 填充外边框矩形区域
                    // 定义内部矩形结构
                    rect = new Rectangle(r.X + borderWidth, r.Y + borderWidth, r.Width - 2 * borderWidth, r.Height - 2 * borderWidth);
                }
                else
                {
                    rect = r;
                }
                // 背景色填充
                if (bgColor2 != Color.Transparent)
                {
                    // 渐变画刷
                    LinearGradientBrush bgBrush = new LinearGradientBrush(rect, bgColor, bgColor2, gradientMode);
                    g.FillRectangle(bgBrush, rect); // 填充背景
                }
                else
                {
                    Brush b = new SolidBrush(borderColor);
                    g.FillRectangle(b, rect); 
                    // Test
                }
            }
        }

    }
}
