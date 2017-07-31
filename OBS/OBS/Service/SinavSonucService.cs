using Newtonsoft.Json;
using OBS.API;
using OBS.DBModels;
using OBS.Interface;
using OBS.Models;
using SQLite.Net;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace OBS.Service
{
    public class SinavSonucService
    {
        SQLiteConnection _sqlconnection;
        YariYilDonem Donem;
        public SinavSonucService()
        {
            _sqlconnection = DependencyService.Get<IConnect>().GetConnection();
            _sqlconnection.CreateTable<DbSinavSonuc>();
        }

        public async Task<ResultData<List<SinavSonucModel>>> GetSinavSonuc(YariYilDonem donem)
        {
            this.Donem = donem;
            var kontrol = _sqlconnection.Table<DbSinavSonuc>().Where(a => a.YariyilID == donem.ID).Count();

            if (kontrol < 1)
            {
                // web servise git
                return await GetFromWebservice();
            }
            else
            {
                return await GetFromDb();
            }
        }

       

        private async Task<ResultData<List<SinavSonucModel>>> GetFromDb()
        {
            var hata = new ResultData<List<SinavSonucModel>>() { Result = false, Message = "Hata" };
            try
            {
                var record = _sqlconnection.Get<DbSinavSonuc>(a => a.YariyilID == Donem.ID);

                if((record.Date - DateTime.Now).TotalDays > 2)
                {
                    var webservice = new WebService();
                    var result = await webservice.Sinavlar(Donem);

                    if(result.Result == false) { return hata; }
                    else
                    {
                        _sqlconnection.Delete(record.ID);
                        var ekle = _sqlconnection.Insert( new DbSinavSonuc(){Data = result.Data, YariyilID = Donem.ID,Date = DateTime.Now, } );

                        var item = _sqlconnection.Get<DbSinavSonuc>(a => a.ID == ekle);
                        var serialize = JsonConvert.DeserializeObject<List<SinavSonucModel>>(item.Data);
                        return new ResultData<List<SinavSonucModel>>()
                        {
                            Data = serialize,
                            Result = true
                        };
                    }

                }
                else
                {
                    var serialize = JsonConvert.DeserializeObject<List<SinavSonucModel>>(record.Data);

                    return new ResultData<List<SinavSonucModel>>
                    {
                        Result = true,
                        Data = serialize

                    };
                }

                

            }
            catch(Exception ex)
            {
                return new ResultData<List<SinavSonucModel>>
                {
                    Message = "Hata Oluştu " + ex.Message,
                    Result = false
                };
            }
        }

        private async Task<ResultData<List<SinavSonucModel>>> GetFromWebservice()
        {
            var hata = new ResultData<List<SinavSonucModel>>() { Result = false, Message = "Hata Oluştu" };
            try
            {
                var webservice = new WebService();
                var result = await webservice.Sinavlar(Donem);


                if (result.Result == false)
                {
                    var item = _sqlconnection.Get<DbSinavSonuc>(a => a.YariyilID == Donem.ID);
                    if(item != null)
                    {
                        var serialize = JsonConvert.DeserializeObject<List<SinavSonucModel>>(item.Data);
                        return new ResultData<List<SinavSonucModel>>()
                        {
                            Data = serialize,
                            Result = true
                        };
                    }
                    else
                    {
                        return new ResultData<List<SinavSonucModel>>()
                        {
                            Result = false,
                            Message = "İnternet Bağlantısı Gerekli"
                        };
                    }
                   
                }
                else
                {

                    var ekle = _sqlconnection.Insert(new DbSinavSonuc() { Data = result.Data, YariyilID = Donem.ID, Date = DateTime.Now, });

                    var item = _sqlconnection.Get<DbSinavSonuc>(a => a.ID == ekle);
                    var serialize = JsonConvert.DeserializeObject<List<SinavSonucModel>>(item.Data);
                    return new ResultData<List<SinavSonucModel>>()
                    {
                        Data = serialize,
                        Result = true
                    };
                }


            }
            catch (Exception ex)
            {
                return new ResultData<List<SinavSonucModel>>
                {
                    Result = false,
                    Message = ex.Message
                };
            }
           
        }
    }

    
}
