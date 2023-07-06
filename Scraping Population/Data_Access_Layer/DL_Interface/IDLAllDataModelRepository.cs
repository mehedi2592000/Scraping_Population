using Data_Access_Layer.DL_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access_Layer.DL_Interface
{
    public interface IDLAllDataModelRepository
    {

        public Task<List<AllData>> AllDataList();

        public Task<AllData> CreateData(AllData data);

       

    }
}
