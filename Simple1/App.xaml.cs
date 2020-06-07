using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Simple1
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private static System.Threading.Mutex mutex;
        private void ApplicationStartup(object sender, StartupEventArgs e)
        {
            Test2();
        }

        private void Test1()
        {
            bool firstTimeRunning = false;
            mutex = new System.Threading.Mutex(true, "signleTester", out firstTimeRunning);
            if (firstTimeRunning)
            {
                // go on...
            }
            else
            {
                // exit.
                MessageBox.Show("Another Instance running!");
                mutex.Close();
                mutex = null;
                this.Shutdown();
            }
        }

        private void Test2()
        {
            mutex = new System.Threading.Mutex(false, "signleTester");
            if (mutex.WaitOne(0,false))
            {
                // go on...
            }
            else
            {
                // exit.
                MessageBox.Show("Another Instance running!");
                mutex.Close();
                mutex = null;
                this.Shutdown();
            }
        }
    }
}
