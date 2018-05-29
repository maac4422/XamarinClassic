﻿namespace ServiceAccessLayer.Services
{
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Threading.Tasks;
    using Models.Models;
    using Newtonsoft.Json;
    using Plugin.Connectivity;

    public class ApiServices
    {
        public async Task<Response> CheckConnection()
        {
            if (!CrossConnectivity.Current.IsConnected)
            {
                return new Response
                {
                    IsSuccess = false,
                    Message = "Por favor enciende tu internet"
                };
            }

            var isReachable = await CrossConnectivity.Current.IsRemoteReachable("https://www.google.com");
            if (!isReachable)
            {
                return new Response
                {
                    IsSuccess = false,
                    Message = "Verifica tu coneccion a internet"
                };
            }

            return new Response
            {
                IsSuccess = true,
                Message = "Ok"
            };
        }

        public async Task<Response> Get<T>(
            string urlBase,
            string servicePrefix,
            string controller,
            int id)
        {
            try
            {
                var client = new HttpClient();
                client.BaseAddress = new Uri(urlBase);
                var url = string.Format(
                    "{0}{1}/{2}",
                    servicePrefix,
                    controller,
                    id);
                var response = await client.GetAsync(url);

                if (!response.IsSuccessStatusCode)
                {
                    return new Response
                    {
                        IsSuccess = false,
                        Message = response.StatusCode.ToString(),
                    };
                }

                var result = await response.Content.ReadAsStringAsync();
                var model = JsonConvert.DeserializeObject<T>(result);
                return new Response
                {
                    IsSuccess = true,
                    Message = "Ok",
                    Result = model,
                };
            }
            catch (Exception ex)
            {
                return new Response
                {
                    IsSuccess = false,
                    Message = ex.Message,
                };
            }
        }


        public async Task<Response> GetList<T>(
            string urlBase,
            string servicePrefix,
            string controller)
        {
            try
            {
                var client = new HttpClient();
                client.BaseAddress = new Uri(urlBase);
                var url = string.Format("{0}{1}", servicePrefix, controller);
                var response = await client.GetAsync(url);
                var result = await response.Content.ReadAsStringAsync();

                if (!response.IsSuccessStatusCode)
                {
                    return new Response
                    {
                        IsSuccess = false,
                        Message = result,
                    };
                }

                var list = JsonConvert.DeserializeObject<List<T>>(result);
                return new Response
                {
                    IsSuccess = true,
                    Message = "Ok",
                    Result = list,
                };
            }
            catch (Exception ex)
            {
                return new Response
                {
                    IsSuccess = false,
                    Message = ex.Message,
                };
            }
        }

    }
}
