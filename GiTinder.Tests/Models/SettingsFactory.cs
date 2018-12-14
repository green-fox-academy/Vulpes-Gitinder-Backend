using GiTinder.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GiTinder.Tests.Models
{
    class SettingsFactory
    {

        public Settings CreateSettings()
        {

            return new Settings()
            {
                UserName = "Filip Eager",
            };


        }


    }
}
