using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cookbook.Security
{
    public interface IKeySaltPair
    {
        string Key { get; }
        string Salt { get; }
    }
}
