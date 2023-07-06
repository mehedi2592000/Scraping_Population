using Business_Logic_Layer.BL_Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Scraping_Population.Controllers
{



    [Route("api/[controller]")]
    [ApiController]
    public class PopulationController : ControllerBase
    {

        public readonly IBLAllDataModelRepository iBLAllDataModel;

        public PopulationController(IBLAllDataModelRepository iBLAllDataModel)
        {
            this.iBLAllDataModel = iBLAllDataModel;
        }


        [Route("api/Population/GetAllData")]
        [HttpGet]
        public async Task<IActionResult> GetAllList()
        {
            try
            {
                return Ok(await iBLAllDataModel.GetBlAllDataList());
            }
            catch (Exception ex)
            {
                return BadRequest(new { Succeeded = false, Message = ex.Message });
            }
        }


        [Route("api/Population/GetPopulationData")]
        [HttpGet]
        public async Task<IActionResult> GetPopulationData()
        {
            try
            {
                return Ok(await iBLAllDataModel.GetPopulationData());

            }
            catch (Exception ex)
            {
                return BadRequest(new { Succeeded = false, Message = ex.Message });
            }
        }


       

        [Route("api/Population/GetPaginationData/{Pagenumber?}")]
        [HttpGet]
        public async Task<IActionResult> GetPaginationData(int Pagenumber)
        {
            try
            {
                
                return Ok(await iBLAllDataModel.GetPaginationData((int)Pagenumber));

            }
            catch (Exception ex)
            {
                return BadRequest(new { Succeeded = false, Message = ex.Message });
            }
        }

    }
}
