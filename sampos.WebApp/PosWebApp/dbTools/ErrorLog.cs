using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

using System.Security.Permissions;
using System.Threading;
using System.Threading.Tasks;
using System.Configuration;
using System.Web.Hosting;



/*
 * 
 *   Based on the PH error handling DLL in ADDS data load...  
 *   Added 2 functions to handle the try catch and write to error log file
 * 
 */

namespace samposoapp.ErrorLog
{
    public partial class ErrorLog
    {
        public static class MyGlobals
        {
            public static Boolean _ERROR_FLag = false; // can change because not const
        }

       // private static string LogFileFolder =HostingEnvironment.MapPath(@"~\") + ConfigurationManager.AppSettings["OutputFolder"];
        //private static string OutputFileName = DateTime.Today.ToString("yyyyMMdd") + ".txt";//string.Format(ConfigurationManager.AppSettings["OutputFileName"],DateTime.Today);
       

        public void UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            //MessageBox.Show("UnhandledException!!!!");
            try
            {
                MyGlobals._ERROR_FLag = true;
                Exception ex = (Exception)e.ExceptionObject;
                TextWriter tw;
                // Create an erroro logging file. Once per day should be sufficieint.
                string _SmallName = System.Reflection.Assembly.GetExecutingAssembly().GetName().Name;
                _SmallName = "Log_err" + _SmallName + DateTime.Today.ToString("yyyyMMdd") + ".txt";
                string _path = System.Reflection.Assembly.GetExecutingAssembly().Location;
                _path = _path.Substring(0, _path.LastIndexOf("\\"));
                string _ErrorLog = _path + "\\" + _SmallName;

                if (!File.Exists(_ErrorLog))
                {
                    File.WriteAllText(_ErrorLog, "");
                }
                tw = new StreamWriter(_ErrorLog, true);
                string _filler = new String('-', 100);
                tw.WriteLine(_filler);
                string errorMsg = "A UNhandled Exception has occured on " + DateTime.Today.ToString("dddd dd MMMM yyyy") + " at " + DateTime.Now.ToString("HH:mm") + " with the following information:\n\n";
                tw.WriteLine(errorMsg);
                errorMsg = ex.Message + "\n\nStack Trace:\n" + ex.StackTrace;
                tw.WriteLine(errorMsg);
                tw.Close();
                //MessageBox.Show(ex.Message + "\n\nStack Trace:\n" + ex.StackTrace);
            }
            catch (Exception exc)
            {
                try
                {
                   // MessageBox.Show("Fatal Non-UI Error",
                     //   "Fatal Non-UI Error. Could not write the error to the event log. Reason: "
                       // + exc.Message, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
                finally
                {
                   // Application.Exit();
                }
            }
           // Application.Exit();
        }

        /*
         *  Log file - need to create log for FTP version 
         */

