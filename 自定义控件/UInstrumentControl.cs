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
    public partial class UInstrumentControl : UserControl
    {
        public UInstrumentControl()
        {
            InitializeComponent();
            SetStyle(ControlStyles.AllPaintingInWmPaint, true); // 忽略窗口消息 减少闪烁
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true); // 双缓冲 '事先绘制到缓冲存而不是屏幕' 减少闪烁
            SetStyle(ControlStyles.UserPaint, true); // 控件由其自身绘制而不是操作系统绘制
            SetStyle(ControlStyles.ResizeRedraw, true); // 控件调整其大小时重绘
            SetStyle(ControlStyles.SupportsTransparentBackColor, true); // 支持透明背景
            SetStyle(ControlStyles.Selectable, false); // 控件不可以接受焦点
            this.SizeChanged += UInstrumentControl_SizeChanged;
            this.Size = new Size(300, 300);
        }
        Rectangle m_rectWorking; // 绘制工作区


        private void UInstrumentControl_SizeChanged(object sender, EventArgs e)
        {
            m_rectWorking = new Rectangle(10, 10, Width - 20, Height - 20);
        }
        private int splitCount = 10;
        [DefaultValue(typeof(int), "10"), Description("分隔刻度数量，数量必须>1"), Category("自定义")]
        public int SplitCount
        {
            get { return splitCount; }
            set
            {
                if (value < 1) return;
                splitCount = value;
                Invalidate();
            }
        }

        private int meterDegrees = 180;
        [DefaultValue(typeof(int), "180"), Description("表盘内跨度角度，0-360"), Category("自定义")]
        public int MeterDegrees
        {
            get { return meterDegrees; }
            set
            {
                if (value < 0 || value > 360) return;
                meterDegrees = value;
                Invalidate();
            }
        }
        private Decimal minValue = 0;
        [DefaultValue(typeof(decimal), "0"), Description("最小值，必须比最大值小"), Category("自定义")]
        public Decimal MinValue
        {
            get { return minValue; }
            set
            {
                if (value >= maxValue) return;
                minValue = value;
                Invalidate();
            }
        }
        private Decimal maxValue = 100;
        [DefaultValue(typeof(decimal), "100"), Description("最大值，必须比最小值大"), Category("自定义")]
        public Decimal MaxValue
        {
            get { return maxValue; }
            set
            {
                if (value <= minValue) return;
                maxValue = value;
                Invalidate();
            }
        }
        [Description("刻度值文本字体"),Category("自定义")]
        public override Font Font
        {
            get => base.Font;
            set
            {
                base.Font = value;
                Invalidate();
            }
        }
        private Decimal m_value = 100;
        [DefaultValue(typeof(decimal), "0"), Description("仪表实际值，在是最大值和最小值之间"), Category("自定义")]
        public Decimal Value
        {
            get { return m_value; }
            set
            {
                if (value < minValue || value > maxValue) return;
                m_value = value;
                Invalidate();
            }
        }
        private TextLocation textLocation = TextLocation.None;
        [DefaultValue(typeof(TextLocation), "None"), Description("值和固定文本是否显示"), Category("自定义")]
        public TextLocation TextLocation
        {
            get { return textLocation; }
            set
            {
                textLocation = value;
                Invalidate();
            }
        }
        private string fixedText = "";
        [DefaultValue(typeof(string), ""), Description("固定文字"), Category("自定义")]
        public string FixedText
        {
            get { return fixedText; }
            set
            {
                fixedText = value;
                Invalidate();
            }
        }
        private Font textFont = DefaultFont;
        [DefaultValue(typeof(Font), "DefaultFont"), Description("值和固体文字字体"), Category("自定义")]
        public Font TextFont
        {
            get { return textFont; }
            set
            {
                textFont = value;
                Invalidate();
            }
        }
        private Color externalRoundColor = Color.Red;
        [DefaultValue(typeof(Color), "Red"), Description("外圆颜色"), Category("自定义")]
        public Color ExternalRoundColor
        {
            get { return externalRoundColor; }
            set
            {
                externalRoundColor = value;
                Invalidate();
            }
        }
        private Color insideRoundColor = Color.Gray;
        [DefaultValue(typeof(Color), "Gray"), Description("内圆颜色"), Category("自定义")]
        public Color InsideRoundColor
        {
            get { return insideRoundColor; }
            set
            {
                insideRoundColor = value;
                Invalidate();
            }
        }
        private Color boundaryLineColor = Color.Red;
        [DefaultValue(typeof(Color), "Red"), Description("边界线颜色"), Category("自定义")]
        public Color BoundaryLineColor
        {
            get { return boundaryLineColor; }
            set
            {
                boundaryLineColor = value;
                Invalidate();
            }
        }
        private Color scaleColor = Color.Gray;
        [DefaultValue(typeof(Color), "Gray"), Description("刻度线颜色"), Category("自定义")]
        public Color ScaleColor
        {
            get { return scaleColor; }
            set
            {
                scaleColor = value;
                Invalidate();
            }
        }
        private Color textColor = Color.Red;
        [DefaultValue(typeof(Color), "Red"), Description("值和固定文字颜色"), Category("自定义")]
        public Color TextColor
        {
            get { return textColor; }
            set
            {
                textColor = value;
                Invalidate();
            }
        }
        private Color scaleValueColor = Color.Red;
        [DefaultValue(typeof(Color), "Red"), Description("刻度值的文本颜色"), Category("自定义")]
        public Color ScaleValueColor
        {
            get { return scaleValueColor; }
            set
            {
                scaleValueColor = value;
                Invalidate();
            }
        }
        private Color pointerColor = Color.Red;
        [DefaultValue(typeof(Color), "Red"), Description("指针颜色"), Category("自定义")]
        public Color PointerColor
        {
            get { return pointerColor; }
            set
            {
                pointerColor = value;
                Invalidate();
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.HighQuality;
            //外圆 -90-75+360=195
            float fltStartAngle = -90 - (meterDegrees) / 2 + 360;//开始角度
                                                                 //绘制外圆弧的矩形区域
            var r1 = new Rectangle(m_rectWorking.Location, new Size(m_rectWorking.Width, m_rectWorking.Width));
            //画外圆弧
            g.DrawArc(new Pen(new SolidBrush(externalRoundColor), 3), r1, fltStartAngle, meterDegrees);

            //内圆矩形区域
            var r2 = new Rectangle(m_rectWorking.Left + (m_rectWorking.Width - m_rectWorking.Width / 4) / 2, m_rectWorking.Top + (m_rectWorking.Width - m_rectWorking.Width / 4) / 2, m_rectWorking.Width / 4, m_rectWorking.Width / 4);
            //画内圆弧
            g.DrawArc(new Pen(new SolidBrush(insideRoundColor), 2), r2, fltStartAngle, meterDegrees);
            //边界线
            if (meterDegrees != 360)
            {
                float fltAngle = fltStartAngle - 180;
                //左上的点坐标
                float intY = (float)(m_rectWorking.Top + m_rectWorking.Width / 2 - ((m_rectWorking.Width / 2 - m_rectWorking.Width / 8) * Math.Sin(Math.PI * (fltAngle / 180.00F))));
                float intX = (float)(m_rectWorking.Left + (m_rectWorking.Width / 2 - ((m_rectWorking.Width / 2 - m_rectWorking.Width / 8) * Math.Cos(Math.PI * (fltAngle / 180.00F)))));
                //左下的点坐标
                float fltY1 = (float)(m_rectWorking.Top + m_rectWorking.Width / 2 - (m_rectWorking.Width / 8 * Math.Sin(Math.PI * (fltAngle / 180.00F))));
                float fltX1 = (float)(m_rectWorking.Left + (m_rectWorking.Width / 2 - (m_rectWorking.Width / 8 * Math.Cos(Math.PI * (fltAngle / 180.00F)))));
                //画左边界线
                g.DrawLine(new Pen(new SolidBrush(boundaryLineColor), 2), new PointF(intX, intY), new PointF(fltX1, fltY1));
                //右边两点的x坐标
                float fltx2 = m_rectWorking.Right - (fltX1 - m_rectWorking.Left);
                float intX2 = m_rectWorking.Right - (intX - m_rectWorking.Left);
                //画右边界线
                g.DrawLine(new Pen(new SolidBrush(boundaryLineColor), 2), new PointF(fltx2, fltY1), new PointF(intX2, intY));
            }
            //分割份数
            int _splitCount = splitCount * 2;
            //每份的角度
            float fltSplitValue = (float)meterDegrees / (float)_splitCount;
            for (int i = 0; i <= _splitCount; i++)
            {
                //刻度的起始角度 
                float fltAngle = (fltStartAngle + fltSplitValue * i - 180) % 360;
                //刻度线的起点坐标
                float fltY1 = (float)(m_rectWorking.Top + m_rectWorking.Width / 2 - ((m_rectWorking.Width / 2) * Math.Sin(Math.PI * (fltAngle / 180.00F))));
                float fltX1 = (float)(m_rectWorking.Left + (m_rectWorking.Width / 2 - ((m_rectWorking.Width / 2) * Math.Cos(Math.PI * (fltAngle / 180.00F)))));
                //结束点坐标
                float fltY2 = 0;
                float fltX2 = 0;
                if (i % 2 == 0)//长刻度
                {
                    fltY2 = (float)(m_rectWorking.Top + m_rectWorking.Width / 2 - ((m_rectWorking.Width / 2 - 10) * Math.Sin(Math.PI * (fltAngle / 180.00F))));
                    fltX2 = (float)(m_rectWorking.Left + (m_rectWorking.Width / 2 - ((m_rectWorking.Width / 2 - 10) * Math.Cos(Math.PI * (fltAngle / 180.00F)))));
                    if (!(meterDegrees == 360 && i == _splitCount))
                    {
                        //长刻度线的文本
                        decimal decValue = minValue + (maxValue - minValue) / _splitCount * i;
                        var txtSize = g.MeasureString(decValue.ToString("0.##"), this.Font);
                        //刻度值文本左上角坐标
                        float fltFY1 = (float)(m_rectWorking.Top - txtSize.Height / 2 + m_rectWorking.Width / 2 - ((m_rectWorking.Width / 2 - 20) * Math.Sin(Math.PI * (fltAngle / 180.00F))));
                        float fltFX1 = (float)(m_rectWorking.Left - txtSize.Width / 2 + (m_rectWorking.Width / 2 - ((m_rectWorking.Width / 2 - 20) * Math.Cos(Math.PI * (fltAngle / 180.00F)))));
                        //画刻度文本
                        g.DrawString(decValue.ToString("0.##"), Font, new SolidBrush(scaleValueColor), fltFX1, fltFY1);
                    }
                }
                else//短刻度
                {
                    fltY2 = (float)(m_rectWorking.Top + m_rectWorking.Width / 2 - ((m_rectWorking.Width / 2 - 5) * Math.Sin(Math.PI * (fltAngle / 180.00F))));
                    fltX2 = (float)(m_rectWorking.Left + (m_rectWorking.Width / 2 - ((m_rectWorking.Width / 2 - 5) * Math.Cos(Math.PI * (fltAngle / 180.00F)))));
                }
                //画刻度线
                g.DrawLine(new Pen(new SolidBrush(scaleColor), i % 2 == 0 ? 2 : 1), new PointF(fltX1, fltY1), new PointF(fltX2, fltY2));
            }
            //值文字和固定文字
            if (textLocation == TextLocation.Top)
            {
                //值文本格式化
                string str = m_value.ToString("0.##");
                var txtSize = g.MeasureString(str, textFont);
                //值文本的左上角坐标
                float fltY = m_rectWorking.Top + m_rectWorking.Width / 4 - txtSize.Height / 2;
                float fltX = m_rectWorking.Left + m_rectWorking.Width / 2 - txtSize.Width / 2;
                //画当前值
                g.DrawString(str, textFont, new SolidBrush(textColor), new PointF(fltX, fltY));
                //如果固定文本有设置
                if (!string.IsNullOrEmpty(fixedText))
                {
                    //固定文本
                    str = fixedText;
                    txtSize = g.MeasureString(str, textFont);
                    //固定文本的左上角坐标
                    fltY = m_rectWorking.Top + m_rectWorking.Width / 4 + txtSize.Height / 2;
                    fltX = m_rectWorking.Left + m_rectWorking.Width / 2 - txtSize.Width / 2;
                    //画固定文本
                    g.DrawString(str, textFont, new SolidBrush(textColor), new PointF(fltX, fltY));
                }
            }
            //画指针中心外圆  半径10
            g.FillEllipse(new SolidBrush(Color.FromArgb(100, pointerColor.R, pointerColor.G, pointerColor.B)), new Rectangle(m_rectWorking.Left + m_rectWorking.Width / 2 - 10, m_rectWorking.Top + m_rectWorking.Width / 2 - 10, 20, 20));
            //画指针中心内圆 半径5
            g.FillEllipse(Brushes.Red, new Rectangle(m_rectWorking.Left + m_rectWorking.Width / 2 - 5, m_rectWorking.Top + m_rectWorking.Width / 2 - 5, 10, 10));
            //值的角色
            float fltValueAngle = (fltStartAngle + ((float)(m_value - minValue) / (float)(maxValue - minValue)) * (float)meterDegrees - 180) % 360;
            //值对应指向点坐标
            float intValueY1 = (float)(m_rectWorking.Top + m_rectWorking.Width / 2 - ((m_rectWorking.Width / 2 - 30) * Math.Sin(Math.PI * (fltValueAngle / 180.00F))));
            float intValueX1 = (float)(m_rectWorking.Left + (m_rectWorking.Width / 2 - ((m_rectWorking.Width / 2 - 30) * Math.Cos(Math.PI * (fltValueAngle / 180.00F)))));
            //画指针线
            g.DrawLine(new Pen(new SolidBrush(pointerColor), 3), intValueX1, intValueY1, m_rectWorking.Left + m_rectWorking.Width / 2, m_rectWorking.Top + m_rectWorking.Width / 2);
        }

    }
    /// <summary>
    /// 值和固定文本是否显示
    /// </summary>
    public enum TextLocation
    {
        None,
        Top
    }
}
