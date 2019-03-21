using System;
using System.Drawing;
using System.Windows.Forms;

namespace TextEditor.Helper
{
    public class InfoLabel
    {
        private Label _lbInfo;
        public InfoLabel(Label lbInfo)
        {
            _lbInfo = lbInfo;
            _lbInfo.Text = "";
        }
        public void Print(string info)
        {
            _lbInfo.Invoke((MethodInvoker)(() => _lbInfo.Text = info));
        }

        public static implicit operator Label(InfoLabel v)
        {
            throw new NotImplementedException();
        }
    }
}
