using Data_Access_Layer.DL_Interface;
using Data_Access_Layer.DL_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access_Layer.DL_Service
{
    public class AllDataModelDataInDB: IDLAllDataModelRepository
    {
        public readonly ApplicationDbContext _Context;

        public AllDataModelDataInDB(ApplicationDbContext context)
        {
            _Context = context;
        }

        public async Task<List<AllData>> AllDataList()
        {
            return _Context.AllDatas.ToList();
        }

        public async Task<AllData> CreateData(AllData data)
        {
            try
            {
                _Context.AllDatas.AddAsync(data);
                _Context.SaveChangesAsync();

                return data;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
