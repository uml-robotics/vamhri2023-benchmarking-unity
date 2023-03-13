using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Unity.Robotics.ROSTCPConnector;
using RosMessageTypes.Std;

using RosMessageTypes.Sensor;
using RosSharp;
using Ros_CSharp;

public class SimpleSubscriber : MonoBehaviour
{
    ROSConnection ros;
    public string topicName = "pos_rot";
    public int packet_size = 1000000;
    // Start is called before the first frame update

    PointCloud2Msg pcl;

    public ROSCore rosmaster;
    void Start()
    {
        ros = ROSConnection.GetOrCreateInstance();

        ros.RegisterPublisher<PointCloud2Msg>("data");

        pcl = new PointCloud2Msg();

        byte[] data = new byte[packet_size];
        for(int i = 0; i < packet_size; i++)
        {
            data[i] = (byte)1;
        }
        pcl.data = data;
    }

    // Update is called once per frame
    void Update()
    {

         Messages.std_msgs.Time t = ROS.GetTime();
        pcl.header.stamp.sec = t.data.sec + 18000; //windows time
        pcl.header.stamp.nanosec = t.data.nsec;

        ros.Publish("data", pcl);


    }
}
