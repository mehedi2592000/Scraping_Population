using Data_Access_Layer.DL_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Logic_Layer.BL_Interface
{
    public  interface IBLAllDataModelRepository
    {
        public Task<List<AllData>> GetBlAllDataList();

        public Task<List<AllData>> GetPopulationData();


        public Task<List<AllData>> GetPaginationData(int Pagenumber);
    }
}
