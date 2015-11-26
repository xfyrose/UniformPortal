using System;
using System.Security.Principal;
using Util.Core;
using Util.Core.Extensions;

namespace Util.Security
{
    public class Identity : IIdentity
    {

        public Identity(bool isAuthenticated, string userId, string[] roleIds = null, string appliationId = "", string tenantId = "")
        {
            IsAuthenticated = isAuthenticated;
            Name = userId;
            RoleIds = roleIds;
            ApplicationId = appliationId;
            TenantId = tenantId;
        }

        public Identity()
            : this(false, string.Empty)
        {

        }

        public string AuthenticationType => "Custom";

        public bool IsAuthenticated { get; private set; }

        public string Name { get; private set; }

        public string UserId => Name;

        public string[] RoleIds { get; private set; }

        public string FullName { get; set; }
        public string Role { get; set; }
        public string ApplicationId { get; set; }
        public string ApplicationCode { get; set; }
        public string Application { get; set; }
        public string TenantId { get; set; }

        public string TenantCode { get; set; }
        public string Tenant { get; set; }
        public string Skin { get; set; }
        public string MenuStyle { get; set; }

        public bool Validate()
        {
            if (!IsAuthenticated)
            {
                return false;
            }

            if (UserId.ToGuid() == Guid.Empty)
            {
                return false;
            }

            return true;
        }

        public static UnauthenticatedIdentity Unauthenticated()
        {
            return new UnauthenticatedIdentity();
        }
    }
}