using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;
using System.Windows.Forms;

/// <summary>
/// Author: Robin Le Couteur
/// Date: 23/06/2019
/// 
/// This code file contains all the code for using MQTT and the code that uses the observer pattern
/// to notify all subscribed forms to update when the MQTT client recieves a DBUpdate message
/// </summary>
namespace PCShopWinFormAdmin
{

    /// <summary>
    /// Interface for the subject, in my case the mqtt client is the subject so it inherits from this.
    /// </summary>
    public interface ISubject
    {
        void Subscribe(IObserver observer);
        void Unsubscribe(IObserver observer);
        void Notify(string lcMessage);
    }

    /// <summary>
    /// Interface for the observer. 
    /// All forms that need to be notified of DBUpdate events need to implement this
    /// </summary>
    public interface IObserver
    {
        void MqttUpdate(string lcMessage);
    }


    /// <summary>
    /// Contains all the code for the mqtt client
    /// </summary>
    public class clsMQTTClient : ISubject
    {
        // List of all observers (The forms implementing IObserver)
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





        //Singleton - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
        private clsMQTTClient()
        {
        }
        public static readonly clsMQTTClient Instance = new clsMQTTClient();
        // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -



        private MqttClient client;
        private string clientId;

        //Connects the client to the mqtt broker 
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
            MqttPublish("An admin panel has started!");
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


            //If the client recieves a DBChange message notify the observers to update their screens
            if (ReceivedMessage == "DBChange")
            {
                Notify("DBChange");
            }
        }


    }
}
