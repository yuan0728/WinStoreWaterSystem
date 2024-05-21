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
    public partial class UArrowControl : UserControl
    {
        public UArrowControl()
        {
            InitializeComponent();
            SetStyle(ControlStyles.AllPaintingInWmPaint, true); // 忽略窗口消息 减少闪烁
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true); // 双缓冲 '事先绘制到缓冲存而不是屏幕' 减少闪烁
            SetStyle(ControlStyles.UserPaint, true); // 控件由其自身绘制而不是操作系统绘制
            SetStyle(ControlStyles.ResizeRedraw, true); // 控件调整其大小时重绘
            SetStyle(ControlStyles.SupportsTransparentBackColor, true); // 支持透明背景
            SetStyle(ControlStyles.Selectable, false); // 不可以接受焦点
            SizeChanged += UArrowControl_SizeChanged;
            this.Size = new Size(100, 50);
        }

        private Color? borderColor = null;
        [DefaultValue(typeof(Color?), "null"), Description("箭头边框的颜色，可以为null")]
        public Color? BorderColor
        {
            get { return borderColor; }
            set
            {
                borderColor = value;
                Invalidate();
            }
        }
        private Color arrowColor = Color.Red;
        [DefaultValue(typeof(Color), "Red"), Description("箭头的颜色")]
        public Color ArrowColor
        {
            get { return arrowColor; }
            set
            {
                arrowColor = value;
                Invalidate();
            }
        }
        private ArrowDirection direction = ArrowDirection.Left;
        [DefaultValue(typeof(ArrowDirection), "Left"), Description("箭头的方向")]
        public ArrowDirection Direction
        {
            get { return direction; }
            set
            {
                direction = value;
                GetPath();
                Invalidate();
            }
        }


        GraphicsPath path; //箭头路径
        private void UArrowControl_SizeChanged(object sender, EventArgs e)
        {
            GetPath();
        }

        /// <summary>
        /// 生成箭头路径
        /// </summary>
        /// <exception cref="NotImplementedException"></exception>
        private void GetPath()
        {
            Point[] points = null;
            switch (direction)
            {
                case ArrowDirection.Left:
                    points = new Point[]
                    {
                        new Point(0,Height/2),
                        new Point(Width/ 5,0),
                        new Point(Width / 5,Height / 4),
                        new Point(Width,Height / 4),
                        new Point(Width,Height - Height / 4),
                        new Point(Width/ 5,Height - Height / 4),
                        new Point(Width/ 5,Height),
                        new Point(0,Height/2)
                    };
                    break;
                case ArrowDirection.Right:
                    points = new Point[]
                    {
                        new Point(0,Height/4),
                        new Point(Width-Width/5,Height/4),
                        new Point(Width-Width/5,0),
                        new Point(Width-1,Height / 2),
                        new Point(Width-Width/5,Height),
                        new Point(Width-Width/5,Height - Height / 4),
                        new Point(0,Height-Height/4),
                        new Point(0,Height/4)
                    };
                    break;
                case ArrowDirection.Top:
                    points = new Point[]
                    {
                        new Point(Width/2,0),
                        new Point(0,Height/4),
                        new Point(Width /5,Height/4),
                        new Point(Width /5,Height),
                        new Point(Width-Width/5, Height),
                        new Point(Width - Width/5, Height/4),
                        new Point(Width ,Height/4),
                        new Point(Width/2,0),
                    };
                    break;
                case ArrowDirection.Bottom:
                    points = new Point[]
                    {
                        new Point(Width /2,Height),
                        new Point(0,Height - Height / 4),
                        new Point(Width / 5,Height - Height / 4),
                        new Point(Width / 5,0),
                        new Point(Width - Width/5,0),
                        new Point(Width - Width/5,Height-Height/4),
                        new Point(Width ,Height-Height/4),
                        new Point(Width /2,Height),
                    };
                    break;
                case ArrowDirection.Left_Right:
                    points = new Point[]
                    {
                        new Point(0,Height/2),
                        new Point(Width/5,0),
                        new Point(Width/5,Height/4),
                        new Point(Width - Width/5,Height/4),
                        new Point(Width - Width/5,Height),
                        new Point(Width,Height/2),
                        new Point(Width - Width/5,0),
                        new Point(Width - Width/5,Height - Height / 4),
                        new Point(Width/5,Height - Height / 4),
                        new Point(Width/5,Height),
                        new Point(0,Height/2),
                    }; 
                    break;
                case ArrowDirection.Top_Bottom:
                    points = new Point[]
                    {
                        new Point(Width/2,0),
                        new Point(0,Height/4),
                        new Point(Width/5,Height/4),
                        new Point(Width/5,Height-Height/4),
                        new Point(0,Height-Height/4),
                        new Point(Width/2,Height),
                        new Point(Width,Height-Height/4),
                        new Point(Width-Width/5,Height-Height/4),
                        new Point(Width-Width/5,Height/4),
                        new Point(Width,Height/4),
                        new Point(Width/2,0),
                    };
                    break;
            }
            path = new GraphicsPath();
            path.AddLines(points);
            path.CloseFigure();
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.HighQuality;
            g.FillPath(new SolidBrush(arrowColor), path); // 填充箭头路径
            // 绘制边框
            if (borderColor != null && borderColor != Color.Empty)
            {
                g.DrawPath(new Pen(new SolidBrush(borderColor.Value)), path);
            }
        }
    }


    public enum ArrowDirection
    {
        Left,
        Right,
        Top,
        Bottom,
        Left_Right,
        Top_Bottom,
    }
}
