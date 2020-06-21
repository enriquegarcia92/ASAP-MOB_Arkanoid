using System.Windows.Forms;

namespace ASAP_MOB_Arkanoid
{
    public class CustomPictureBox: PictureBox
    {
        public int Golpes { get; set; }

        public CustomPictureBox() : base() { }
    }
}