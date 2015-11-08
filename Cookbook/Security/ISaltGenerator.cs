using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cookbook.Security
{
    public interface ISaltGenerator
    {
        string GetSaltUTF8(int saltLength); // probably it's not good to store salt in utf-8
        byte[] GetSalt(int saltLength);
    }
}
