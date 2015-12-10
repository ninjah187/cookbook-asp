using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cookbook.Security
{
    public interface IKeySaltManager
    {
        IKeySaltPair GetKeyAndSalt(string input);
        bool Authenticate(string password, string key, string salt);
        bool Authenticate(string password, IKeySaltPair keySaltPair);
    }
}
