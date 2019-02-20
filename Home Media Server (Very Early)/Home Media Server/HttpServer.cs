using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net;

namespace Home_Media_Server
{
    public class HttpServer
    {
        private HttpListener listener;
        public bool IsRunning => listener.IsListening;

        public HttpServer()
        {
            listener = new HttpListener();
            listener.Prefixes.Add("http://*:5555/");
            //listener.Prefixes.Add("http://192.168.43.147:5555/");
        }
        public void Start()
        {
            if(!listener.IsListening)
            {
                listener.Start();
                HandleClient();
            }
        }
        public void Stop()
        {
            if (listener.IsListening)
            {
                listener.Stop();
            }
        }
        private async void HandleClient()
        {
            while (listener.IsListening)
            {
                var context = await listener.GetContextAsync();
                if(listener.IsListening)
                {
                    OnConnection?.Invoke(this, context);
                }
            }

        }
        public delegate void ConnectionHandler(object sender, HttpListenerContext e);
        public event ConnectionHandler OnConnection;
    }
}
