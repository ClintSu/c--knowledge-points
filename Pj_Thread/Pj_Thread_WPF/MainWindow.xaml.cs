using System.Threading;
using System.Windows;

namespace Pj_Thread_WPF
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        delegate void SetTbNumberCallBack(int vlaue);
        SetTbNumberCallBack setCallBack;

        private void btnTest_Click(object sender, RoutedEventArgs e)
        {
            //跨线程
            setCallBack = new SetTbNumberCallBack(SetValue);
            Thread thread1 = new Thread(SetNumber);
            thread1.IsBackground = true;
            thread1.Start();

        }
        private void SetNumber()
        {
            for (int i = 0; i < 10000; i++)
            {
                //使用回调
                this.Dispatcher.Invoke(setCallBack, i);
            }
        }

        /// <summary>
        /// 定义回调使用的方法
        /// </summary>
        /// <param name="value"></param>
        private void SetValue(int value)
        {
            this.tbNumber.Text = value.ToString();
        }

    }
}
