using CorePush.Google;
using Dapper;
using Erp.Application.Common.Interfaces;
using Erp.Application.Common.Models;
using Erp.Application.Common.Notifications;
using Erp.Domain.Entities.Common;
using Erp.Domain.Entities.Common.NotificationForMobile;
using Erp.Infrastructure.Persistence;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using System.Net.Http;
using System.Net.Http.Headers;
using static Erp.Domain.Entities.Common.NotificationForMobile.GoogleNotification;

namespace Erp.Infrastructure.Services.ErpApp.Notifications
{
    public class NotificationService : DbContext<NotificationModel>, INotifications
    {
        private readonly ICurrentUserService _currentUserService;
        private readonly ApplicationDbContext _context;
        private readonly FcmNotificationSetting _fcmNotificationSetting;
        public NotificationService(IConfiguration configuration, ICurrentUserService currentUserService, ApplicationDbContext context, IOptions<FcmNotificationSetting> settings) : base(configuration)
        {
            _currentUserService = currentUserService;
            _context = context;
            _fcmNotificationSetting = settings.Value;
        }

        public async Task<Result> CreateNotification(NotificationModel model)
        {
            string query = "PRO_NOTIFICATIONS_SAVE";

            DynamicParameters parameters = new DynamicParameters();

            parameters.Add("P_ID", model.Id, DbType.Int32, ParameterDirection.Input);
            parameters.Add("P_NOTIFICATION_TYPE_ID", model.NotificationTypeId, DbType.Int32, ParameterDirection.Input);
            parameters.Add("P_USER_TYPE_ID", model.UserTypeId, DbType.Int32, ParameterDirection.Input);
            parameters.Add("P_FROM_USER_ID", _currentUserService.EmployeeId, DbType.String, ParameterDirection.Input);
            parameters.Add("P_NOTIFICATION_HEADER", model.NotificationHeader, DbType.Int32, ParameterDirection.Input);
            parameters.Add("P_NOTIFICATION_BODY", model.NotificationBody, DbType.String, ParameterDirection.Input);
            parameters.Add("P_CREATED_BY", _currentUserService.EmployeeId, DbType.String, ParameterDirection.Input);
            parameters.Add("P_HEAD_OFFICE_ID", _currentUserService.HeadOfficeId, DbType.Int32, ParameterDirection.Input);
            parameters.Add("P_BRANCH_OFFICE_ID", _currentUserService.BranchOfficeId, DbType.Int32, ParameterDirection.Input);
            parameters.Add("P_MESSAGE", "", DbType.String, ParameterDirection.Output);

            return await SetDisposeErrorFreeSingleAsync(query, parameters);
        }
        public async Task<Result> CreateNotificationManually(NotificationModel model)
        {
            string query = "PRO_NOTIFICATIONS_SAVE_MANUALLY";

            DynamicParameters parameters = new DynamicParameters();

            parameters.Add("P_ID", model.Id, DbType.Int32, ParameterDirection.Input);
            parameters.Add("P_NOTIFICATION_TYPE_ID", model.NotificationTypeId, DbType.Int32, ParameterDirection.Input);
            parameters.Add("P_USER_TYPE_ID", model.UserTypeId, DbType.Int32, ParameterDirection.Input);
            parameters.Add("P_FROM_USER_ID", _currentUserService.EmployeeId, DbType.String, ParameterDirection.Input);
            parameters.Add("P_TO_USER_ID", model.ToUserId, DbType.String, ParameterDirection.Input);
            parameters.Add("P_NOTIFICATION_HEADER", model.NotificationHeader, DbType.String, ParameterDirection.Input);
            parameters.Add("P_NOTIFICATION_BODY", model.NotificationBody, DbType.String, ParameterDirection.Input);


            parameters.Add("P_CREATED_BY", _currentUserService.EmployeeId, DbType.String, ParameterDirection.Input);
            parameters.Add("P_HEAD_OFFICE_ID", _currentUserService.HeadOfficeId, DbType.Int32, ParameterDirection.Input);
            parameters.Add("P_BRANCH_OFFICE_ID", _currentUserService.BranchOfficeId, DbType.Int32, ParameterDirection.Input);
            parameters.Add("P_MESSAGE", "", DbType.String, ParameterDirection.Output);
            return await SetDisposeErrorFreeSingleAsync(query, parameters);
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public async Task<List<MobileDeviceDto>> GetDevices()
        {
            string query = " SELECT * FROM vew_L_USER_DEVICE";

            var Notifications = await GetDisposeErrorFreeListAsync<MobileDeviceDto>(query, null);

            return Notifications.ToList();
        }

        public async Task<List<NotificationDto>> GetNotifications()
        {
            string query = " SELECT * FROM VEW_NOTIFICATIONS where IS_READ=0 AND TO_USER_ID = " + _currentUserService.UserId;

            var Notifications = await GetDisposeErrorFreeListAsync<NotificationDto>(query, null);

            return Notifications.ToList();
        }

        public async Task<ResponseModel> SendNotification(FCMNotificationModel notificationModel)
        {
            ResponseModel response = new ResponseModel();
            try
            {
                /* FCM Sender (Android Device) */
                FcmSettings settings = new FcmSettings()
                {
                    SenderId = _fcmNotificationSetting.SenderId,
                    ServerKey = _fcmNotificationSetting.ServerKey
                };
                HttpClient httpClient = new HttpClient();

                string authorizationKey = string.Format("keyy={0}", settings.ServerKey);
                string deviceToken = notificationModel.DeviceId;

                httpClient.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", authorizationKey);
                httpClient.DefaultRequestHeaders.Accept
                        .Add(new MediaTypeWithQualityHeaderValue("application/json"));

                DataPayload dataPayload = new DataPayload();
                dataPayload.Title = notificationModel.Title;
                dataPayload.Body = notificationModel.Body;

                GoogleNotification notification = new GoogleNotification();
                notification.Data = dataPayload;
                notification.Notification = dataPayload;

                var fcm = new FcmSender(settings, httpClient);
                var fcmSendResponse = await fcm.SendAsync(deviceToken, notification);

                if (fcmSendResponse.IsSuccess())
                {
                    response.IsSuccess = true;
                    response.Message = "Notification sent successfully";
                    return response;
                }
                else
                {
                    response.IsSuccess = false;
                    response.Message = fcmSendResponse.Results[0].Error;
                    return response;
                }


            }
            catch (Exception)
            {
                response.IsSuccess = false;
                response.Message = "Something went wrong";
                return response;
            }
        }
    }
}

