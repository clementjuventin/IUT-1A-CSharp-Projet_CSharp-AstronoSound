using AstronoSound;
using System;
using System.Collections.Generic;
using System.Text;

namespace Modele
{
    public static class GetTheCurrent
    {
        private static Manager mgr = new Manager();
        public static Manager Mgr { get { return mgr; } private set { mgr = value; } }
    }
}
