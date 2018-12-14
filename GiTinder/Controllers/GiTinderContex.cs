using System;
using System.Threading.Tasks;
using GiTinder.Models;

namespace GiTinder.Controllers
{
    public class GiTinderContex
    {
        public object Settings { get; internal set; }

        internal void SettingsAdd(Settings settings)
        {
            throw new NotImplementedException();
        }

        internal Task SaveChangesAsync()
        {
            throw new NotImplementedException();
        }
    }
}