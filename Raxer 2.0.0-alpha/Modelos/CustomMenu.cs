using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using LinearGradientBrush = System.Drawing.Drawing2D.LinearGradientBrush;

namespace Raxer_2_alpha.Modelos;
internal class CustomMenu : ContextMenuStrip
{
    private string color1, color2;

    [DllImport("dwmapi.dll", CharSet = CharSet.Unicode, SetLastError = true)]
    private static extern long DwmSetWindowAttribute(
        IntPtr hwnd,
        DWMWINDOWATTRIBUTE attribute,
        ref DWM_WINDOW_CORNER_PREFERENCE pvAttribute,
        uint cbAttribute);

    public CustomMenu(string col1, string col2)
    {
        color1 = col1;
        color2 = col2;

        ForeColor = System.Drawing.Color.White;

        var preferencia = DWM_WINDOW_CORNER_PREFERENCE.DWMWCP_ROUND;
        DwmSetWindowAttribute(Handle,
                              DWMWINDOWATTRIBUTE.DWMWA_WINDOW_CORNER_PREFERENCE,
                              ref preferencia,
                              sizeof(uint));
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        LinearGradientBrush pincelGrad = new LinearGradientBrush(
            System.Drawing.Point.Empty,
            new System.Drawing.Point(0, Height),
            ColorTranslator.FromHtml(color1),
            ColorTranslator.FromHtml(color2));

        e.Graphics.FillRectangle(pincelGrad, new Rectangle(System.Drawing.Point.Empty, Size));

        base.OnPaint(e);
    }
    public void ChangueColorStatus(string color1, string color2)
    {
        this.color1 = color1;
        this.color2 = color2;
    }
}

public enum DWMWINDOWATTRIBUTE
{
    DWMWA_WINDOW_CORNER_PREFERENCE = 33
}
public enum DWM_WINDOW_CORNER_PREFERENCE
{
    DWMWCP_ROUND = 2,
}