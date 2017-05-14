using MIS442Store.DataLayer.DataModels;
using System;
using System.Web;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIS442Store.DataLayer.Interfaces
{
   public interface IStateRepository
    {
        List<USState> GetState();
    }
   
}
