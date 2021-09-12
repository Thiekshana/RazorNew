using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Razor.Interfaces
{
    public interface IEventHandlerService
    {
        public Task postJson(string jsonData);
    }
}
