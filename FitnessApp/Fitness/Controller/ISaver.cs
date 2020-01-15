using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitness.Controller
{
    public interface ISaver
    {
        void Save(string fileName, object item);

        T Load<T>(string fileName) where T: class;

    }
}
