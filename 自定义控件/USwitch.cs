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
    [DefaultEvent("CheckedChanged")] // 双击默认事件
    public partial class USwitch : UserControl
    {
        public USwitch()
        {
            InitializeComponent();
            SetStyle(ControlStyles.AllPaintingInWmPaint, true); // 忽略窗口消息 减少闪烁
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true); // 双缓冲 '事先绘制到缓冲存而不是屏幕' 减少闪烁
            SetStyle(ControlStyles.UserPaint, true); // 控件由其自身绘制而不是操作系统绘制
            SetStyle(ControlStyles.ResizeRedraw, true); // 控件调整其大小时重绘
            SetStyle(ControlStyles.SupportsTransparentBackColor, true); // 支持透明背景
            SetStyle(ControlStyles.Selectable, true); // 可以接受焦点
            MouseDown += USwitch_MouseDown;
        }
        /// <summary>
        /// 引发CheckedChanged事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void USwitch_MouseDown(object sender, MouseEventArgs e)
        {
            CheckedChanged?.Invoke(this, EventArgs.Empty);
        }

        private Color trueColor = Color.DarkTurquoise;
        [Description("开关状态值改变时触发")]
        public event EventHandler CheckedChanged;
        [DefaultValue(typeof(Color), "DarkTurquoise"), Description("状态为Checked 或 True时的颜色")]
        public Color TrueColor
        {
            get { return trueColor; }
            set { trueColor = value; }
        }
        private Color falseColor = Color.Gray;
        [DefaultValue(typeof(Color), "Gray"), Description("状态为!Checked 或 False时的颜色")]
        public Color FalseColor
        {
            get { return falseColor; }
            set
            {
                falseColor = value;
                Invalidate();
            }
        }
        private bool mchecked = false;
        [DefaultValue(typeof(Color), "false"), Description("开关状态值")]
        public bool Checked
        {
            get { return mchecked; }
            set
            {
                mchecked = value;
                Invalidate();
            }
        }
        private string[] texts = { };
        [Description("开关两种状态的文本，必须时长度为2的字符串数组")]
        public string[] Texts
        {
            get { return texts; }
            set
            {
                texts = value;
                Invalidate();
            }
        }
        private SwitchType switchType = SwitchType.Ellipse;
        [DefaultValue(typeof(SwitchType), "Ellipse"), Description("开关样式")]
        public SwitchType SwitchType
        {
            get { return switchType; }
            set
            {
                switchType = value;
                Invalidate();
            }
        }
        public override Font Font
        {
            get => base.Font;
            set
            {
                base.Font = value;
                Invalidate();
            }
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            // 开关按钮的背景填充色
            var fillColor = mchecked ? trueColor : falseColor;
            // 外观形状的路径path
            GraphicsPath path = new GraphicsPath();
            if (switchType == SwitchType.Ellipse)
            {
                // 上边直线
                path.AddLine(Height / 2, 1, Width - Height / 2, 1);
                // 右边半圆弧
                path.AddArc(Width - Height - 1, 1, Height - 2, Height - 2, -90f, 180f);
                // 下边直线 右 --> 左
                path.AddLine(Width - Height / 2, Height - 1, Height / 2, Height);
                // 坐边半圆弧
                path.AddArc(1, 1, Height - 2, Height - 2, 90f, 180f);
                g.FillPath(new SolidBrush(fillColor), path);
                // 开关要绘制的文本开关
                string strText = "";
                if (texts != null && texts.Length == 2)
                {
                    if (mchecked)
                    {
                        strText = texts[0];
                    }
                    else
                    {
                        strText = texts[1];
                    }
                }
                if (mchecked)
                {
                    // 填充 右边正圆 直径 ： Height-2-4
                    g.FillEllipse(new SolidBrush(Color.White), new Rectangle(Width - Height - 1 + 2, 1 + 2, Height - 2 - 4, Height - 2 - 4));
                    if (string.IsNullOrEmpty(strText)) // 没有文本
                    {
                        // 左边就画一个小圆圈，边框为白色的小圆，直径右边圆的一半
                        g.DrawEllipse(
                            new Pen(Color.White, 2),
                            new RectangleF(
                            (Height - 2 - 4) / 2 - ((Height - 2 - 4) / 4),
                            (Height - 2 - (Height - 2 - 4) / 2) / 2 + 1,
                            (Height - 2 - 4) / 2,
                            (Height - 2 - 4) / 2));
                    }
                    else
                    {
                        // 获取文本的尺寸
                        SizeF sizeF = g.MeasureString(strText.Replace(" ", "***"), Font);
                        // 计算文本绘制的位置的矩形的左上角y坐标值
                        int textY = (int)(Height - sizeF.Height) / 2 + 2;
                        // x坐标 1/2 半径处
                        g.DrawString(strText, Font, Brushes.White, new Point((Height - 2 - 4) / 2, textY));
                    }
                }
                else
                {
                    // 填充左边正圆
                    g.FillEllipse(Brushes.White, new RectangleF(1 + 2, 1 + 2, Height - 2 - 4, Height - 2 - 4));
                    if (string.IsNullOrEmpty(strText)) // 没有文本
                    {
                        // 右边就画一个小圆圈，边框为白色的小圆，直径左边圆的一半
                        g.DrawEllipse(
                            new Pen(Color.White, 2),
                            new RectangleF(
                                Width - 2 - (Height - 2 - 4) / 2 - ((Height - 2 - 4) / 2) / 2,
                                (Height - 2 - (Height - 2 - 4) / 2) / 2 + 1,
                                (Height - 2 - 4) / 2,
                                (Height - 2 - 4) / 2));
                    }
                    else
                    {
                        // 获取文本的尺寸
                        SizeF sizeF = g.MeasureString(strText.Replace(" ", "***"), Font);
                        // 计算文本绘制的位置的矩形的左上角y坐标值
                        int textY = (int)(Height - sizeF.Height) / 2 + 2;
                        // x坐标 1/2 半径处
                        g.DrawString(strText, Font, Brushes.White, new Point((Width - 2 - Height / 2 - (int)sizeF.Width + 4), textY));
                    }
                }
            }
            else if (switchType == SwitchType.Quadriateral)//四边形
            {
                //圆角正方形边长
                int intRadius = 5;
                //左上角圆弧 
                path.AddArc(0, 0, intRadius, intRadius, 180f, 90f);
                //右上角圆弧 
                path.AddArc(Width - intRadius - 1, 0, intRadius, intRadius, 270f, 90f);
                //右下角圆弧
                path.AddArc(Width - intRadius - 1, Height - intRadius - 1, intRadius, intRadius, 0f, 90f);
                //左下角圆弧
                path.AddArc(0, Height - intRadius - 1, intRadius, intRadius, 90f, 90f);
                //填充圆角矩形
                g.FillPath(new SolidBrush(fillColor), path);

                //获取文本
                string strText = string.Empty;
                if (texts != null && texts.Length == 2)
                {
                    if (mchecked)
                    {
                        strText = texts[0];
                    }
                    else
                    {
                        strText = texts[1];
                    }
                }

                if (mchecked)
                {
                    //右边正方形圆角
                    GraphicsPath path2 = new GraphicsPath();
                    //左上角圆弧
                    path2.AddArc(Width - Height - 1 + 2, 1 + 2, intRadius, intRadius, 180f, 90f);
                    //右上角圆弧
                    path2.AddArc(Width - 1 - 2 - intRadius, 1 + 2, intRadius, intRadius, 270f, 90f);
                    //右下角圆弧
                    path2.AddArc(Width - 1 - 2 - intRadius, Height - 2 - intRadius - 1, intRadius, intRadius, 0f, 90f);
                    //右下角圆弧 
                    path2.AddArc(Width - Height - 1 + 2, Height - 2 - intRadius - 1, intRadius, intRadius, 90f, 90f);
                    //填充圆角正方形
                    g.FillPath(Brushes.White, path2);

                    if (string.IsNullOrEmpty(strText))
                    {
                        //左边画个小圆
                        //小圆所在矩形左上角坐标 ：x 1/2边长-1/2小圆半径
                        //y: 1/2边长-1/2小圆半径+1
                        //半径：1/2 正方形边长
                        g.DrawEllipse(new Pen(Color.White, 2), new Rectangle((Height - 2 - 4) / 2 - ((Height - 2 - 4) / 2) / 2, (Height - 2 - (Height - 2 - 4) / 2) / 2 + 1, (Height - 2 - 4) / 2, (Height - 2 - 4) / 2));
                    }
                    else
                    {
                        //画文本
                        System.Drawing.SizeF sizeF = g.MeasureString(strText.Replace(" ", "A"), Font);
                        //y坐标
                        int intTextY = (Height - (int)sizeF.Height) / 2 + 2;
                        //x:1/2边长处
                        g.DrawString(strText, Font, Brushes.White, new Point((Height - 2 - 4) / 2, intTextY));
                    }
                }
                else//画关的外观
                {
                    //圆角正方形路径  左边
                    GraphicsPath path2 = new GraphicsPath();
                    path2.AddArc(1 + 2, 1 + 2, intRadius, intRadius, 180f, 90f);
                    path2.AddArc(Height - 2 - intRadius, 1 + 2, intRadius, intRadius, 270f, 90f);
                    path2.AddArc(Height - 2 - intRadius, Height - 2 - intRadius - 1, intRadius, intRadius, 0f, 90f);
                    path2.AddArc(1 + 2, Height - 2 - intRadius - 1, intRadius, intRadius, 90f, 90f);
                    //填充圆角正方形
                    g.FillPath(Brushes.White, path2);
                    if (string.IsNullOrEmpty(strText))
                    {
                        //无文本，画右边小圆
                        //小圆所在矩形左上角坐标 ：x  宽度-2-1/2边长-1/2小圆半径
                        //y: 1/2边长-1/2小圆半径+1
                        //半径：1/2 正方形边长
                        g.DrawEllipse(new Pen(Color.White, 2), new Rectangle(Width - 2 - (Height - 2 - 4) / 2 - ((Height - 2 - 4) / 2) / 2, (Height - 2 - (Height - 2 - 4) / 2) / 2 + 1, (Height - 2 - 4) / 2, (Height - 2 - 4) / 2));
                    }
                    else
                    {
                        //画文本
                        System.Drawing.SizeF sizeF = g.MeasureString(strText.Replace(" ", "A"), Font);
                        //y坐标
                        int intTextY = (Height - (int)sizeF.Height) / 2 + 2;
                        //x坐标  宽-2-1/2正方形边长-文字宽度+4
                        g.DrawString(strText, Font, Brushes.White, new Point(Width - 2 - (Height - 2 - 4) / 2 - (int)sizeF.Width + 4, intTextY));
                    }
                }
            }
            else //线型
            {
                //线高
                int intLineHeight = (Height - 2 - 4) / 2;

                // 上边直线    点 ：高度,(高度-线高)/2    点：宽-高/2, (高度-线高)/2 
                path.AddLine(new Point(Height / 2, (Height - intLineHeight) / 2), new Point(Width - Height / 2, (Height - intLineHeight) / 2));
                //右边半圆弧  半径是 1/2线高
                path.AddArc(new Rectangle(Width - Height / 2 - intLineHeight - 1, (Height - intLineHeight) / 2, intLineHeight, intLineHeight), -90, 180);
                //下边直线 
                path.AddLine(new Point(Width - Height / 2, (Height - intLineHeight) / 2 + intLineHeight), new Point(Width - Height / 2, (Height - intLineHeight) / 2 + intLineHeight));
                //左边半圆弧
                path.AddArc(new Rectangle(Height / 2, (Height - intLineHeight) / 2, intLineHeight, intLineHeight), 90, 180);
                //填充线
                g.FillPath(new SolidBrush(fillColor), path);

                if (mchecked)//绘制开时的外观
                {
                    //填充右边外圆
                    g.FillEllipse(new SolidBrush(fillColor), new Rectangle(Width - Height - 1 + 2, 1 + 2, Height - 2 - 4, Height - 2 - 4));
                    //填充右边内圆 
                    //x坐标：宽-2-1/2外圆半径-1/2内圆半径-4   y坐标：高-2-1/2内圆半径+1
                    //内圆直径：(Height - 2 - 4) / 2  (高-2-4)/2
                    g.FillEllipse(Brushes.White, new Rectangle(Width - 2 - (Height - 2 - 4) / 2 - ((Height - 2 - 4) / 2) / 2 - 4, (Height - 2 - (Height - 2 - 4) / 2) / 2 + 1, (Height - 2 - 4) / 2, (Height - 2 - 4) / 2));
                }
                else //关时的外观
                {
                    //填充左边外圆
                    g.FillEllipse(new SolidBrush(fillColor), new Rectangle(1 + 2, 1 + 2, Height - 2 - 4, Height - 2 - 4));
                    //填充左贺内圆
                    //x坐标：1/2外圆半径-1/2内圆半径+4   y坐标：1/2外圆半径-1/2内圆半径+1
                    //内圆直径：(Height - 2 - 4) / 2  (高-2-4)/2
                    g.FillEllipse(Brushes.White, new Rectangle((Height - 2 - 4) / 2 - ((Height - 2 - 4) / 2) / 2 + 4, (Height - 2 - (Height - 2 - 4) / 2) / 2 + 1, (Height - 2 - 4) / 2, (Height - 2 - 4) / 2));
                }
            }

        }

    }
    /// <summary>
    /// 开关样式
    /// </summary>
    public enum SwitchType
    {
        Ellipse, // 圆形
        Quadriateral, // 四边形
        Line // 线性
    }
}
