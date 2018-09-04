using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pj_Thread_Form
{
    public partial class Form1 : Form
    {

        delegate void SetTbNumberCallBack(int vlaue);

        private SetTbNumberCallBack setCallBack;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //跨线程,普通调用异常
            //Thread thread1 = new Thread(SetNumber);
            //thread1.IsBackground = true;
            //thread1.Start();

            //跨线程，使用回调控制
            setCallBack = new SetTbNumberCallBack(SetValue);
            Thread thread2 = new Thread(SetNumber2);
            thread2.IsBackground = true;
            thread2.Start();
        }


        private void SetNumber()
        {
            for (int i = 0; i < 10000; i++)
            {
                this.textBox1.Text = i.ToString();
            }
        }


        private void SetNumber2()
        {
            for (int i = 0; i < 10000; i++)
            {
                //使用回调
                textBox1.Invoke(setCallBack, i);
            }
        }

        /// <summary>
        /// 定义回调使用的方法
        /// </summary>
        /// <param name="value"></param>
        private void SetValue(int value)
        {
            this.textBox1.Text = value.ToString();
        }

    }
}
