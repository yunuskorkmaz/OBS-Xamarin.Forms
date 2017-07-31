using Newtonsoft.Json;
using OBS.API;
using OBS.DBMOdels;
using OBS.Interface;
using OBS.Models;
using SQLite.Net;
using System;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace OBS.Service
{
    public class YariyilService
    {
        SQLiteConnection _sqlconnection;
        public YariyilService()
        { 
            _sqlconnection = DependencyService.Get<IConnect>().GetConnection();
            _sqlconnection.CreateTable<DbYariyil>();
        }

        public async Task<ResultData<YariyilModel>> GetYariyillar()
        {
            var kontrol = _sqlconnection.Table<DbYariyil>().Count();

            if(kontrol < 1)
            {
                // web servise git
                return  await GetFromWebservice();
            }
            else
            {
                return await GetFromDb();
            }
        }

        private async  Task<ResultData<YariyilModel>> GetFromDb()
        {
            var record = _sqlconnection.Table<DbYariyil>().LastOrDefault();
            var a = DateTime.Now - record.Date; 
           

            if (a.TotalDays > 3)
            {
                return await GetFromWebservice();
            }
            else
            {
                var resultData = JsonConvert.DeserializeObject<YariyilModel>(record.Data);
                return new ResultData<YariyilModel>() { Data = resultData, Result = true, Message = "Veritabanı" };
            }
     
        }

        private async Task<ResultData<YariyilModel>> GetFromWebservice()
        {
            var webservice = new WebService();

            var apiresult = await webservice.Yariyillar();
            if (apiresult.Result)
            {
                var tostring = JsonConvert.SerializeObject(apiresult.Data);

                _sqlconnection.DeleteAll<DbYariyil>();
                _sqlconnection.Insert(new DbYariyil() {Data =tostring,Date=DateTime.Now });
                apiresult = await GetFromDb();
            }
            return apiresult;
        }

    }
}
