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
using System.Windows.Forms.VisualStyles;

namespace WinStoreWaterSystem
{
    public partial class UCPipe : UserControl
    {
        System.Timers.Timer timer = null;
        int intLineLeft = 0;// 线的左边的距离 
        int intPenWidth = 0;// 圆弧的半径值
        public UCPipe()
        {
            InitializeComponent();
            SetStyle(ControlStyles.AllPaintingInWmPaint, true); // 忽略窗口消息 减少闪烁
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true); // 双缓冲 '事先绘制到缓冲存而不是屏幕' 减少闪烁
            SetStyle(ControlStyles.UserPaint, true); // 控件由其自身绘制而不是操作系统绘制
            SetStyle(ControlStyles.ResizeRedraw, true); // 控件调整其大小时重绘
            SetStyle(ControlStyles.SupportsTransparentBackColor, true); // 支持透明背景
            SetStyle(ControlStyles.Selectable, false); // 不可以接受焦点
            SizeChanged += UCPipe_SizeChanged;
            this.Size = new Size(200, 30);
            timer = new System.Timers.Timer();
            timer.Interval = 100;
            timer.AutoReset = true;
            timer.Elapsed += Timer_Elapsed;
        }

        private void Timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            intLineLeft += 2;
            if (intLineLeft > 12)
            {
                intLineLeft = 0;
            }
            Invalidate();
        }

        private void UCPipe_SizeChanged(object sender, EventArgs e)
        {
            intPenWidth = pipeStyle.ToString().Substring(0, 1) == "H" ? Height : Width;
        }
        private PipeStyle pipeStyle = PipeStyle.Horizontal_None_None;
        [DefaultValue(typeof(PipeStyle), "Horizontal_None_None"), Description("管道样式")]
        public PipeStyle PipeStyle
        {
            get { return pipeStyle; }
            set
            {
                string oldStr = pipeStyle.ToString().Substring(0, 1);
                string newStr = value.ToString().Substring(0, 1);
                pipeStyle = value;
                if (oldStr != newStr)
                {
                    Size = new Size(Size.Height, Size.Width);
                }
                Invalidate();
            }
        }
        private bool isFlow = false;
        [DefaultValue(typeof(bool), "false"), Description("是否流动")]
        public bool IsFlow
        {
            get { return isFlow; }
            set
            {
                isFlow = value;
                if (isFlow)
                {
                    timer.Enabled = true;
                }
                else
                {
                    timer.Enabled = false;
                }
                Invalidate();
            }
        }
        private int flowWidth = 4;
        [DefaultValue(typeof(int), "4"), Description("流动线的粗细")]
        public int FlowWidth
        {
            get { return flowWidth; }
            set
            {
                flowWidth = value;
                if (flowWidth <= 0)
                    flowWidth = 1;
                Invalidate();
            }
        }
        private int flowLength = 8;
        [DefaultValue(typeof(int), "8"), Description("流动线的长度")]
        public int FlowLength
        {
            get { return flowLength; }
            set
            {
                flowLength = value;
                if (flowLength <= 0)
                    flowLength = 1;
                Invalidate();
            }
        }
        private int flowSpace = 4;
        [DefaultValue(typeof(int), "4"), Description("流动线的间隔")]
        public int FlowSpace
        {
            get { return flowSpace; }
            set
            {
                flowSpace = value;
                if (flowSpace <= 0)
                    flowSpace = 1;
                Invalidate();
            }
        }
        private Color pipeColor = Color.LightBlue;
        [DefaultValue(typeof(Color), "LightBlue"), Description("管道的颜色")]
        public Color PipeColor
        {
            get { return pipeColor; }
            set
            {
                pipeColor = value;
                Invalidate();
            }
        }
        private Color flowColor = Color.White;
        [DefaultValue(typeof(Color), "White"), Description("流动线的颜色")]
        public Color FlowColor
        {
            get { return flowColor; }
            set
            {
                flowColor = value;
                Invalidate();
            }
        }
        private FlowDirection flowDirection = FlowDirection.Forward;
        [DefaultValue(typeof(FlowDirection), "Forward"), Description("流动方向")]
        public FlowDirection FlowDirection
        {
            get { return flowDirection; }
            set
            {
                flowDirection = value;
                Invalidate();
            }
        }
        private int flowSpeed = 100;
        [DefaultValue(typeof(int), "100"), Description("流动速度（ms）")]
        public int FlowSpeed
        {
            get { return flowSpeed; }
            set
            {
                flowSpeed = value;
                if (flowSpace <= 0)
                    flowSpace = 1;
                timer.Interval = flowSpeed;
                Invalidate();
            }
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            GraphicsPath path = new GraphicsPath();// 管道轮廓路径
            GraphicsPath linePath = new GraphicsPath(); // 流动线外围路径
            switch (pipeStyle)
            {
                case PipeStyle.Horizontal_None_None:
                    path.AddLines(new PointF[4]
                    {
                new PointF(0f, 0f),
                new PointF(base.ClientRectangle.Right, 0f),
                new PointF(base.ClientRectangle.Right, base.Height),
                new PointF(0f, base.Height)
                    });
                    path.CloseAllFigures();
                    linePath.AddLine(0, base.Height / 2, base.Width, base.Height / 2);
                    break;
                case PipeStyle.Horizontal_Up_None:
                    path.AddLines(new PointF[4]
                    {
                new PointF(0f, 0f),
                new PointF(base.ClientRectangle.Right, 0f),
                new PointF(base.ClientRectangle.Right, base.Height),
                new PointF(intPenWidth, base.Height)
                    });
                    path.AddArc(new Rectangle(0, intPenWidth * -1, intPenWidth * 2, intPenWidth * 2), 90f, 90f);
                    path.CloseAllFigures();
                    linePath.AddArc(new Rectangle(intPenWidth / 2 + 1, -1 * intPenWidth / 2 - 1, intPenWidth, intPenWidth), 181f, -91f);
                    linePath.AddLine(intPenWidth, base.Height / 2, base.Width, base.Height / 2);
                    break;
                case PipeStyle.Horizontal_Down_None:
                    path.AddLines(new PointF[4]
                    {
                new PointF(intPenWidth, 0f),
                new PointF(base.ClientRectangle.Right, 0f),
                new PointF(base.ClientRectangle.Right, base.Height),
                new PointF(0f, base.Height)
                    });
                    path.AddArc(new Rectangle(0, 0, intPenWidth * 2, intPenWidth * 2), 180f, 90f);
                    path.CloseAllFigures();
                    linePath.AddArc(new Rectangle(intPenWidth / 2 + 1, base.Height / 2, intPenWidth, intPenWidth), 179f, 91f);
                    linePath.AddLine(intPenWidth + 1, base.Height / 2, base.Width, base.Height / 2);
                    break;
                case PipeStyle.Horizontal_None_Up:
                    path.AddLines(new PointF[4]
                    {
                new PointF(base.ClientRectangle.Right - intPenWidth, base.Height),
                new PointF(0f, base.Height),
                new PointF(0f, 0f),
                new PointF(base.ClientRectangle.Right, 0f)
                    });
                    path.AddArc(new Rectangle(base.ClientRectangle.Right - intPenWidth * 2, intPenWidth * -1, intPenWidth * 2, intPenWidth * 2), 0f, 90f);
                    path.CloseAllFigures();
                    linePath.AddLine(0, base.Height / 2, base.Width - intPenWidth, base.Height / 2);
                    linePath.AddArc(new Rectangle(base.ClientRectangle.Right - intPenWidth - intPenWidth / 2 - 1, -1 * intPenWidth / 2 - 1, intPenWidth, intPenWidth), 91f, -91f);
                    break;
                case PipeStyle.Horizontal_None_Down:
                    path.AddLines(new PointF[4]
                    {
                new PointF(base.ClientRectangle.Right, base.Height),
                new PointF(0f, base.Height),
                new PointF(0f, 0f),
                new PointF(base.ClientRectangle.Right - intPenWidth, 0f)
                    });
                    path.AddArc(new Rectangle(base.ClientRectangle.Right - intPenWidth * 2, -1, intPenWidth * 2, intPenWidth * 2), 270f, 90f);
                    path.CloseAllFigures();
                    linePath.AddLine(0, base.Height / 2, base.Width - intPenWidth - 1, base.Height / 2);
                    linePath.AddArc(new Rectangle(base.ClientRectangle.Right - intPenWidth - intPenWidth / 2 - 1, intPenWidth / 2, intPenWidth, intPenWidth), 269f, 91f);
                    break;
                case PipeStyle.Horizontal_Down_Up:
                    path.AddLine(new Point(intPenWidth, 0), new Point(base.Width, 0));
                    path.AddArc(new Rectangle(base.ClientRectangle.Right - intPenWidth * 2, intPenWidth * -1, intPenWidth * 2, intPenWidth * 2), 0f, 90f);
                    path.AddLine(new Point(base.Width - intPenWidth, base.Height), new Point(0, base.Height));
                    path.AddArc(new Rectangle(0, 0, intPenWidth * 2, intPenWidth * 2), 180f, 90f);
                    path.CloseAllFigures();
                    linePath.AddArc(new Rectangle(intPenWidth / 2 + 1, base.Height / 2, intPenWidth, intPenWidth), 179f, 91f);
                    linePath.AddArc(new Rectangle(base.ClientRectangle.Right - intPenWidth - intPenWidth / 2 - 1, -1 * intPenWidth / 2 - 1, intPenWidth, intPenWidth), 91f, -91f);
                    break;
                case PipeStyle.Horizontal_Up_Down:
                    path.AddLine(new Point(0, 0), new Point(base.Width - intPenWidth, 0));
                    path.AddArc(new Rectangle(base.ClientRectangle.Right - intPenWidth * 2, -1, intPenWidth * 2, intPenWidth * 2), 270f, 90f);
                    path.AddLine(new Point(base.Width, base.Height), new Point(intPenWidth, base.Height));
                    path.AddArc(new Rectangle(0, intPenWidth * -1, intPenWidth * 2, intPenWidth * 2), 90f, 90f);
                    path.CloseAllFigures();
                    linePath.AddArc(new Rectangle(intPenWidth / 2 + 1, -1 * intPenWidth / 2 - 1, intPenWidth, intPenWidth), 181f, -91f);
                    linePath.AddLine(intPenWidth, base.Height / 2, base.Width - intPenWidth - 1, base.Height / 2);
                    linePath.AddArc(new Rectangle(base.ClientRectangle.Right - intPenWidth - intPenWidth / 2 - 1, intPenWidth / 2, intPenWidth, intPenWidth), 269f, 91f);
                    break;
                case PipeStyle.Horizontal_Up_Up:
                    path.AddLine(new Point(0, 0), new Point(base.Width, 0));
                    path.AddArc(new Rectangle(base.ClientRectangle.Right - intPenWidth * 2, intPenWidth * -1, intPenWidth * 2, intPenWidth * 2), 0f, 90f);
                    path.AddLine(new Point(base.Width - intPenWidth, base.Height), new Point(intPenWidth, base.Height));
                    path.AddArc(new Rectangle(0, intPenWidth * -1, intPenWidth * 2, intPenWidth * 2), 90f, 90f);
                    path.CloseAllFigures();
                    linePath.AddArc(new Rectangle(intPenWidth / 2 + 1, -1 * intPenWidth / 2 - 1, intPenWidth, intPenWidth), 181f, -91f);
                    linePath.AddArc(new Rectangle(base.ClientRectangle.Right - intPenWidth - intPenWidth / 2 - 1, -1 * intPenWidth / 2 - 1, intPenWidth, intPenWidth), 91f, -91f);
                    break;
                case PipeStyle.Horizontal_Down_Down:
                    path.AddLine(new Point(intPenWidth, 0), new Point(base.Width - intPenWidth, 0));
                    path.AddArc(new Rectangle(base.ClientRectangle.Right - intPenWidth * 2, -1, intPenWidth * 2, intPenWidth * 2), 270f, 90f);
                    path.AddLine(new Point(base.Width, base.Height), new Point(0, base.Height));
                    path.AddArc(new Rectangle(0, -1, intPenWidth * 2, intPenWidth * 2), 180f, 90f);
                    path.CloseAllFigures();
                    linePath.AddArc(new Rectangle(intPenWidth / 2 + 1, base.Height / 2, intPenWidth, intPenWidth), 179f, 91f);
                    linePath.AddLine(intPenWidth + 1, base.Height / 2, base.Width - intPenWidth - 1, base.Height / 2);
                    linePath.AddArc(new Rectangle(base.ClientRectangle.Right - intPenWidth - intPenWidth / 2 - 1, intPenWidth / 2, intPenWidth, intPenWidth), 269f, 91f);
                    break;
                case PipeStyle.Vertical_None_None:
                    path.AddLines(new PointF[4]
                    {
                new PointF(0f, 0f),
                new PointF(base.ClientRectangle.Right, 0f),
                new PointF(base.ClientRectangle.Right, base.Height),
                new PointF(0f, base.Height)
                    });
                    path.CloseAllFigures();
                    linePath.AddLine(base.Width / 2, 0, base.Width / 2, base.Height);
                    break;
                case PipeStyle.Vertical_Left_None:
                    path.AddLines(new PointF[4]
                    {
                new PointF(base.ClientRectangle.Right, intPenWidth),
                new PointF(base.ClientRectangle.Right, base.Height),
                new PointF(0f, base.Height),
                new PointF(0f, 0f)
                    });
                    path.AddArc(new Rectangle(-1 * intPenWidth, 0, intPenWidth * 2, intPenWidth * 2), 270f, 90f);
                    path.CloseAllFigures();
                    linePath.AddArc(new Rectangle(-1 * intPenWidth / 2 - 1, intPenWidth / 2 + 1, intPenWidth, intPenWidth), 269f, 91f);
                    linePath.AddLine(intPenWidth / 2, intPenWidth, intPenWidth / 2, base.Height);
                    break;
                case PipeStyle.Vertical_Right_None:
                    path.AddLines(new PointF[4]
                    {
                new PointF(base.ClientRectangle.Right, 0f),
                new PointF(base.ClientRectangle.Right, base.Height),
                new PointF(0f, base.Height),
                new PointF(0f, intPenWidth)
                    });
                    path.AddArc(new Rectangle(-1, 0, intPenWidth * 2, intPenWidth * 2), 180f, 90f);
                    path.CloseAllFigures();
                    linePath.AddArc(new Rectangle(intPenWidth / 2, intPenWidth / 2 + 1, intPenWidth, intPenWidth), 271f, -91f);
                    linePath.AddLine(intPenWidth / 2, intPenWidth + 1, intPenWidth / 2, base.Height);
                    break;
                case PipeStyle.Vertical_None_Left:
                    path.AddLines(new PointF[4]
                    {
                new PointF(0f, base.Height),
                new PointF(0f, 0f),
                new PointF(base.ClientRectangle.Right, 0f),
                new PointF(base.ClientRectangle.Right, base.Height - intPenWidth)
                    });
                    path.AddArc(new Rectangle(-1 * intPenWidth, base.Height - intPenWidth * 2, intPenWidth * 2, intPenWidth * 2), 0f, 90f);
                    path.CloseAllFigures();
                    linePath.AddLine(base.Width / 2, 0, base.Width / 2, base.Height - intPenWidth);
                    linePath.AddArc(new Rectangle(-1 * intPenWidth / 2 - 1, base.Height - intPenWidth - intPenWidth / 2 - 1, intPenWidth, intPenWidth), -1f, 91f);
                    break;
                case PipeStyle.Vertical_None_Right:
                    path.AddLines(new PointF[4]
                    {
                new PointF(0f, base.Height - intPenWidth),
                new PointF(0f, 0f),
                new PointF(base.ClientRectangle.Right, 0f),
                new PointF(base.ClientRectangle.Right, base.Height)
                    });
                    path.AddArc(new Rectangle(-1, base.Height - intPenWidth * 2, intPenWidth * 2, intPenWidth * 2), 90f, 90f);
                    path.CloseAllFigures();
                    linePath.AddLine(base.Width / 2, 0, base.Width / 2, base.Height - intPenWidth - 1);
                    linePath.AddArc(new Rectangle(intPenWidth / 2, base.Height - intPenWidth - intPenWidth / 2 - 1, intPenWidth, intPenWidth), 181f, -91f);
                    break;
                case PipeStyle.Vertical_Left_Right:
                    path.AddLine(base.Width, intPenWidth, base.Width, base.Height);
                    path.AddArc(new Rectangle(-1, base.Height - intPenWidth * 2, intPenWidth * 2, intPenWidth * 2), 90f, 90f);
                    path.AddLine(0, base.Height - intPenWidth, 0, 0);
                    path.AddArc(new Rectangle(-1 * intPenWidth, 0, intPenWidth * 2, intPenWidth * 2), 270f, 90f);
                    path.CloseAllFigures();
                    linePath.AddArc(new Rectangle(-1 * intPenWidth / 2 - 1, intPenWidth / 2 + 1, intPenWidth, intPenWidth), 269f, 91f);
                    linePath.AddArc(new Rectangle(intPenWidth / 2, base.Height - intPenWidth - intPenWidth / 2 - 1, intPenWidth, intPenWidth), 181f, -91f);
                    break;
                case PipeStyle.Vertical_Right_Left:
                    path.AddLine(base.Width, 0, base.Width, base.Height - intPenWidth);
                    path.AddArc(new Rectangle(-1 * intPenWidth, base.Height - intPenWidth * 2, intPenWidth * 2, intPenWidth * 2), 0f, 90f);
                    path.AddLine(0, base.Height, 0, intPenWidth);
                    path.AddArc(new Rectangle(-1, 0, intPenWidth * 2, intPenWidth * 2), 180f, 90f);
                    path.CloseAllFigures();
                    linePath.AddArc(new Rectangle(intPenWidth / 2, intPenWidth / 2 + 1, intPenWidth, intPenWidth), 271f, -91f);
                    linePath.AddArc(new Rectangle(-1 * intPenWidth / 2 - 1, base.Height - intPenWidth - intPenWidth / 2 - 1, intPenWidth, intPenWidth), -1f, 91f);
                    break;
                case PipeStyle.Vertical_Left_Left:
                    path.AddLine(base.Width, intPenWidth, base.Width, base.Height - intPenWidth);
                    path.AddArc(new Rectangle(-1 * intPenWidth, base.Height - intPenWidth * 2, intPenWidth * 2, intPenWidth * 2), 0f, 90f);
                    path.AddLine(0, base.Height, 0, 0);
                    path.AddArc(new Rectangle(-1 * intPenWidth, 0, intPenWidth * 2, intPenWidth * 2), 270f, 90f);
                    path.CloseAllFigures();
                    linePath.AddArc(new Rectangle(-1 * intPenWidth / 2 - 1, intPenWidth / 2 + 1, intPenWidth, intPenWidth), 269f, 91f);
                    linePath.AddArc(new Rectangle(-1 * intPenWidth / 2 - 1, base.Height - intPenWidth - intPenWidth / 2 - 1, intPenWidth, intPenWidth), -1f, 91f);
                    break;
                case PipeStyle.Vertical_Right_Right:
                    path.AddLine(base.Width, 0, base.Width, base.Height);
                    path.AddArc(new Rectangle(-1, base.Height - intPenWidth * 2, intPenWidth * 2, intPenWidth * 2), 90f, 90f);
                    path.AddLine(0, base.Height - intPenWidth, 0, intPenWidth);
                    path.AddArc(new Rectangle(-1, 0, intPenWidth * 2, intPenWidth * 2), 180f, 90f);
                    path.CloseAllFigures();
                    linePath.AddArc(new Rectangle(intPenWidth / 2, intPenWidth / 2 + 1, intPenWidth, intPenWidth), 271f, -91f);
                    linePath.AddArc(new Rectangle(intPenWidth / 2, base.Height - intPenWidth - intPenWidth / 2 - 1, intPenWidth, intPenWidth), 180f, -91f);
                    break;
            }
            // 填充管道颜色
            g.FillPath(new SolidBrush(pipeColor), path);
            // 渐变色
            int intCount = intPenWidth / 2 / 4;
            int intSplit = (255 - 100) / intCount;
            for (int i = 0; i < intCount; i++)
            {
                int _penWidth = intPenWidth / 2 - 4 * i;
                if (_penWidth <= 0)
                    _penWidth = 1;
                // 画流动线外围的渐变色（浅白部分）
                g.DrawPath(new Pen(new SolidBrush(Color.FromArgb(40, Color.White.R, Color.White.G, Color.White.B)), _penWidth), linePath);
                if (_penWidth == 1)
                    break;
            }
            // 液体的流动
            if (flowDirection != FlowDirection.None)
            {
                Pen p = new Pen(new SolidBrush(flowColor), flowWidth);
                // 虚线的样式
                p.DashPattern = new float[] { flowLength, flowSpace };
                p.DashOffset = intLineLeft * (FlowDirection == FlowDirection.Forward ? -1 : 1);
                g.DrawPath(p, linePath);
            }


        }


    }
    /// <summary>
    /// 流动方向
    /// </summary>
    public enum FlowDirection
    {
        None,
        Forward,
        Backward
    }
    /// <summary>
    /// 管道样式
    /// </summary>
    public enum PipeStyle
    {
        /// <summary>
        /// 直线 
        /// </summary>
        Horizontal_None_None,
        /// <summary>
        /// 左上
        /// </summary>
        Horizontal_Up_None,
        /// <summary>
        /// 左下
        /// </summary>
        Horizontal_Down_None,
        /// <summary>
        /// 右上
        /// </summary>
        Horizontal_None_Up,
        /// <summary>
        /// 右下
        /// </summary>
        Horizontal_None_Down,
        /// <summary>
        /// 左下右上
        /// </summary>
        Horizontal_Down_Up,
        /// <summary>
        /// 左上右下
        /// </summary>
        Horizontal_Up_Down,
        /// <summary>
        /// 左上，右上
        /// </summary>
        Horizontal_Up_Up,
        /// <summary>
        /// 左下右下
        /// </summary>
        Horizontal_Down_Down,

        /// <summary>
        /// 竖线
        /// </summary>
        Vertical_None_None,
        /// <summary>
        /// 上左
        /// </summary>
        Vertical_Left_None,
        /// <summary>
        /// 上右
        /// </summary>
        Vertical_Right_None,
        /// <summary>
        /// 下左
        /// </summary>
        Vertical_None_Left,
        /// <summary>
        /// 下右
        /// </summary>
        Vertical_None_Right,
        /// <summary>
        /// 上左下右
        /// </summary>
        Vertical_Left_Right,
        /// <summary>
        /// 上右下左
        /// </summary>
        Vertical_Right_Left,
        /// <summary>
        /// 上左下左
        /// </summary>
        Vertical_Left_Left,
        /// <summary>
        /// 上右下右
        /// </summary>
        Vertical_Right_Right,
    }
}
