using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Adams.RepositoryService.Server
{
    public class Auth
    {
    }

    public static class PolicyNames
    {
        public const string MemberOrAdmin = "MemberOrAdmin";
        public const string AdminOnly = "AdminOnly";
    }

    public static class ClaimNames
    {
        public const string Member = "Member";
        public const string Admin = "Admin";
    }
}
