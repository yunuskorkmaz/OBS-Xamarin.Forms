using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBS.API
{
    public class WebService
    {

        private string time
        {
            get
            {
                long ticks = DateTime.UtcNow.Ticks - DateTime.Parse("01/01/1970 00:00:00").Ticks;
                ticks /= 10000000;
                return ticks.ToString();
            }
            set { time = value; }
        }

        public static bool CheckConnection()
        {
            return CrossConnectivity.Current.IsConnected;
        }

        public async Task<ResultData<Student>> OturumAc(string k, string s)
        {
            ResultData<Student> result;

            if (CheckConnection() == false)
            {
                result = new ResultData<Student>()
                {
                    Message = "İnternet Bağlantısı Gerekli",
                    Result = false,
                    Data = null
                };
                return result;
            }

            k.Trim();
            s.Trim();
            await Task.Delay(0);
            string url = "http://meuoibs.16mb.com/index.php?kullaniciAdi=" + k + "&sifre=" + s;
            HttpClient client = await getClient();
            var response = await client.GetStringAsync(url);


            try
            {
                result = JsonConvert.DeserializeObject<ResultData<Student>>(response);
                result.Data.Sifre = s;
            }
            catch (Exception)
            {
                result = new ResultData<Student>()
                {
                    Message = "Bir Hata Oluştu Tekrar Deneyiniz.",
                    Result = false,
                    Data = null
                };

            }
            return result;
        }

        public async Task<ResultData<YariyilModel>> Yariyillar()
        {
            ResultData<YariyilModel> result;
            if (CheckConnection() == false)
            {
                result = new ResultData<YariyilModel>()
                {
                    Message = "İnternet Bağlantısı Gerekli",
                    Result = false,
                    Data = null
                };
                return result;
            }

            string url = "http://meuoibs.16mb.com/yariyillar.php?kullaniciAdi=" + App.User.OgrenciNo + "&sifre=" + App.User.Sifre;
            HttpClient client = await getClient();
            var response = await client.GetStringAsync(url);


            try
            {
                result = new ResultData<YariyilModel>();
                var model = JsonConvert.DeserializeObject<YariyilModel>(response);
                if (model.Success == true)
                {
                    result.Message = "Başarılı";
                    result.Result = true;
                    result.Data = model;
                }
                else
                {
                    result.Message = "Hata Oluştu";
                    result.Result = false;
                }
            }
            catch (Exception)
            {
                result = new ResultData<YariyilModel>()
                {
                    Message = "Bir Hata Oluştu Tekrar Deneyiniz.",
                    Result = false,
                    Data = null
                };

            }

            return result;
        }

        public async Task<ResultData<List<SinavSonucModel>>> SinavSonuclari(YariYilDonem Donem)
        {
            ResultData<List<SinavSonucModel>> result;
            if (CheckConnection() == false)
            {
                result = new ResultData<List<SinavSonucModel>>()
                {
                    Message = "İnternet Bağlantısı Gerekli",
                    Result = false,
                    Data = null
                };
                return result;
            }

            string url = "http://meuoibs.16mb.com/sinavsonuclari.php?a=" + App.User.OgrenciNo + "&b=" + App.User.Sifre + "&c=" + Donem.ID;
            HttpClient client = await getClient();
            var response = await client.GetStringAsync(url);


            try
            {
                result = new ResultData<List<SinavSonucModel>>();
                var model = JsonConvert.DeserializeObject<List<SinavSonucModel>>(response);
                if (model.Count > 0)
                {
                    result.Message = "Başarılı";
                    result.Result = true;
                    result.Data = model;
                }
                else
                {
                    result.Message = "Hata Oluştu";
                    result.Result = false;
                }
            }
            catch (Exception)
            {
                result = new ResultData<List<SinavSonucModel>>()
                {
                    Message = "Bir Hata Oluştu Tekrar Deneyiniz.",
                    Result = false,
                    Data = null
                };

            }

            return result;
        }

        public async Task<ResultData<List<ProgramModel>>> DersProgrami()
        {
            var result = new ResultData<List<ProgramModel>>();
            if (CheckConnection() == false)
            {
                result = new ResultData<List<ProgramModel>>()
                {
                    Message = "İnternet Bağlantısı Gerekli",
                    Result = false,
                    Data = null
                };
                return result;
            }







            string url = "http://meuoibs.16mb.com/dersprogrami.php?a=" + App.User.OgrenciNo + "&b=" + App.User.Sifre;

            HttpClient client = await getClient();
            var response = await client.GetStringAsync(url);


            try
            {
                var model = JsonConvert.DeserializeObject<List<ProgramModel>>(response);
                result.Result = true;
                result.Message = "Başarılı";
                result.Data = model;
            }
            catch (Exception e)
            {
                result.Result = false;
                result.Message = e.Message;
                result.Data = null;
            }

            return result;
        }
        public async Task<ResultData<List<DuyuruModel>>> Duyurular()
        {
            ResultData<List<DuyuruModel>> result;
            if (CheckConnection() == false)
            {
                result = new ResultData<List<DuyuruModel>>()
                {
                    Message = "İnternet Bağlantısı Gerekli",
                    Result = false,
                    Data = null
                };
                return result;
            }

            string url = "http://meuoibs.16mb.com/duyurular.php?a=" + App.User.OgrenciNo + "&b=" + App.User.Sifre;
            HttpClient client = await getClient();
            var response = await client.GetStringAsync(url);

            try
            {
                result = JsonConvert.DeserializeObject<ResultData<List<DuyuruModel>>>(response);
            }
            catch (Exception)
            {
                result = new ResultData<List<DuyuruModel>>()
                {
                    Message = "Bir Hata Oluştu Tekrar Deneyiniz.",
                    Result = false,
                    Data = null
                };
            }
            return result;
        }
        public async Task<ResultData<List<BasariTakipModel>>> Basari()
        {
            ResultData<List<BasariTakipModel>> result;
            if (CheckConnection() == false)
            {
                result = new ResultData<List<BasariTakipModel>>()
                {
                    Message = "İnternet Bağlantısı Gerekli",
                    Result = false,
                    Data = null
                };
                return result;
            }
            string url = "http://meuoibs.16mb.com/basari.php?a=" + App.User.OgrenciNo + "&b=" + App.User.Sifre;
            HttpClient client = await getClient();
            var response = await client.GetStringAsync(url);

            try
            {
                result = JsonConvert.DeserializeObject<ResultData<List<BasariTakipModel>>>(response);
            }
            catch (Exception)
            {
                result = new ResultData<List<BasariTakipModel>>()
                {
                    Message = "Bir Hata Oluştu Tekrar Deneyiniz.",
                    Result = false,
                    Data = null
                };

            }
            return result;
        }

        public async Task<ResultData<OrtalamaModel>> Ortalama()
        {
            ResultData<OrtalamaModel> result;
            if (CheckConnection() == false)
            {
                result = new ResultData<OrtalamaModel>()
                {
                    Message = "İnternet Bağlantısı Gerekli",
                    Result = false,
                    Data = null
                };
                return result;
            }
            string url = "http://meuoibs.16mb.com/ortalama.php?a=" + App.User.OgrenciNo + "&b=" + App.User.Sifre;
            HttpClient client = await getClient();
            var response = await client.GetStringAsync(url);

            try
            {
                result = JsonConvert.DeserializeObject<ResultData<OrtalamaModel>>(response);
            }
            catch (Exception)
            {
                result = new ResultData<OrtalamaModel>()
                {
                    Message = "Bir Hata Oluştu Tekrar Deneyiniz.",
                    Result = false,
                    Data = null
                };

            }
            return result;
        }


        private async Task<HttpClient> getClient()
        {
            HttpClient client = new HttpClient();
            await Task.Delay(0);
            client.DefaultRequestHeaders.Add("Accept", "application/json");


            return client;
        }
    }
}
