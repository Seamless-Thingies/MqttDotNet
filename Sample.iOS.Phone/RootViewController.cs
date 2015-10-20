using System;
using System.Drawing;

using Foundation;
using MqttLib;
using MqttLib.Core;
using UIKit;

namespace Sample.iOS.Phone
{
    public partial class RootViewController : UIViewController
    {
        private IMqtt _mqttClient;
        private bool _connected = false;
        private bool _subscribed = false;

        public RootViewController(IntPtr handle) : base(handle)
        {
        }

        public override void DidReceiveMemoryWarning()
        {
            // Releases the view if it doesn't have a superview.
            base.DidReceiveMemoryWarning();

            // Release any cached data, images, etc that aren't in use.
        }

        #region View lifecycle

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            lblConnected.Text = "Disconnected";
            _mqttClient = MqttClientFactory.CreateClient("tcp://m11.cloudmqtt.com:12360", Guid.NewGuid().ToString(), "mike", "cloudmqtt");
            _mqttClient.Connected += (object sender, EventArgs e) => {

                InvokeOnMainThread(() =>
                {
                    var subscription = new Subscription("mqttdotnet/pubtest", QoS.BestEfforts);
                    _mqttClient.Subscribe(subscription);
                    setConneectedState();
                });
            };
            _mqttClient.ConnectionLost += (object sender, EventArgs e) => {
                InvokeOnMainThread(() => {
                    setDisconnectedState();
                });
            };
            _mqttClient.Subscribed += _mqttClient_Subscribed;
            _mqttClient.Unsubscribed += _mqttClient_Unsubscribed;
            _mqttClient.PublishArrived += _mqttClient_PublishArrived;

            _mqttClient.Connect();
        }

        private bool _mqttClient_PublishArrived(object sender, PublishArrivedArgs e)
        {
            InvokeOnMainThread(() =>
            {
                lblReceivedMessage.Text = e.Payload.ToString();
            });
            return true;
        }

        private void setConneectedState()
        {
            btnSend.Enabled = true;
            lblConnected.TextColor = UIColor.Green;
            lblConnected.Text = "Connected";
            btnConnect.SetTitle("Disconnect", UIControlState.Normal);
            _connected = true;
        }

        private void setDisconnectedState()
        {
            btnSend.Enabled = false;
            lblConnected.TextColor = UIColor.Red;
            lblConnected.Text = "Not connected";
            btnConnect.SetTitle("Connect", UIControlState.Normal);
            _connected = false;

        }

        private void _mqttClient_Subscribed(object sender, CompleteArgs e)
        {
            _subscribed = true;
        }

        private void _mqttClient_Unsubscribed(object sender, CompleteArgs e)
        {
            _subscribed = false;
        }

        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);
        }

        public override void ViewDidAppear(bool animated)
        {
            base.ViewDidAppear(animated);
        }

        public override void ViewWillDisappear(bool animated)
        {
            base.ViewWillDisappear(animated);
        }

        public override void ViewDidDisappear(bool animated)
        {
            base.ViewDidDisappear(animated);
        }

        #endregion

        partial void btnSend_TouchUpInside(UIButton sender)
        {
            if (_subscribed)
            {
                var message = tbContent.Text;
                _mqttClient.Publish("mqttdotnet/pubtest", message, QoS.BestEfforts, false);
            }
        }

        partial void btnConnect_TouchUpInside(UIButton sender)
        {
            if (_connected)
            {
                _mqttClient.Disconnect();
                setDisconnectedState();
            }
            else
            {
                _mqttClient.Connect();
            }
        }
    }
}