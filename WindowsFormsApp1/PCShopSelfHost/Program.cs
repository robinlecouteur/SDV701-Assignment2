using MQTTnet;
using MQTTnet.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.SelfHost;

namespace PCShopSelfHost
{
    class Program
    {
        static async void Main(string[] args)
        {
            // Set up server configuration
            Uri _baseAddress = new Uri("http://localhost:60064/");
            HttpSelfHostConfiguration config = new HttpSelfHostConfiguration(_baseAddress);
            config.Routes.MapHttpRoute(
            name: "DefaultApi",
            routeTemplate: "api/{controller}/{action}/{id}",
            defaults: new { id = RouteParameter.Optional }
            );

            // Create server
            HttpSelfHostServer server = new HttpSelfHostServer(config);

            // Start listening
            server.OpenAsync().Wait();




            //Start MQTT server
            var optionsBuilder = new MqttServerOptionsBuilder()
                .WithConnectionBacklog(100)
                .WithDefaultEndpointPort(1884);

            var mqttServer = new MqttFactory().CreateMqttServer();
            await mqttServer.StartAsync(optionsBuilder.Build());
            //------------------



            Console.WriteLine("PCShop Web-API Self hosted on " + _baseAddress +
                    _TextArt);
            Console.WriteLine("Hit ENTER to exit...");
            Console.ReadLine();
            server.CloseAsync().Wait();
            await mqttServer.StopAsync();
        }


        private const string _TextArt = @"
              ____,----.___
        __.--'...........::\_
      _/::::.:::::::.......::\
    _/::::.......::::::::...::\
   /:::............:::::::::.::\
   /:::................:::::::.:|
   |:::..|::.|::.........:::::.:/
   |::::..\\__\___..:::..:..::.::\             _.-----.____
    \\:::::| ___  \__\_/\::..:..::|           /:/:.........`---._
      \\__\  \  `      `,\......::|          /:.......:::::::....\_
            \ \     ,   \|:.....::|         :::. /:.......:::::::..\_
                //    ;  /::...::/         .|:../:............::::::.\
            /   /        \.\:.::/          |:::|::...............:::::|
            - _            \_\__|          |:..|::::...............:::|
              -'       ,      _/ \         |::..\_:::::.././:/:......:|
             _\__    _-    __/  _/\_       ::::...\----___/:/:__/::.../
             \_  __ -\  __/  __/    \      |.:....|  --   --'--`-/:../
            .--\_\ \  \/ ___/    |   \_    ||:....| --' -.  |/:./
            | --- \ | _ / __ /        |     \   ||::...|    ///  '-  /:,|
            | -- \| / _ /                  \   \.:...| __,     /::.|
             \-\|  ||           | ---.    \   |::.////\_   --- /::.:'
              | '||           /    \_   |   \:| '' ' / -/ \\\\::./
              |    ||          /       \__ | ____ ||    / ---'  ''|__/
              |   |:|         |        /    \ \  \   \  / _ / _____
              |   |:|         |       /      \ \  `   |/   /       \
              |   |:|                /        \ \_ |   |   |/        \
             .'   |:|         |     |          `- |  .' |         |
             |    |:|         |     | __   \  /   ||   |         |
             |    |:|         |     | _ /  \_ | /   .'|   `.  |     |
             |    |:/          \    | _ /      \|/    | |    |  .--.__ |
             |    `|         /  \  / \\       |    .' |    `./     |'
             |     |             \/   `|     .'    |  `.    |      |
             |     |       /   /   \   |    .'    .' |    `.     |
             |     |      /  / |    \_ `.  .'     |    |     |     |
             |     |     / /          \_ | '     .' |     `.    |
             |     |                   ||        | ----`.     |   , '
              \    /                   /`.       |      |     `   |
               \   \                  /% | '  %%  |         |
                `--_\                 |%% \     /   %|%  \       , '
                   \                 /    |\___ /     |    \_ / \
                   | ___ |%    |          |      `--' %%\
                    \__    __, --'   |%%  |%%      %% |    %%        |
                     / `--'         |    |%%%     %%%|  %%%%   %%%  |
                 "; 
    }
}
