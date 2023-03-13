using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RosSharp.RosBridgeClient
{
    public class rossharppub : UnityPublisher<MessageTypes.Sensor.PointCloud2>
    {
        //public Transform PublishedTransform;
        //public string FrameId = "Unity";

        public int packet_size = 100000;

        private MessageTypes.Sensor.PointCloud2 message;

        protected override void Start()
        {
            base.Start();
            InitializeMessage();
        }

        private void FixedUpdate()
        {
            UpdateMessage();
        }

        private void InitializeMessage()
        {
            message = new MessageTypes.Sensor.PointCloud2
            {
                header = new MessageTypes.Std.Header()
                {
                    frame_id = ""
                }
            };

            byte[] data = new byte[packet_size];
            for (int i = 0; i < packet_size; i++)
            {
                data[i] = (byte)1;
            }
            message.data = data;
        }

        private void UpdateMessage()
        {
            message.header.Update();

            Publish(message);
        }



    }
}
