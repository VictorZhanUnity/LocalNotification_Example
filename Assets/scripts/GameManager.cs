using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    void Start()
    {
        AndroidNotificationManager.CreateNewNotification("example_channel_id", "Notification Title", "Notification Context", "icon_large", 
            DateTime.Now.AddSeconds(15));
    }
}
