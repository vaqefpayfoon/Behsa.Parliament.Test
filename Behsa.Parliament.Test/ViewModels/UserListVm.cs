using System;
using System.Collections.Generic;
using System.Text;

namespace Behsa.Parliament.Test.ViewModels
{
    public class UsersListVm
    {
        public UsersListVm()
        {
            Users = new List<UserEditVm>();
        }
        public int AllUsersCount { get; set; }
        public int CurrentUsersCount { get; set; }
        public IList<UserEditVm> Users { get; set; }
    }
    public class UserEditVm
    {

        public UserEditVm()
        {
            IsDisabled = true;//برای امنیت بیشتر
            //Roles = new List<string>();
        }

        public Guid UserId { get; set; }
        //public Guid EmployeeId { get; set; } //for 154
        public string EmployeeId { get; set; } // for 60.4
        //public string DomainName { set; get; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; }
        //public string MobilePhone { get; set; }
        //public string InternalEmailAddress { get; set; }
        public bool IsDisabled { set; get; }
        public Guid ConstituencyId { get; set; }
        public string ConstituencyName { get; set; }
        //public List<string> Roles { get; set; }

    }
}
