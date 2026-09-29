using System.Windows.Forms;

namespace MB01.A1_2_5
{
    /*
     * Eigene Class (Klasse), die von TableLayoutPanel erbt.
     *
     * Double Buffering:
     *
     * Die Oberfläche wird zuerst unsichtbar vorbereitet
     * und anschliessend als fertiges Bild dargestellt.
     *
     * Das reduziert sichtbares Flackern erheblich.
     */
    public class DoubleBufferedTableLayoutPanel
        : TableLayoutPanel
    {
        public DoubleBufferedTableLayoutPanel()
        {
            DoubleBuffered = true;


            SetStyle(
                ControlStyles.OptimizedDoubleBuffer |
                ControlStyles.AllPaintingInWmPaint |
                ControlStyles.ResizeRedraw,
                true
            );


            UpdateStyles();
        }
    }
}