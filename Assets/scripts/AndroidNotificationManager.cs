using Unity.Notifications.Android;
using System;

public class AndroidNotificationManager
{
    // repeatTime最少為1分鐘
    public static void CreateNewNotification(string id, string title, string context, string iconName, DateTime fireDateTime, TimeSpan repeatTime)
    {
        AndroidNotificationChannel notificationChannel = new AndroidNotificationChannel()
        {
            Id = id, Name = "Default Channel", Importance = Importance.High, Description = "Generic Notification",
        };

        AndroidNotificationCenter.RegisterNotificationChannel(notificationChannel);

        AndroidNotification notification = new AndroidNotification(title, context, fireDateTime);
        notification.SmallIcon = notification.LargeIcon = iconName;
        notification.ShowTimestamp = true;
        if (repeatTime != null)
        {
            notification.RepeatInterval = repeatTime;
        }

        int identifier = AndroidNotificationCenter.SendNotification(notification, id);
        if (AndroidNotificationCenter.CheckScheduledNotificationStatus(identifier) == NotificationStatus.Scheduled)
        {
            AndroidNotificationCenter.CancelNotification(identifier);
            AndroidNotificationCenter.SendNotification(notification, id);
        }
    }

    public static void CancelAllNotifications()
    {
        AndroidNotificationCenter.CancelAllNotifications();
    }

    public static void DeleteNotificationChannel(string identifier)
    {
        AndroidNotificationCenter.DeleteNotificationChannel(identifier);
    }

}
