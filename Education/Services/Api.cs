using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace Education.Services
{
    public class Api
    {
        public static HttpClient httpClient = new HttpClient();

        public const string DOMAIN_URL = "https://education-erp.com/api/ClientApplication/";
        public static string NEWS_URL = $"{DOMAIN_URL}News?schoolType=Football&cityId=4&count=10";

        public static string ApiError;

        public static async Task<T> Get<T>(string url){
            var res = default(T);
            ApiError = "";
            try
            {
                var json = await httpClient.GetStringAsync(new Uri(url));
                //Debug.WriteLine($"Api Get json => {json}");
                res = JsonConvert.DeserializeObject<T>(json);
            } catch (Exception ex)
            {
                ApiError = "Что-то пошло не так! Проверьте соединение с интернетом";
                Debug.WriteLine($"Api Get err => {ex.Message}");
                return res;
            }
            Debug.WriteLine($"Get {url} {res}");
            return res;
        }
    }
}

