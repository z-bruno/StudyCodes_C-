using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BackgroundWorker_test2
{
    public partial class Form1 : Form
    {

        private BackgroundWorker bgWorker = new BackgroundWorker();
        public Form1()
        {
            InitializeComponent();
            InitializeBackgroundWorker();
        }

        private void InitializeBackgroundWorker()
        {
            //报告操作进度，触发BackgroundWorker.ProgressChanged事件
            //内部包含int类型的变量percentProgress，用来表示当前异步操作所执行的进度百分比
            bgWorker.WorkerReportsProgress = true;

            //bool类型，指示BackgroundWorker是否支持异步取消操作。当该属性值为True是，将可以成功调用CancelAsync方法
            bgWorker.WorkerSupportsCancellation = true;

            //bgWorker.DoWork += new DoWorkEventHandler(bgWorker_DoWork);  //用bgWorker_DoWork方法处理DoWork事件
            //bgWorker.ProgressChanged += new ProgressChangedEventHandler(bgWorker_ProgessChanged);
            //bgWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bgWorker_WorkerCompleted);
            bgWorker.DoWork += bgWorker_DoWork;
            bgWorker.ProgressChanged += bgWorker_ProgessChanged;
            bgWorker.RunWorkerCompleted += bgWorker_WorkerCompleted;

        }
        //DoWork不能够操作用户界面的内容，如果需要更新用户界面，可以使用ProgressChanged事件及RunWorkCompleted事件来实现
        public void bgWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            for (int i = 0; i <= 99; i++)
            {
                //判断用户是否请求中断后台线程
                if (bgWorker.CancellationPending)
                {
                    e.Cancel = true;
                    return;
                }
                else
                {
                    //传送后台线程进度同时触发ProgressChanged事件
                    bgWorker.ReportProgress(i, "Working");
                    System.Threading.Thread.Sleep(50);

                    //在进度条读到99％时停3秒然后完成
                    if (i == 99) { System.Threading.Thread.Sleep(3000); i++; bgWorker.ReportProgress(i, "Working"); }
                }
            }
        }
        //bgWorker.ReportProgress的数值改变时触发ProgressChanged事件
        public void bgWorker_ProgessChanged(object sender, ProgressChangedEventArgs e)
        {
            //string state = (string)e.UserState;//接收ReportProgress方法传递过来的userState
            this.progressBar1.Value = e.ProgressPercentage;
            this.label1.Text = "处理进度:" + Convert.ToString(e.ProgressPercentage) + "%";
            Console.WriteLine("  -> " + e.ProgressPercentage);
        }
        //DoWork线程结束后触发WorkerCompleted事件
        public void bgWorker_WorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //判断是是否出错
            if (e.Error != null)
            {
                MessageBox.Show(e.Error.ToString());
                return;
            }
            //判断是否完成后台进程
            if (!e.Cancelled)
            {
                this.label1.Text = "处理完毕!";
                this.btnStart.Enabled = true;
            }
            //若未完成后台进程则为用户中止进程
            else
                return;
                //this.label1.Text = "处理终止!";

        }

        private void btnStart_Click_1(object sender, EventArgs e)
        {
            if (bgWorker.IsBusy)
                return;            
            this.progressBar1.Maximum = 100;
            this.btnStart.Enabled = false;
            this.btnStop.Enabled = true;
            bgWorker.RunWorkerAsync();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            this.btnStart.Enabled = true;
            this.btnStop.Enabled = false;
            bgWorker.CancelAsync();
        }
    }
}
