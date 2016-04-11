using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace IotMQTTClient_beta_v1
{
    
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private MqttClient client;
        byte[] message;
       
        public MainPage()
        {
            this.InitializeComponent();
            this.client = new MqttClient("broker.mqttdashboard.com");//QOS_LEVEL_AT_MOST_ONCE
            try
            {
                this.client.Connect(Guid.NewGuid().ToString());
                textBlock3.Text = "broker.mqttdashboard.com";
            }
            catch (Exception)
            {
                try
                {
                    this.client = new MqttClient("iot.eclipse.org");
                    textBlock3.Text = "iot.eclipse.org";
                }
                catch (Exception)
                {

                    textBlock3.Text = "No Broker Connection";
                }
                
            }
            //this.client.Connect(Guid.NewGuid().ToString());
            byte[] qosLevels = { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE, MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE };
            this.client.Publish("/MQTTpublisher", Encoding.UTF8.GetBytes("connected"));
        }

        private void publishButton_Click(object sender, RoutedEventArgs e)
        {
            string topicStringA = topicA.Text;
            string status = textboxTopicA.Text;
            this.client.Publish(topicStringA, Encoding.UTF8.GetBytes(status));
        }

        private void Switch1_Toggled(object sender, RoutedEventArgs e)
        {
            if (Switch1.IsOn == true)
            {
                string topicStringB = topicB.Text;
                string status = Switch1.Name + ":" +  "on";
                this.client.Publish(topicStringB, Encoding.UTF8.GetBytes(status));

            }
            else if (Switch1.IsOn == false)
            {
                string topicStringB = topicB.Text;
                string status =  Switch1.Name + ":" +  "off";
                this.client.Publish(topicStringB, Encoding.UTF8.GetBytes(status));
            }
        }

        private void Switch2_Toggled(object sender, RoutedEventArgs e)
        {
            if (Switch2.IsOn == true)
            {
                string topicStringB = topicB.Text;
                string status = Switch2.Name + ":" + "on";
                this.client.Publish(topicStringB, Encoding.UTF8.GetBytes(status));

            }
            else if (Switch2.IsOn == false)
            {
                string topicStringB = topicB.Text;
                string status = Switch2.Name + ":" + "off";
                this.client.Publish(topicStringB, Encoding.UTF8.GetBytes(status));
            }
        }

        private void Switch3_Toggled(object sender, RoutedEventArgs e)
        {
            if (Switch3.IsOn == true)
            {
                string topicStringB = topicB.Text;
                string status = Switch3.Name +":"+ "on";
                this.client.Publish(topicStringB, Encoding.UTF8.GetBytes(status));

            }
            else if (Switch3.IsOn == false)
            {
                string topicStringB = topicB.Text;
                string status = Switch3.Name + ":" + "off";
                this.client.Publish(topicStringB, Encoding.UTF8.GetBytes(status));
            }
        }

        private void Switch4_Toggled(object sender, RoutedEventArgs e)
        {
            if (Switch4.IsOn == true)
            {
                string topicStringB = topicB.Text;
                string status = Switch4.Name + ":" + "on";
                this.client.Publish(topicStringB, Encoding.UTF8.GetBytes(status));

            }
            else if (Switch4.IsOn == false)
            {
                string topicStringB = topicB.Text;
                string status = Switch4.Name + ":" + "off";
                this.client.Publish(topicStringB, Encoding.UTF8.GetBytes(status));
            }
        }

        private void slider_ValueChanged(object sender, RangeBaseValueChangedEventArgs e)
        {
            string topicStringC = topicC.Text;
            sliderValue.Text = slider.Value.ToString();
            string status = sliderValue.Text;
            this.client.Publish(topicStringC, Encoding.UTF8.GetBytes(status));
        }
    }
}
