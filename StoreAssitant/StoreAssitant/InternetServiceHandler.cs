using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StoreAssitant
{
    public class InternetServiceHandler
    {
        private static InternetServiceHandler instance;
        private static int TIME_ONLINE_DETECTION = 2;
        public Task CheckOfflineTask;
        private Exception noInternetConnection;
        private CancellationTokenSource cancelProcess;

        public EventHandler OfflineModeDetected;

        private InternetServiceHandler()
        {
            noInternetConnection = new Exception("No internet");
            cancelProcess = new CancellationTokenSource();
        }

        public static InternetServiceHandler Instance {
            get
            {
                if (instance == null) instance = new InternetServiceHandler();
                return instance;
            }
        }
        public void Run()
        {
            CheckOfflineTask = Run(detecOfflineMode,
                new TimeSpan(0, 0, TIME_ONLINE_DETECTION),
                cancelProcess.Token);
        }
        private static async Task Run(Action act, TimeSpan period, CancellationToken token)
        {
            while (!token.IsCancellationRequested)
            {
                await Task.Delay(period, token);
                if (!token.IsCancellationRequested) act();
            }
        }

        private void detecOfflineMode()
        {
            if (!DatabaseController.IsOnline())
            {
                MessageBox.Show("Không có kết nối mạng, thoát chương trình","Thông báo", MessageBoxButtons.OK,MessageBoxIcon.Information);
                OnOfflineModeDetected(new EventArgs());
                cancelProcess.Cancel();
                //Application.Exit(); 
            }
        }
/*        public void Execute(Action func)
        {
            if (func == null) throw new ArgumentNullException();
            try
            {
                func();
            }
            catch
            {
                if (offlineModeDetected())
                {
                    throw noInternetConnection;
                }
                else
                {
                    throw;
                }
            }
        }

        private bool offlineModeDetected()
        {
            bool isOffileMode = false;
            if (!DatabaseController.IsOnline())
            {
                isOffileMode = true;
                Console.WriteLine("Offline Mode is turn on");

                OnOfflineModeDetected(new EventArgs());

            }
            return isOffileMode;
        }
*/
        private void OnOfflineModeDetected(EventArgs e)
        {
            OfflineModeDetected?.Invoke(this, e);
        }
    }
    public class MyWebClient : WebClient
    {
        //public MyWebClient() : base() { }
        protected override WebRequest GetWebRequest(Uri address)
        {
            WebRequest w = base.GetWebRequest(address);
            w.Timeout = 3 * 1000;
            return w;
        }
    }
}
