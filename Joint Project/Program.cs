using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Joint_Project
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            DateTime currentUpdateTime;
            DateTime lastUpdateTime;
            TimeSpan frameTime;
            currentUpdateTime = DateTime.Now; lastUpdateTime = DateTime.Now;

            Form1 form = new Form1();               //Create the form
            form.Show();                            //Make it appear

            while (form.Created == true)
            {
                currentUpdateTime = DateTime.Now;
                frameTime = currentUpdateTime - lastUpdateTime;

                if (frameTime.TotalMilliseconds > 40)
                {
                    Application.DoEvents();
                    form.UpdateWorld();
                    form.Refresh();
                    lastUpdateTime = DateTime.Now;

                }
            }
        }


    }
}
