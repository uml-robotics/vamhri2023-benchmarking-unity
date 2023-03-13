using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine;
using Ros_CSharp;
using Messages.sensor_msgs;

public class ROSnetSub : MonoBehaviour
{
    public ROSCore rosmaster;
    public string topic_name = "PleaseChooseATopic";
    private NodeHandle nh = null;
    private Subscriber<PointCloud2> sub;

    public int packet_size = 1000000;

    private PointCloud2 pcl;
    // Start is called before the first frame update
    void Start()
    {
        nh = rosmaster.getNodeHandle();
        sub = nh.subscribe<PointCloud2>(topic_name, 10,callback);
    }

    void callback(PointCloud2 cloud)
    {
        Messages.std_msgs.Time t = ROS.GetTime();
        t.data.sec += 18000;


        double cloud_time = cloud.header.stamp.data.sec + (cloud.header.stamp.data.nsec / 1000000000.0);

        double current_time = t.data.sec + (t.data.nsec / 1000000000.0);

        double latency = current_time - cloud_time;

        Debug.Log("Current latency is "+  latency);

        //cloud.header.stamp;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
