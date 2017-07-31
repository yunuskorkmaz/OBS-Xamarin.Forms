using OBS.DBModels;
using OBS.Interface;
using OBS.Models;
using SQLite.Net;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;
using System;
using OBS.API;
using Newtonsoft.Json;

namespace OBS.Service
{

    public class ProgramService
    {
        SQLiteConnection _sqlconnection;
        public ProgramService()
        {
            _sqlconnection = DependencyService.Get<IConnect>().GetConnection();
            _sqlconnection.CreateTable<DbProgram>();
        }

        public async Task<ResultData<List<ProgramModel>>> GetProgram()
        {
            var kontrol = _sqlconnection.Table<DbProgram>().Count();

            if(kontrol < 1)
            {
                return await GetFromWebService();
            }
            else
            {
                return await GetFromDb();
            }
        }

        private async Task<ResultData<List<ProgramModel>>> GetFromDb()
        {
            var hata = new ResultData<List<ProgramModel>>() { Result = false, Message = "Hata" };
            try
            {
                var record = _sqlconnection.Table<DbProgram>().FirstOrDefault();

                if ((record.Date - DateTime.Now).TotalDays > 2)
                {
                    var webservice = new WebService();
                    var result = await webservice.DersProgrami();

                    if (result.Result == false) { return hata; }
                    else
                    {
                        _sqlconnection.Delete(record.ID);
                        var ekle = _sqlconnection.Insert(new DbProgram() { Data = result.Data, Date = DateTime.Now, });

                        var item = _sqlconnection.Get<DbProgram>(a => a.ID == ekle);
                        var serialize = JsonConvert.DeserializeObject<List<ProgramModel>>(item.Data);
                        return new ResultData<List<ProgramModel>>()
                        {
                            Data = serialize,
                            Result = true
                        };
                    }

                }
                else
                {
                    var serialize = JsonConvert.DeserializeObject<List<ProgramModel>>(record.Data);

                    return new ResultData<List<ProgramModel>>
                    {
                        Result = true,
                        Data = serialize

                    };
                }

                }
                catch (Exception ex)
                {
                    return new ResultData<List<ProgramModel>>
                    {
                        Message = "Hata Oluştu " + ex.Message,
                        Result = false
                    };
                }
        }

        private async Task<ResultData<List<ProgramModel>>> GetFromWebService()
        {
            try
            {
                var webservice = new WebService();
                var result = await webservice.DersProgrami();

                if(result.Result == false)
                {
                    var item = _sqlconnection.Table<DbProgram>().FirstOrDefault();
                    if(item != null)
                    {
                        var serialize = JsonConvert.DeserializeObject<List<ProgramModel>>(item.Data);
                        return new ResultData<List<ProgramModel>>()
                        {
                            Data = serialize,
                            Result = true
                        };
                    }
                    else
                    {
                        return new ResultData<List<ProgramModel>>()
                        {
                            Result = false,
                            Message = "İnternet Bağlantısı Gerekli"
                        };
                    }
                }
                else
                {
                    var ekle = _sqlconnection.Insert(new DbProgram() { Data = result.Data, Date = DateTime.Now, });

                    var item = _sqlconnection.Get<DbSinavSonuc>(a => a.ID == ekle);
                    var serialize = JsonConvert.DeserializeObject<List<ProgramModel>>(item.Data);
                    return new ResultData<List<ProgramModel>>()
                    {
                        Data = serialize,
                        Result = true
                    };
                }

            }
            catch (Exception ex)
            {
                return new ResultData<List<ProgramModel>>()
                {
                    Result = false,
                    Message = ex.Message
                };
            }
        }
    }
}
