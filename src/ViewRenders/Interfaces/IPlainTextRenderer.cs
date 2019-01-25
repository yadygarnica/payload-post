using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PayloadPost.ViewRenders.Interfaces
{
    public interface IPlainTextContentRenderer
    {
        string RenderModelToString(object model);
    }
}
