using Unity.Notifications.Android;
using System;

public class AndroidNotificationManager
{
    public static void CreateNewNotification(string id, string title, string context, string iconName, DateTime dateTime)
    {
        AndroidNotificationChannel notificationChannel = new AndroidNotificationChannel()
        {
            Id = id, Name = "Default Channel", Importance = Importance.High, Description = "Generic Notification",
        };

        AndroidNotificationCenter.RegisterNotificationChannel(notificationChannel);

        AndroidNotification notification = new AndroidNotification();
        notification.Title = title;
        notification.Text = context;
        notification.SmallIcon = notification.LargeIcon = iconName;
        notification.ShowTimestamp = true;
        notification.FireTime = dateTime;

        var identifier = AndroidNotificationCenter.SendNotification(notification, id);

        if (AndroidNotificationCenter.CheckScheduledNotificationStatus(identifier) == NotificationStatus.Scheduled)
        {
            AndroidNotificationCenter.CancelAllNotifications();
            AndroidNotificationCenter.SendNotification(notification, id);
        }
    }
}