        public static string  ccLog(string _messageString)
        {
            try
            {
                //Exception ex = t.Exception;
                string LogFileFolder =HostingEnvironment.MapPath(@"~\") + ConfigurationManager.AppSettings["OutputFolder"];
                string OutputFileName = "errorlog-" + DateTime.Today.ToString("yyyyMMdd") + ".txt";//string.Format(ConfigurationManager.AppSettings["OutputFileName"],DateTime.Today);
       

                TextWriter tw;
                // Create an erroro logging file. Once per day should be sufficieint.
                //string _SmallName = System.Reflection.Assembly.GetExecutingAssembly().GetName().Name;
                //_SmallName = "Log_" + _SmallName + DateTime.Today.ToString("yyyyMMdd") + ".txt";
                //_SmallName = "LogAPO" + _SmallName + DateTime.Today.ToString("yyyyMMdd") + ".txt";
                //string _path = System.Reflection.Assembly.GetExecutingAssembly().Location;
                //_path = _path.Substring(0, _path.LastIndexOf("\\"));

                string _SmallName = OutputFileName;
                string _path = LogFileFolder;
                string _ErrorLog = _path + "\\" + _SmallName;
                
                if (!File.Exists(_ErrorLog))
                {
                    File.WriteAllText(_ErrorLog, "");
                }
                tw = new StreamWriter(_ErrorLog, true);
                string _filler = new String('-', 100);
                tw.WriteLine(_filler);
                string errorMsg = "Error log on " + DateTime.Today.ToString("dddd dd MMMM yyyy") + " at " + DateTime.Now.ToString("HH:mm") + " with the following information:\n\n";
                tw.WriteLine(errorMsg);
                //errorMsg = t.Message + "\n\nStack Trace:\n" + t.StackTrace + "\n\nSouce:\n" + t.Source;
                errorMsg = _messageString;
                tw.WriteLine(errorMsg);
                tw.Close();
                //MessageBox.Show(t.Message + "\n\nStack Trace:\n" + t.StackTrace);
                //MessageBox.Show(errorMsg = t.Message + "\n\nStack Trace:\n" + t.StackTrace + "\n\nSouce:\n" + t.Source);
                return _ErrorLog;

            }
            catch (Exception exc)
            {
                try
                {
                  //  MessageBox.Show("Fatal Non-UI Error",
                    //    "Fatal Non-UI Error. Could not write the error to the event log. Reason: "
                      //  + exc.Message, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
                finally
                {
                    //Application.Exit();
                }
                return "";
            }


        }

        /*
         * 
         * custom exception
         * date:4/10/2016
         * by: pphan
         */
        public static void ccException(string objectName, Exception t)
        {
             try
            {
                //Exception ex = t.Exception;
                TextWriter tw;
                // Create an erroro logging file. Once per day should be sufficieint.
                string LogFileFolder = HostingEnvironment.MapPath(@"~\") + ConfigurationManager.AppSettings["OutputFolder"];
                string OutputFileName = "ExceiptionErrorlog-" + DateTime.Today.ToString("yyyyMMdd") + ".txt";

                string _SmallName = OutputFileName;
                string _path = LogFileFolder;
                 //string.Format(ConfigurationManager.AppSettings["OutputFileName"],DateTime.Today);

                //string _SmallName = System.Reflection.Assembly.GetExecutingAssembly().GetName().Name;
                //_SmallName = "Log_" + _SmallName + DateTime.Today.ToString("yyyyMMdd") + ".txt";
                //string _path = System.Reflection.Assembly.GetExecutingAssembly().Location;
                //_path = _path.Substring(0, _path.LastIndexOf("\\"));
                string _ErrorLog = _path + "\\" + _SmallName;

                if (!File.Exists(_ErrorLog))
                {
                    File.WriteAllText(_ErrorLog, "");
                }
                tw = new StreamWriter(_ErrorLog, true);
                string _filler = new String('-', 100);
                tw.WriteLine(_filler);
                string errorMsg = "A Handled Exception has occured on " + DateTime.Today.ToString("dddd dd MMMM yyyy") + " at " + DateTime.Now.ToString("HH:mm") + " with the following information:\n\n";
                tw.WriteLine(errorMsg);
                errorMsg = t.Message + "\n\n Stack Trace:\n" + t.StackTrace + "\n\n Souce:\n" + t.Source;
                
                tw.WriteLine(errorMsg);

                tw.WriteLine(objectName);
                tw.Close();
                //MessageBox.Show(t.Message + "\n\nStack Trace:\n" + t.StackTrace);
                //MessageBox.Show(errorMsg = t.Message + "\n\nStack Trace:\n" + t.StackTrace + "\n\nSouce:\n" + t.Source);

            }
             catch (Exception exc)
             {
                 try
                 {
                     //MessageBox.Show("Fatal Non-UI Error",
                      //   "Fatal Non-UI Error. Could not write the error to the event log. Reason: "
                        // + exc.Message, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                 }
                 finally
                 {
                     //Application.Exit();
                 }
             }

        }

        public void  UIException(object sender, Exception t)
        {

            try
            {
                //Exception ex = t.Exception;
                TextWriter tw;
                // Create an erroro logging file. Once per day should be sufficieint.
                string _SmallName = System.Reflection.Assembly.GetExecutingAssembly().GetName().Name;
                _SmallName = "Error" + _SmallName + DateTime.Today.ToString("yyyyMMdd") + ".txt";
                string _path = System.Reflection.Assembly.GetExecutingAssembly().Location;
                _path = _path.Substring(0, _path.LastIndexOf("\\"));
                string _ErrorLog = _path + "\\" + _SmallName;

                if (!File.Exists(_ErrorLog))
                {
                    File.WriteAllText(_ErrorLog, "");
                }
                tw = new StreamWriter(_ErrorLog, true);
                string _filler = new String('-', 100);
                tw.WriteLine(_filler);
                string errorMsg = "A Handled Exception has occured on " + DateTime.Today.ToString("dddd dd MMMM yyyy") + " at " + DateTime.Now.ToString("HH:mm") + " with the following information:\n\n";
                tw.WriteLine(errorMsg);
                errorMsg = t.Message + "\n\n Stack Trace:\n" + t.StackTrace + "\n\n Souce:\n" + t.Source;
                
                tw.WriteLine(errorMsg);
                tw.Close();
                //MessageBox.Show(t.Message + "\n\nStack Trace:\n" + t.StackTrace);
                //MessageBox.Show(errorMsg = t.Message + "\n\nStack Trace:\n" + t.StackTrace + "\n\nSouce:\n" + t.Source);

            }
            catch (Exception exc)
            {
                try
                {
                    //MessageBox.Show("Fatal Non-UI Error",
                      //  "Fatal Non-UI Error. Could not write the error to the event log. Reason: "
                        //+ exc.Message, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
                finally
                {
                   // Application.Exit();
                }
            }
        }







        public void UIThreadException(object sender, ThreadExceptionEventArgs t)
        {
            try
            {
                Exception ex = t.Exception;
                TextWriter tw;
                // Create an erroro logging file. Once per day should be sufficieint.
                string _SmallName = System.Reflection.Assembly.GetExecutingAssembly().GetName().Name;
                _SmallName = "Error" + _SmallName + DateTime.Today.ToString("yyyyMMdd") + ".txt";
                string _path = System.Reflection.Assembly.GetExecutingAssembly().Location;
                _path = _path.Substring(0, _path.LastIndexOf("\\"));
                string _ErrorLog = _path + "\\" + _SmallName;

                if (!File.Exists(_ErrorLog))
                {
                    File.WriteAllText(_ErrorLog, "");
                }
                tw = new StreamWriter(_ErrorLog, true);
                string _filler = new String('-', 100);
                tw.WriteLine(_filler);
                string errorMsg = "A Handled Exception has occured on " + DateTime.Today.ToString("dddd dd MMMM yyyy") + " at " + DateTime.Now.ToString("HH:mm") + " with the following information:\n\n";
                tw.WriteLine(errorMsg);
                errorMsg = ex.Message + "\n\nStack Trace:\n" + ex.StackTrace;
                tw.WriteLine(errorMsg);
                tw.Close();
               // MessageBox.Show(ex.Message + "\n\nStack Trace:\n" + ex.StackTrace);

            }
            catch (Exception exc)
            {
                try
                {
                   // MessageBox.Show("Fatal Non-UI Error",
                    //    "Fatal Non-UI Error. Could not write the error to the event log. Reason: "
                    //    + exc.Message, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
                finally
                {
                   // Application.Exit();
                }
            }
        }
    }
}
