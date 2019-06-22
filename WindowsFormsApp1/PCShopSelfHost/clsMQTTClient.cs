using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;

namespace PCShopSelfHost
{
    public interface ISubject
    {
        void Subscribe(IObserver observer);
        void Unsubscribe(IObserver observer);
        void Notify(string lcMessage);
    }
    public interface IObserver
    {
        void MqttUpdate(string lcMessage);
    }



    public class clsMQTTClient : ISubject
    {

        private List<IObserver> observers = new List<IObserver>();


        public void Notify(string lcMessage)
        {
            observers.ForEach(x => x.MqttUpdate(lcMessage));
        }
        public void Subscribe(IObserver observer)
        {
            observers.Add(observer);
        }

        public void Unsubscribe(IObserver observer)
        {
            observers.Remove(observer);
        }






        private clsMQTTClient()
        {
        }
        public static readonly clsMQTTClient Instance = new clsMQTTClient();

        private MqttClient client;
        private string clientId;

        public void ConnectMqttClient()
        {
            string BrokerAddress = "broker.hivemq.com";

            client = new MqttClient(BrokerAddress);

            // register a callback-function (we have to implement, see below) which is called by the library when a message was received
            client.MqttMsgPublishReceived += MqttMsgPublishReceived;

            // use a unique id as client id, each time we start the application
            clientId = Guid.NewGuid().ToString();

            client.Connect(clientId);

            ////------------------
            MqttSubscribe();
            MqttPublish("A selfhost server has started!");
        }
        public void DisconnectMqttClient()
        {
            client.Disconnect();
        }

        public void MqttSubscribe()
        {
            // whole topic
            string Topic = "/PCShop/" + "DatabaseUpdate" + "/test";

            // subscribe to the topic with QoS 2
            client.Subscribe(new string[] { Topic }, new byte[] { 2 });   // we need arrays as parameters because we can subscribe to different topics with one call
        }

        public void MqttPublish(string lcMessageToPublish)
        {
            // whole topic
            string Topic = "/PCShop/" + "DatabaseUpdate" + "/test";

            // publish a message with QoS 2
            client.Publish(Topic, Encoding.UTF8.GetBytes(lcMessageToPublish), MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE, true);
        }
        public void MqttMsgPublishReceived(object sender, MqttMsgPublishEventArgs e)
        {
            string ReceivedMessage = Encoding.UTF8.GetString(e.Message);


            if (ReceivedMessage == "DBChange")
            {
                Notify("Success!");
            }

            if (ReceivedMessage == "TestUpdate")
            {

            }

            // Dispatcher.Invoke(delegate {              // we need this construction because the receiving code in the library and the UI with textbox run on different threads
            //    txtReceived.Text = ReceivedMessage;
            // });
        }


    }
}
