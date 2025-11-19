using System;
using System.Collections.Generic;
using System.Text;

namespace Erp.Application.Auth.RoleManagement
{
    public class CreateMenuPermisionDto
    {

        public int Id { get; set; }
        public string Title { get; set; }
        public int Master_Parent_Id { get; set; }
        public int ParentId { get; set; }
        public string ParentName { get; set; }
        public bool Active { get; set; }
        public string Active_YN { get; set; }
        public int SortOrder { get; set; }
        public string Path { get; set; }
        public string Remarks { get; set; }
        public string Icon { get; set; }
        public string Type { get; set; }
        public bool IsSelected { get; set; }
        public int UserId { get; set; }
        public int PendingTask { get; set; }
        public int Menu_Id { get; set; }
        public string Menu_Name { get; set; }
        public int Parent_Menu_Id { get; set; }
        public string Routing_Name { get; set; }
        public string Component_Name { get; set; }
        public string Page_link { get; set; }
        public int Step_No { get; set; }
        public int Priority { get; set; }
        public string CreateBy { get; set; }
        public List<AppUserDataPermissionDto> AppUserDataPermissionList { get; set; }

    }


    //public class CreateMenuPermisionObj
    //{
    //    public int Menu_Id { get; set; }
    //    public string Menu_Name { get; set; }
    //    public string Routing_Name { get; set; }
    //    public string Component_Name { get; set; }
    //    public string Page_link { get; set; }
    //    public int Parent_Menu_Id { get; set; }
    //    public bool Is_Active { get; set; }
    //    public int Step_No { get; set; }
    //    public string Remarks { get; set; }
    //    public string Icon { get; set; }
    //    public string Type { get; set; }
    //    public bool IsSelected { get; set; }
    //    public int UserId { get; set; }
    //    public string BadgeType { get; set; }
    //}
    public class CreateMenuPermisionObj
    {
        public int Menu_Id { get; set; }
        public string Menu_Name { get; set; }
        public string Routing_Name { get; set; }
        public string Component_Name { get; set; }
        public string Page_link { get; set; }
        public int Parent_Menu_Id { get; set; }
        public bool Is_Active { get; set; }
        public int Step_No { get; set; }
        public string Remarks { get; set; }
        public string Icon { get; set; }
        public string Type { get; set; }
        public bool IsSelected { get; set; }
        public int UserId { get; set; }
        public string BadgeType { get; set; }

        // 👇 New property for children
        public List<CreateMenuPermisionObj> Children { get; set; } = new List<CreateMenuPermisionObj>();
    }
}
