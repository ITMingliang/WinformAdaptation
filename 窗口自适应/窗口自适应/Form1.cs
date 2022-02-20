using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 窗口自适应
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        #region
        private float FormHeight;
        private float FormWidth;

        private void setTag( Control cons)
        {
            foreach (Control con in cons.Controls)
            {
                con.Tag = con.Width + ":" + con.Height + ":" + con.Left + ":" + con.Top + ":" + con.Font.Size;
                if (con.Controls.Count>0)
                {
                    setTag(con);
                }
            }
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            FormWidth =this.Width;  
            FormHeight =this.Height;    
            setTag(this);
        }


        private void setControls(float newx, float newy, Control cons)
        {

            try
            {
                foreach (Control con in cons.Controls)
                {
                    string[] mytag = con.Tag.ToString().Split(new char[] { ':' });
                    float a = System.Convert.ToSingle(mytag[0]) * newx;
                    con.Width = (int)a;
                    a = System.Convert.ToSingle(mytag[1]) * newy;
                    con.Height = (int)a;
                    a = System.Convert.ToSingle(mytag[2]) * newx;
                    con.Left = (int)a;
                    a = System.Convert.ToSingle(mytag[3]) * newy;
                    con.Top = (int)a;

                    Single currentSize = System.Convert.ToSingle(mytag[4]) * newy; 
                    con.Font = new System.Drawing.Font(con.Font.Name, currentSize, con.Font.Style, con.Font.Unit);

                    if (con.Controls.Count > 0)
                    {
                        setControls(newx, newy, con);
                    }
                }
            }
            catch (Exception)
            {

            }

        
            
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            float newx=(this.Width)/ FormWidth;
            float newy=(this.Height)/ FormHeight;
            setControls(newx, newy,this);

        }
        #endregion


    }


}
