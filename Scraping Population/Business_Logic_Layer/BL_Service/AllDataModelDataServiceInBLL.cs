using Business_Logic_Layer.BL_Interface;
using cloudscribe.HtmlAgilityPack;
using Data_Access_Layer.DL_Interface;
using Data_Access_Layer.DL_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Business_Logic_Layer.BL_Service
{
    public  class AllDataModelDataServiceInBLL: IBLAllDataModelRepository
    {

        public readonly IDLAllDataModelRepository idalAllData;

        public AllDataModelDataServiceInBLL(IDLAllDataModelRepository idalAllData)
        {
            this.idalAllData = idalAllData;
        }

       

        public async Task<List<AllData>> GetBlAllDataList()
        {
            return await idalAllData.AllDataList();
        }

        public async Task<List<AllData>> GetPopulationData()
        {

            List<AllData> populationDataList = new List<AllData>();

            // Make an HTTP request to the Wikipedia page
            var web = new HtmlWeb();
            var document = web.Load("https://en.wikipedia.org/wiki/World_population");


            var tableNode = document.DocumentNode.SelectSingleNode("//*[@id=\"mw-content-text\"]/div[1]/table[5]");
            var rows = tableNode.SelectNodes(".//tr");

            Regex r = new Regex(@"[^a-zA-Z]");




            foreach (var row in rows)
            {
                var cells = row.SelectNodes(".//td");
                if (cells != null && cells.Count >= 2)
                {

                    var vf = cells;
                    //var bb = cells[0].InnerHtml;
                    var Country = r.Replace(cells[0].InnerText, "");
                    var population = cells[1].InnerText;
                    var Percentage = cells[2].InnerText;
                    var Date = DateTime.Parse(cells[3].InnerText);
                    var Source = cells[4].InnerText;


                    var populationData = new AllData
                    {
                        Country = Country,
                        Population = population,
                        Percentage= Percentage,
                        Date= Date,
                        Source= Source

                    };

                    populationDataList.Add(populationData);
                }
            }


            List<AllData> CareateOrUpdatePopulationData = await AddCareateOrUpdatePopulationData(populationDataList);

           

           

            return CareateOrUpdatePopulationData;
        }


        public async Task<List<AllData>> AddCareateOrUpdatePopulationData(List<AllData> populationDataList)
        {

            try
            {
                List<AllData> AllDataList = await idalAllData.AllDataList();

               

                if (AllDataList.Count == 0)
                {

                    AllDataList = await CreatePopulationData(populationDataList);

                }
               

                return AllDataList;
            }
            catch (Exception ex)
            {
                 throw ex;
            }
        }


        public async Task<List<AllData>> CreatePopulationData(List<AllData> populationDataList)
        {
            try
            {

                foreach (AllData item in populationDataList)
                {

                    AllData allData = new AllData();
                    allData.Country = item.Country;
                    allData.Population = item.Population;
                    allData.Source = item.Source;
                    allData.Percentage = item.Percentage;
                    allData.Date = item.Date;

                    await idalAllData.CreateData(allData);
                }

                return populationDataList;
            }
            catch(Exception ex) {
                throw ex;
            }
        }


        public async Task<List<AllData>> GetPaginationData(int Pagenumber)
        {
            try {
                int totalPagePerView = 4;
                List<AllData> TotalList = await idalAllData.AllDataList();
                List<AllData> returndata = TotalList.Skip((Pagenumber-1)*totalPagePerView).Take(totalPagePerView).ToList();

                return returndata;

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


    }
}
