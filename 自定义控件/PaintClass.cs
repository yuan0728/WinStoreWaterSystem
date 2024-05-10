using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinStoreWaterSystem
{
     public  class PaintClass
    {
        /// <summary>
        /// 获取圆角矩形的路径
        /// </summary>
        /// <param name="rect"></param>
        /// <param name="r"></param>
        /// <returns></returns>
        public static  GraphicsPath GetRoundRectangle(Rectangle rect,int r)
        {
            GraphicsPath gp = new GraphicsPath();
            int l = 2 * r;//圆弧所在矩形的边长
            //上边线段
            gp.AddLine(rect.X + r, rect.Y, rect.Right - r, rect.Y);
            //右上角1/4圆弧  270 90
            gp.AddArc(rect.Right - l, rect.Y, l, l, 270F, 90F);
            //右边竖线
            gp.AddLine(rect.Right, rect.Y+r, rect.Right, rect.Bottom-r);
            //右下角1/4圆弧  0 90
            gp.AddArc(rect.Right - l, rect.Bottom-l, l, l, 0F, 90F);
            //下边线段
            gp.AddLine(rect.Right-r, rect.Bottom, rect.X + r, rect.Bottom);
            //左下角1/4圆弧  90 90
            gp.AddArc(rect.X, rect.Bottom - l, l, l, 90F, 90F);
            //左边竖线
            gp.AddLine(rect.X , rect.Bottom-r, rect.X, rect.Y+r);
            //左上角1/4圆弧  180 90
            gp.AddArc(rect.X, rect.Y, l, l, 180F, 90F);
            return gp;
        }
    }
}
