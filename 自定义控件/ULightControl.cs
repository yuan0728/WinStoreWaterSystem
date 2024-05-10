using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace WinStoreWaterSystem
{
    public partial class ULightControl : UserControl
    {
        public ULightControl()
        {
            InitializeComponent();
            SetStyle(ControlStyles.AllPaintingInWmPaint, true); // 忽略窗口消息 减少闪烁
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true); // 双缓冲 '事先绘制到缓冲存而不是屏幕' 减少闪烁
            SetStyle(ControlStyles.UserPaint, true); // 控件由其自身绘制而不是操作系统绘制
            SetStyle(ControlStyles.ResizeRedraw, true); // 控件调整其大小时重绘
            SetStyle(ControlStyles.SupportsTransparentBackColor, true); // 支持透明背景
            SetStyle(ControlStyles.Selectable, true); // 控件可以接受焦点
        }
        public event EventHandler ClickEvent;// 单击指示灯时触发

        private Color surroundColor = Color.Green; // 灯环绕的颜色

        private Color centerColor = Color.White;
        [DefaultValue(typeof(Color), "White"), Description("控件的中心放射颜色")]
        /// <summary>
        /// 中心放射颜色
        /// </summary>
        public Color CenterColor
        {
            get { return centerColor; }
            set
            {
                centerColor = value;
                Invalidate();// 重绘
            }
        }
        private Color borderColor = Color.Gray;
        [DefaultValue(typeof(Color), "Gray"), Description("控件的边框颜色")]
        /// <summary>
        /// 边框颜色
        /// </summary>
        public Color BorderColor
        {
            get { return borderColor; }
            set
            {
                borderColor = value;
                Invalidate();// 重绘
            }
        }
        private Color focusColor = Color.Green;
        [DefaultValue(typeof(Color), "Green"), Description("控件状态为On的时候灯的颜色")]
        /// <summary>
        /// 状态为On的时候灯的颜色
        /// </summary>
        public Color LightfocusColor
        {
            get { return focusColor; }
            set
            {
                focusColor = value;
                Invalidate();// 重绘
            }
        }
        private Color normalColor = Color.Red;
        [DefaultValue(typeof(Color), "Red"), Description("控件常规时时候灯的颜色")]
        /// <summary>
        /// 控件常规时时候灯的颜色
        /// </summary>
        public Color LightNormalColor
        {
            get { return normalColor; }
            set
            {
                normalColor = value;
                surroundColor = value;
                Invalidate();// 重绘
            }
        }
        private string stateText = "运行";
        [DefaultValue(typeof(string), "运行"), Description("控件灯的状态文本描述")]
        /// <summary>
        /// 灯的状态文本描述
        /// </summary>
        public string StateText
        {
            get { return stateText; }
            set
            {
                stateText = value;
                Invalidate();// 重绘
            }
        }

        private string varName;
        [DefaultValue(typeof(string), "varName"), Description("状态参数名称")]
        public string VarName
        {
            get { return varName; }
            set
            {
                varName = value;
            }
        }
        private bool isOn = false;
        [DefaultValue(typeof(bool), "False"), Description("灯的状态")]
        public bool IsOn
        {
            get { return isOn; }
            set
            {
                isOn = value;
                if (value)
                    surroundColor = focusColor;
                else
                    surroundColor = normalColor;
                Invalidate();
            }
        }
        // 调用ClickEvent事件
        protected override void OnClick(EventArgs e)
        {
            ClickEvent?.Invoke(this, new EventArgs());
        }
        /// <summary>
        /// 绘制控件的外观形状 边框 灯 文本 
        /// </summary>
        /// <param name="e"></param>
        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.HighQuality;
            // Path 灯的部分的圆形
            var path = new GraphicsPath();
            // 灯的矩形
            Rectangle rectEllipse;
            // 外围边框的矩形
            Rectangle borderEllipse;
            if (!string.IsNullOrEmpty(StateText)) // 设置了状态文本
            {
                // 定义边框部分的矩形尺寸
                borderEllipse = new Rectangle(Width / 4, Height / 8, Width / 2, Height / 2);
                // 定义灯的矩形区域
                rectEllipse = new Rectangle(Width / 4 + 4, Height / 8 + 4, Width / 2 - 8, Height / 2 - 8);
            }
            else // 没有文本的时候 灯的尺寸比较大
            {
                // 定义边框部分的矩形尺寸
                borderEllipse = new Rectangle(5, 5, Width - 10, Height - 10);
                // 定义灯的矩形区域 内部
                rectEllipse = new Rectangle(5 + Width / 10, 5 + Height / 10, Width - 10 - Width / 5, Height - 10 - Height / 5);
            }
            path.AddEllipse(borderEllipse);// 灯的圆形添加到路径中
            // 画刷 镜像渐变
            var pathGrBrush = new PathGradientBrush(path)
            {
                CenterColor = centerColor
            };
            Color[] colors = { surroundColor };
            pathGrBrush.SurroundColors = colors;// 路径中的颜色数组
            g.FillEllipse(new SolidBrush(borderColor), borderEllipse);// 填充外边框园
            g.FillEllipse(pathGrBrush, rectEllipse);// 填充指示灯部分

            // 绘制文本
            if (!string.IsNullOrEmpty(StateText))
            {
                // 定义文本的矩形
                Rectangle rectText = new Rectangle(Width / 6, Height - Height / 3, Width - Width / 3, Height / 3);
                // 文本的格式化
                StringFormat format = new StringFormat();
                // 水平垂直都居中
                format.Alignment = StringAlignment.Center;
                format.LineAlignment = StringAlignment.Center;
                // 绘制文本
                g.DrawString(stateText, this.Font, new SolidBrush(ForeColor), rectText,format);
            }
        }

    }
}
