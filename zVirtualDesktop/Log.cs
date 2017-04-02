using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.ServiceModel;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace zVirtualDesktop
{
    public static class Log
    {

        public static void LogEvent(string eventName,
                          string eventDetails,
                          string additionalDetails,
                          string moduleName,
                          Exception e)
        {

            try
            {
                string computerInfo = "Operating System: " + System.Environment.OSVersion;

                AddEventToDatabase("zVirtualDesktop", "", DateTime.Now, eventName, eventDetails, additionalDetails, moduleName, e, 1, SystemInformation.UserName,
                SystemInformation.ComputerName, computerInfo);
                

            }
            catch (Exception ex)
            {
            }
        }

        private static void AddEventToDatabase(string applicationName, 
                                        string applicationVersion, 
                                        DateTime eventDateTime, 
                                        string eventName, 
                                        string eventDetails, 
                                        string additionalDetails,
                                        string moduleName,
                                        Exception exception,
                                        int stackLevel,
                                        string username,
                                        string computerName,
                                        string computerInfo)
        {

            try
            {
                StackFrame stackframe1 = new StackFrame(1 + stackLevel);
                ParameterInfo[] parameters = stackframe1.GetMethod().GetParameters();
                string method = (moduleName + Convert.ToString("::")) + stackframe1.GetMethod().Name;
                method = method + Convert.ToString("(");
                int i = 0;
                foreach (ParameterInfo param in parameters.OrderBy(p => p.Position))
                {
                    method = (method + param.ParameterType.Name + Convert.ToString(" ")) + param.Name;
                    if (i < parameters.Count() - 1)
                    {
                        method = method + Convert.ToString(", ");
                    }
                    i += 1;
                }
                method = method + Convert.ToString(")");



                String exceptionText = "";
                if (exception != null)
                {
                    exceptionText = exception.GetType().ToString();
                }

                Zomp.EventData theEvent = new Zomp.EventData();
                theEvent.ApplicationName = applicationName;
                theEvent.ApplicationVersion = applicationVersion;
                theEvent.EventDateTime = eventDateTime;
                theEvent.EventName = eventName;
                theEvent.EventDetails = eventDetails;
                theEvent.AdditionalDetails = additionalDetails;
                theEvent.ModuleName = moduleName;
                theEvent.Exception = exceptionText;
                theEvent.CallingMethod = method;
                theEvent.Username = username;
                theEvent.ComputerName = computerName;
                theEvent.ComputerInfo = computerInfo;

                Thread t = new Thread(AddEventToDatabase);

                //z.AddEventToDatabase(theEvent);


                t.Start(theEvent);
                //MessageBox.Show(ex.Message);
            }
            catch (Exception ex)
            {
            }
        }

        private static void AddEventToDatabase(Object d)
        {
            try
            {
                Zomp.EventData dd = (Zomp.EventData)d;
                WSHttpBinding b = new WSHttpBinding(SecurityMode.Transport);
                b.Security.Transport.ClientCredentialType = HttpClientCredentialType.None;
                b.Name = "WSHttpBinding_IService";
                EndpointAddress address = new EndpointAddress("https://zomp.co/z/ZompWebService.svc");

                using (Zomp.ServiceClient z = new Zomp.ServiceClient(b, address))
                {
                    z.AddEventToDatabase(dd);
                }


            }
            catch (Exception ex)
            {
            }


        }


    }
}
