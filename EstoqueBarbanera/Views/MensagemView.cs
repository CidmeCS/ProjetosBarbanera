using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Estoque.Views
{
    public partial class MensagemView : Form
    {
        public MensagemView(string r)
        {
            InitializeComponent();
            label1.Text = r;
            richTextBox1.Text = r;
        }
    }
}
