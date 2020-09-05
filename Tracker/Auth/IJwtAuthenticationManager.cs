using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tracker.Auth
{
    public interface IAuthenticationManager
    {
        string Authenticate(string username, string password);
    }
}
