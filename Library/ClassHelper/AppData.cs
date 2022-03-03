using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.ClassHelper
{
    class AppData
    {
        public static EF.LibraryEntities Context { get; } = new EF.LibraryEntities();
    }
}
