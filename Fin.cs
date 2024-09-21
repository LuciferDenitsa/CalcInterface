using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalcInterface
{
    public class Fin1 : IFin
    {
        ILogger Logger { get; }
        public Fin1 (ILogger logger)
        {
            Logger = logger;
        }

        public void Fin()
        {
            Logger.Event("Суммирование завершено");
        }
    }
}
