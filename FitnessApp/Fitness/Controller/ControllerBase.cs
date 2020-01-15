using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Fitness.Controller
{
    public abstract class ControllerBase
    {
        protected ISaver saver = new SerialiseISaver();
        protected ISaver saver2 = new DataBaseSaver();
        protected void Save(string fileName, object item)
        {
            saver.Save(fileName, item);
            saver2.Save(fileName, item);
        }

        protected T Load<T>(string fileName)where T: class
        {
            return saver.Load<T>(fileName);
        }


    }
}
