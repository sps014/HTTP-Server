# Http Server C#
This Project only firewall permission is needed to communicate with Remote client and no need of Administrative Permissions.
At core of this lies a Sonic Server which is a HTTP Server based on TCP Listener.
I created this to avoid many firewall issues.

## Usage

```c#
        SonicHttpServer server = new SonicHttpServer();


        private  void button1_Click(object sender, EventArgs e)
        {

            if (!server.IsRunning)
            {
                server.Start();
            }
            else
            {
                server.Stop();
            }
        }
        
        //Events

        private void Form1_Load(object sender, EventArgs e)
        {
            //server.OnConnection += Server_OnConnection;
            server.ClientConnected += Server_ClientConnected;
            server.Start();
        }
        
        //On CLient Connected
        private async void Server_ClientConnected(object sender, ConnectionEventArgs e)
        {
            
            string reqURL = e.Request.URL;
            if(reqURL==null)
            {
                e.Response.OutputStream.Close();
                return;
            }
            else
            {
                e.Response.WriteHeader(StatusCode.NOT_FOUND, MIMEType.none);
                e.Response.End();
            }
        }
```
