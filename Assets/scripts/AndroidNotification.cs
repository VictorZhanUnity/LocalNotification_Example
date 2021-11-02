using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Notifications.Android;

public class AndroidNotification : MonoBehaviour
{
    void Start()
    {
        AndroidNotificationChannel notificationChannel = new AndroidNotificationChannel()
        {
            Id = "example_channel_id",
            Name = "My Channel",
            Importance = Importance.High,
            Description = "Generic Notification",
        };

        AndroidNotificationCenter.RegisterNotificationChannel(notificationChannel);
        AndroidNotification notification = new AndroidNotification();
    }

}
