using Erp.Application.Common.Models;
using Erp.Domain.Entities.Common;
using Erp.Domain.Entities.Common.NotificationForMobile;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using FCMNotificationModel = Erp.Domain.Entities.Common.NotificationForMobile.FCMNotificationModel;

namespace Erp.Application.Common.Notifications
{
    public interface INotifications
    {
        Task<Result> CreateNotification(NotificationModel model);
        Task<List<NotificationDto>> GetNotifications();
        Task<List<MobileDeviceDto>> GetDevices();
        Task<ResponseModel> SendNotification(FCMNotificationModel notificationModel);
        Task<Result> CreateNotificationManually(NotificationModel model);
    }
}
