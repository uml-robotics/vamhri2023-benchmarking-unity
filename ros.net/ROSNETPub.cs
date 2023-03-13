using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ros_CSharp;
using Messages.sensor_msgs;

public class ROSNETPub : MonoBehaviour
{
    public ROSCore rosmaster;
    public string topic_name = "PleaseChooseATopic";
    private NodeHandle nh = null;
    private Publisher<PointCloud2> pub;

    public int packet_size = 1000000;

    private PointCloud2 pcl;
    byte[] data;
    // Start is called before the first frame update
    void Start()
    {
        nh = rosmaster.getNodeHandle();
        pub = nh.advertise<PointCloud2>(topic_name, 10);

        pcl = new PointCloud2();

         data = new byte[packet_size];
        for (int i = 0; i < packet_size; i++)
        {
            data[i] = (byte)1;
        }

        pcl.data = data;
    }

    // Update is called once per frame
    void Update()
    {
        pcl = new PointCloud2();
        pcl.data = data;
        pcl.header = new Messages.std_msgs.Header();
        pcl.header.stamp = ROS.GetTime();
        pcl.header.stamp.data.sec += 18000;
        pub.publish(pcl);
    }
}
