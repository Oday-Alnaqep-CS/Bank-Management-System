using System;
using System.Drawing;

namespace WindowsFormsApp2
{
    internal class PopupNotifier
    {
        public string TitleText { get; set; }
        public string ContentText { get; set; }
        public Color TitleColor { get; set; }
        public Color TitleColorHover { get; set; }
        public Color ContentHoverColor { get; set; }
        public int HeaderHeight { get; set; }
        public Color HeaderColor { get; set; }
        public int AnimationDuration { get; set; }
        public int AnimationInterval { get; set; }
        public int Delay { get; set; }

        public void Popup()
        {
            throw new NotImplementedException();
        }
    }
}