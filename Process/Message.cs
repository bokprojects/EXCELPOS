using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace ExcelPOS.Process
{
    public class Message
    {
        public void DisplayStatus(ToolStripStatusLabel lblMessage,string Message)
        {
            lblMessage.Text = Message;
        }
    }
}
