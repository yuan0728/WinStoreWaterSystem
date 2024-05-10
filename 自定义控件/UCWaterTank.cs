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
    public partial class UCWaterTank : UserControl
    {
        public UCWaterTank()
        {
            InitializeComponent();
            SetStyle(ControlStyles.AllPaintingInWmPaint, true); // 忽略窗口消息 减少闪烁
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true); // 双缓冲 '事先绘制到缓冲存而不是屏幕' 减少闪烁
            SetStyle(ControlStyles.UserPaint, true); // 控件由其自身绘制而不是操作系统绘制
            SetStyle(ControlStyles.ResizeRedraw, true); // 控件调整其大小时重绘
            SetStyle(ControlStyles.SupportsTransparentBackColor, true); // 支持透明背景
            rectWidth = 2;
            this.Size = new Size(100, 200);
        }
        float fRatio = 0.0f;// 比例值
        float fHeight = 0.0f;// 实际水位高度值
        private RectangleF valueRect;// 
        private int mValue = 0;
        [DefaultValue(typeof(int), "0"), Description("当前水位值")]
        public int Value
        {
            get { return mValue; }
            set
            {
                if (value > maxVlaue)
                    mValue = maxVlaue;
                else if (value < 0)
                    mValue = 0;
                else
                    mValue = value;
                UpdateHeight();// 更新比例数 实际矩形区域
                Invalidate();
            }
        }

        private int maxVlaue = 100;
        [DefaultValue(typeof(int), "100"), Description("最大水位值")]
        public int MaxVlaue
        {
            get { return maxVlaue; }
            set
            {
                if (value < mValue)
                    maxVlaue = mValue;
                else
                    maxVlaue = value;
                UpdateHeight();
                Invalidate();
            }
        }
        private Color valColor = Color.Blue;
        [DefaultValue(typeof(Color), "Blue"), Description("水位深度颜色")]
        public Color ValColor
        {
            get { return valColor; }
            set
            {
                valColor = value;
                Invalidate();
            }
        }
        private Color borderColor = Color.Gray;
        [DefaultValue(typeof(Color), "Gray"), Description("水池的边框颜色")]
        public Color BorderColor
        {
            get { return borderColor; }
            set
            {
                borderColor = value;
                Invalidate();
            }
        }
        private int rectWidth = 1;
        [DefaultValue(typeof(int), "1"), Description("水池的边框粗细")]
        public int RectWidth
        {
            get { return rectWidth; }
            set
            {
                rectWidth = value;
                UpdateHeight();// 更新比例数 实际矩形区域
                Invalidate();
            }
        }
        /// <summary>
        /// 更新内部矩形的实际高度
        /// </summary>
        private void UpdateHeight()
        {
            UpdateRatio();
            // 水位高度
            fHeight = (float)Value * fRatio;
            // 水位的矩形
            valueRect = new RectangleF(rectWidth, Height - fHeight - rectWidth, Width - 2 * rectWidth - 1, fHeight);
        }
        /// <summary>
        /// 计算水池高度水池的比例值
        /// </summary>
        private void UpdateRatio()
        {
            fRatio = (float)(Height - 2 * rectWidth) / (float)maxVlaue;
        }
        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            UpdateHeight();
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            // 画边框
            Pen pen = new Pen(new SolidBrush(borderColor), rectWidth);
            Rectangle rect = new Rectangle(0, 0, Width - 1, Height - 1);
            // 外边框 圆角矩形
            GraphicsPath rectPath = PaintClass.GetRoundRectangle(rect, 5);
            // 填充水位
            g.FillRectangle(new SolidBrush(ValColor), valueRect);
            // 画边框
            g.DrawPath(pen, rectPath);
        }
    }
}
