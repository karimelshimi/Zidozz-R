using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Globalization;


namespace Zidozz_R
{
    public partial class Form1 : Form
    {
        private bool _dragging = false;
        
        private Point _start_point = new Point(0, 0);
        
        public Form1()
        {
            
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            

        }

        private void button9_Click(object sender, EventArgs e)
        {
          
        }

        private void button10_Click(object sender, EventArgs e)
        {
            
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            _dragging = true;  // _dragging is your variable flag
            _start_point = new Point(e.X, e.Y);
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            _dragging = false; 
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (_dragging)
            {
                Point p = PointToScreen(e.Location);
                Location = new Point(p.X - this._start_point.X, p.Y - this._start_point.Y);
            }
        }

       

      

        private void button11_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectAll();
            richTextBox1.Focus();
           
        }

       

        

        

        private void button16_Click(object sender, EventArgs e)
        {
            ColorDialog colorDlg = new ColorDialog();
            if (colorDlg.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.BackColor = colorDlg.Color;
                
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Process.Start("https://www.facebook.com/karimzidozz");
        }

        private void pictureBox3_MouseMove(object sender, MouseEventArgs e)
        {
            pictureBox3.BackColor = Color.Snow;
        }

        private void pictureBox3_MouseLeave(object sender, EventArgs e)
        {
            pictureBox3.BackColor = Color.Transparent;
        }

        private void pictureBox4_MouseLeave(object sender, EventArgs e)
        {
            pictureBox4.BackColor = Color.Transparent;
        }

        private void pictureBox4_MouseMove(object sender, MouseEventArgs e)
        {
            pictureBox4.BackColor = Color.Snow;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                try
                {
                    ofd.Filter = "Text files (*.txt)|*.txt|RTF files (*.rtf)|*.rtf";
                    if (ofd.ShowDialog() == DialogResult.OK)
                    {
                        if (Path.GetExtension(ofd.FileName) == ".rtf")
                        {
                            richTextBox1.LoadFile(ofd.FileName, RichTextBoxStreamType.RichText);
                        }
                        if (Path.GetExtension(ofd.FileName) == ".txt")
                        {
                            richTextBox1.LoadFile(ofd.FileName, RichTextBoxStreamType.PlainText);
                        }

                    }
                }
                catch (Exception)
                {
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            saveFileDialog1.RestoreDirectory = true;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllText(saveFileDialog1.FileName, richTextBox1.Text);
            }   
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (richTextBox1.Text == string.Empty)
            {
                MessageBox.Show("There is no Text");
            }
            else
                Clipboard.SetText(richTextBox1.Text);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            richTextBox1.Paste();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (richTextBox1.Text == "")
            {
                MessageBox.Show("There is no Text");
            }
            else
            {
                Clipboard.SetText(richTextBox1.Text);
                richTextBox1.Clear();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            richTextBox1.Undo();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            richTextBox1.Redo();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = string.Empty;
        }

        private void button12_Click(object sender, EventArgs e)
        {
            // Show the dialog.
            DialogResult result = fontDialog1.ShowDialog();
            // See if OK was pressed.
            if (result == DialogResult.OK)
            {
                // Get Font.
                Font font = fontDialog1.Font;
                // Set TextBox properties.
                richTextBox1.SelectAll();
                this.richTextBox1.Font = font;
            }

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            Font font = fontDialog1.Font;
            // Set TextBox properties.

            this.richTextBox1.Font = font;
        //------------------------------------------------------------
            string k;
            k = richTextBox1.TextLength.ToString();
            label2.Text = k;
       //-------------------------------------------------------------
            if (checkBox1.Checked == false)
            {
                
                if (checkBox2.Checked == true)
                {
                    richTextBox1.Font = new Font(richTextBox1.Font, FontStyle.Italic);
                }
                else if (checkBox3.Checked == true)
                {
                    richTextBox1.Font = new Font(richTextBox1.Font, FontStyle.Underline);
                }
                else
                    richTextBox1.Font = new Font(richTextBox1.Font, FontStyle.Regular);
            }
            else if (checkBox2.Checked == false)
            {
                if ( checkBox1.Checked == true)
                {
                    richTextBox1.Font = new Font(richTextBox1.Font, FontStyle.Bold);
                }
                   else if (checkBox3.Checked == true)
                    {
                        richTextBox1.Font = new Font(richTextBox1.Font, FontStyle.Underline);
                    }
                else
                {
                    richTextBox1.Font = new Font(richTextBox1.Font, FontStyle.Regular);
                }
            }
                else if (checkBox3.Checked == false)
            {
                
                    if (checkBox1.Checked == true)
                    {
                        richTextBox1.Font = new Font(richTextBox1.Font, FontStyle.Bold);
                    }
                    else if (checkBox2.Checked == true)
                    {
                        richTextBox1.Font = new Font(richTextBox1.Font, FontStyle.Italic);
                    }
                    else
                        richTextBox1.Font = new Font(richTextBox1.Font, FontStyle.Regular);

            }
            //---------------------------------------------------------------
             if (checkBox1.Checked == true && checkBox2.Checked == true)
            {
                richTextBox1.Font = new Font(richTextBox1.Font, FontStyle.Bold | FontStyle.Italic);
            }
            else if (checkBox1.Checked == true && checkBox3.Checked == true)
             {
                 richTextBox1.Font = new Font(richTextBox1.Font, FontStyle.Bold | FontStyle.Underline);
             }
            else if (checkBox2.Checked == true && checkBox3.Checked == true)
             {
                 richTextBox1.Font = new Font(richTextBox1.Font, FontStyle.Italic | FontStyle.Underline);
             }
             if (checkBox1.Checked == true && checkBox2.Checked == true && checkBox3.Checked == true)
             {
                 richTextBox1.Font = new Font(richTextBox1.Font, FontStyle.Bold | FontStyle.Italic | FontStyle.Underline);
             }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            richTextBox1.Font = new Font(richTextBox1.Font, FontStyle.Bold);
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            richTextBox1.Font = new Font(richTextBox1.Font, FontStyle.Italic);
        }

        private void oPENToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (radioButton1.Text == "English")
            {
                DialogResult dialogResult = MessageBox.Show("Are you sure you want to exit ?", "Warning", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    Application.Exit();
                }
                else if (dialogResult == DialogResult.No)
                {
                   
                }
            }
            else if (radioButton1.Text == "الانجليزيه")
            {
                DialogResult dialogResult = MessageBox.Show("هل أنت متأكد أنك تريد الخروج ؟", "تحذير", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    Application.Exit();
                }
                else if (dialogResult == DialogResult.No)
                {
                   
                }
            }
        }

        private void openToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                try
                {
                    ofd.Filter = "Text files (*.txt)|*.txt|RTF files (*.rtf)|*.rtf";
                    if (ofd.ShowDialog() == DialogResult.OK)
                    {
                        if (Path.GetExtension(ofd.FileName) == ".rtf")
                        {
                            richTextBox1.LoadFile(ofd.FileName, RichTextBoxStreamType.RichText);
                        }
                        if (Path.GetExtension(ofd.FileName) == ".txt")
                        {
                            richTextBox1.LoadFile(ofd.FileName, RichTextBoxStreamType.PlainText);
                        }

                    }
                }
                catch (Exception)
                {
                }
            }
        }

        private void openToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (richTextBox1.Text == string.Empty)
            {
                MessageBox.Show("There is no Text");
            }
            else
                Clipboard.SetText(richTextBox1.Text);
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (richTextBox1.Text == "")
            {
                MessageBox.Show("There is no Text");
            }
            else
            {
                Clipboard.SetText(richTextBox1.Text);
                richTextBox1.Clear();
            }
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Paste();
        }

        private void sELECTALLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectAll();
            richTextBox1.Focus();
        }

        private void cLEARToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = string.Empty;
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            saveFileDialog1.RestoreDirectory = true;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllText(saveFileDialog1.FileName, richTextBox1.Text);
            }   
        }

        private void button15_Click(object sender, EventArgs e)
        {
            ColorDialog colorDlg = new ColorDialog();
            if (colorDlg.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.ForeColor = colorDlg.Color;

            }
        }

        

        private void minimizeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void maximizeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            richTextBox1.Font = new Font(richTextBox1.Font, FontStyle.Underline);
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            button1.Text = "فتح";
            button2.Text = "نسخ";
            button3.Text = "لصق";
            button4.Text = "رجوع خطوه";
            button5.Text = "حفظ";
            button6.Text = "قص";
            button7.Text = "ازاله";
            button8.Text = "تقدم خطوه";
            
            button11.Text = "تحديد الكل";
            button12.Text = "الخط";
            
            button15.Text = "لون النص";
            button16.Text = "لون الخلفيه";
            groupBox1.Text = "اللغات";
            groupBox2.Text = "اسلوب الخط";
            
            groupBox4.Text = "المحاذاة";
            radioButton1.Text = "الانجليزيه";
            radioButton2.Text = "العربيه";
            radioButton3.Text = "يمين";
            radioButton4.Text = "وسط";
            radioButton5.Text = "يسار";
            label1.Text = "عدد الحروف";
            label2.Text = "0";
            checkBox1.Text = "عريض";
            checkBox2.Text = "مائل";
            checkBox3.Text = "تسطير";
            oPENToolStripMenuItem.Text = "تحرير";
            openToolStripMenuItem1.Text = "نسخ";
            cutToolStripMenuItem.Text = "قص";
            pasteToolStripMenuItem.Text = "لصق";
            sELECTALLToolStripMenuItem.Text = "تحديد الكل";
            cLEARToolStripMenuItem.Text = "مسح";
            openToolStripMenuItem2.Text = "فتح";
            saveToolStripMenuItem.Text = "حفظ";
            textEditToolStripMenuItem.Text = "خصائص النص";
            textColorToolStripMenuItem.Text = "لون النص";
            fontToolStripMenuItem.Text = "الخط";
            undoToolStripMenuItem.Text = "رجوع خطوه";
            redoToolStripMenuItem.Text = "تقدم خطوه";
            //---------------------------------
            maximizeToolStripMenuItem.Text = "تكبير";
            minimizeToolStripMenuItem.Text = "تصغير";
            sizeToolStripMenuItem.Text = "الحجم";
            infoToolStripMenuItem.Text = "المعلومات";
            closeToolStripMenuItem.Text = "الخروج";

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            button1.Text = "OPEN";
            button2.Text = "COPY";
            button3.Text = "PASTE";
            button4.Text = "UNDO";
            button5.Text = "SAVE";
            button6.Text = "CUT";
            button7.Text = "CLEAR";
            button8.Text = "REDO";
            
            button11.Text = "SELECT ALL";
            button12.Text = "FONT";
            
            button15.Text = "TEXT COLOR";
            button16.Text = "BACK COLOR";
            groupBox1.Text = "languages";
            groupBox2.Text = "Font Style";
           
            groupBox4.Text = "Alignment";
            radioButton1.Text = "English";
            radioButton2.Text = "Arabic";
            radioButton3.Text = "Right";
            radioButton4.Text = "Center";
            radioButton5.Text = "Left";
            label1.Text = "NO.Letters ";
            label2.Text = "0";
            checkBox1.Text = "Bold";
            checkBox2.Text = "Italic";
            checkBox3.Text = "Underline";
            oPENToolStripMenuItem.Text = "Edit";
            openToolStripMenuItem1.Text = "Copy";
            cutToolStripMenuItem.Text = "Cut";
            pasteToolStripMenuItem.Text = "Paste";
            sELECTALLToolStripMenuItem.Text = "Select all";
            cLEARToolStripMenuItem.Text = "Clear";
            openToolStripMenuItem2.Text = "Open";
            saveToolStripMenuItem.Text = "Save";
            textEditToolStripMenuItem.Text = "Text properties";
            textColorToolStripMenuItem.Text = "Text color";
            fontToolStripMenuItem.Text = "Font";
            undoToolStripMenuItem.Text = "Undo";
            redoToolStripMenuItem.Text = "Redo";
            //---------------------------------
            maximizeToolStripMenuItem.Text = "Maximize";
            minimizeToolStripMenuItem.Text = "Minimize";
            sizeToolStripMenuItem.Text = "Size";
            infoToolStripMenuItem.Text = "Info";
            closeToolStripMenuItem.Text = "Exit";
            //------------------------------------
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Process.Start("http://www.way2prof.com/");
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            richTextBox1.SelectAll();
            richTextBox1.SelectionAlignment = HorizontalAlignment.Right;
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            richTextBox1.SelectAll();
            richTextBox1.SelectionAlignment = HorizontalAlignment.Center;
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            richTextBox1.SelectAll();
            richTextBox1.SelectionAlignment = HorizontalAlignment.Left;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (radioButton1.Text == "English")
            {
                DialogResult dialogResult = MessageBox.Show("Are you sure you want to exit ?", "Warning", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    Application.Exit();
                }
                else if (dialogResult == DialogResult.No)
                {
                    e.Cancel = true;
                }
            }
            else if (radioButton1.Text == "الانجليزيه")
            {
                DialogResult dialogResult = MessageBox.Show("هل أنت متأكد أنك تريد الخروج ؟", "تحذير", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    Application.Exit();
                }
                else if (dialogResult == DialogResult.No)
                {
                    e.Cancel = true;
                }
            }
            
            
        }

        private void fontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Show the dialog.
            DialogResult result = fontDialog1.ShowDialog();
            // See if OK was pressed.
            if (result == DialogResult.OK)
            {
                // Get Font.
                Font font = fontDialog1.Font;
                // Set TextBox properties.
                richTextBox1.SelectAll();
                this.richTextBox1.Font = font;
            }
        }

        private void textColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog colorDlg = new ColorDialog();
            if (colorDlg.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.ForeColor = colorDlg.Color;

            }
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Undo();
        }

        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Redo();
        }

        private void infoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (radioButton1.Text == "English")
            {
                MessageBox.Show("Zidozz R" + Environment.NewLine + "version : 1.0" + Environment.NewLine + "programmer : karim mohamed");
            }
            else if ( radioButton1.Text == "الانجليزيه")
            {
                MessageBox.Show("Zidozz R" + Environment.NewLine + " الاصدار "+" :1.0" + Environment.NewLine + "المبرمج : karim mohamed");
            }
        }


        

       

        
    }
}
