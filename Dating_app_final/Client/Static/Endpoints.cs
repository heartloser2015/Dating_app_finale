using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dating_app_final.Client.Static
{
    public static class Endpoints
    {
        private static readonly string Prefix = "api";

        public static readonly string MatchesEndPoint = $"{Prefix}/matches";
        public static readonly string MembershipsEndPoint = $"{Prefix}/memberships";
        public static readonly string MessagesEndPoint = $"{Prefix}/messages";
        public static readonly string PaymentsEndPoint = $"{Prefix}/payments";
        public static readonly string ProfilesEndPoint = $"{Prefix}/profiles";
        public static readonly string LocationsEndPoint = $"{Prefix}/locations";
        public static readonly string NotifiesEndPoint = $"{Prefix}/notifies";
        public static readonly string BlockedUsersEndPoint = $"{Prefix}/blockedusers";
        public static readonly string UsersEndPoint = $"{Prefix}/users";


    }
}
