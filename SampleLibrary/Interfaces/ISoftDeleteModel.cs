using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleLibrary.Interfaces
{
    public interface ISoftDeleteModel
    {
        bool IsDeleted { get; set; }
    }
}
