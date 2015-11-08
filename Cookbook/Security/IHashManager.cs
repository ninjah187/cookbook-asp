using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace Cookbook.Security
{
    public interface IHashManager
    {
        string GetHash(string text);
        string GetHash(string text, Encoding encoding);
        bool AreTheSame(string text1, string text2);
    }
}