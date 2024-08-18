using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace VideoConverter.Auxiliary
{
    public class TextStreamWriter : TextWriter
    {
        private Control textbox;
        public TextStreamWriter(Control textbox)
        {
            this.textbox = textbox;
        }

        public override void Write(char value)
        {
            textbox.Text += value;
        }

        public override void Write(string value)
        {
            textbox.Text += value;
        }

        public override Encoding Encoding
        {
            get { return Encoding.ASCII; }
        }
    }
}



