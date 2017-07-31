using OBS.API;
using OBS.Interface;
using OBS.Models;
using OBS.Pages;
using SQLite.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace OBS.Service
{
    public class StudentService
    {
        SQLiteConnection _sqlconnection;
        public StudentService()
        {
            //TODO: not set intense 
            _sqlconnection = DependencyService.Get<IConnect>().GetConnection();
            _sqlconnection.CreateTable<Student>();
        }

        public bool CheckSession()
        {
            var count = _sqlconnection.Table<Student>().Count();
            if (count < 1)
                return false;
            else
                return true;
        }

        public ResultData<Student> GetUser()
        {
            var result = new ResultData<Student>(); 
            result.Data = _sqlconnection.Table<Student>().LastOrDefault();
            App.User = result.Data;
            return result;
        }

        public async Task<ResultData<Student>> OturumAc(string numara, string sifre)
        {
            var manager = new WebService();
            var result = await manager.OturumAc(numara, sifre);
            
            if(result.Result == true)
            {
                _sqlconnection.Insert(result.Data);
                result.Data =  _sqlconnection.Table<Student>().LastOrDefault();
                return result;
            }
            else
            {
                return result;
            }

        }

        public void Logout()
        {
            _sqlconnection.DeleteAll<Student>();
            App.User = null;
            Application.Current.MainPage = new LoginPage();

            
        }
    }
}
