using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private int seconds = 10;

    private string id = "example_channel_id";

    void Start()
    {
        AndroidNotificationManager.CancelAllNotifications();
        AndroidNotificationManager.CreateNewNotification(id, "Notification Title", "Notification Context", "icon_large",
            DateTime.Now.AddSeconds(seconds), new TimeSpan(0, 1, 0));
    }

    public void DeleteNotification()
    {
        AndroidNotificationManager.DeleteNotificationChannel(id);
    }
}
