using CommonData.Emag.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EmagAPITest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void buttonRead_Click(object sender, EventArgs e)
        {
            await Read();
        }


        private async Task Read()
        {
            try
            {
                var values = new Dictionary<string, string>();
                var content = new FormUrlEncodedContent(values);

                using (HttpClient httpClient = new HttpClient())
                {
                    httpClient.DefaultRequestHeaders.Add("ContentType", "application/json");
                    var plainTextBytes = Encoding.UTF8.GetBytes("USER:PAROLA");
                    string val = Convert.ToBase64String(plainTextBytes);
                    httpClient.DefaultRequestHeaders.Add("Authorization", "Basic " + val);

                    var response = await httpClient.PostAsync("https://marketplace-api.emag.ro/api-3/product_offer/read", content);
                    richTextBoxResponse.Text = await response.Content.ReadAsStringAsync();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Eroare");
            }
        }

        private async void buttonUpdate_Click(object sender, EventArgs e)
        {
            //await UpdateEmagJson();
            await UpdateEmagMultipartFomrData();
            //await UpdateEmagFormUrlEncoded();
        }

        private async Task UpdateEmagJson()
        {
            try
            {
                List<OfferUpdate> offers = new List<OfferUpdate>();

                var offer = new OfferUpdate
                {
                    id = 2,
                    status = 1,
                    sale_price = 63,
                    vat_id = 1
                };
                offers.Add(offer);
                var data = new { data = offers };
                var postData = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(data));


                using (HttpClient httpClient = new HttpClient())
                {
                    var request = new HttpRequestMessage(HttpMethod.Post, "https://marketplace-api.emag.ro/api-3/product_offer/save");
                    httpClient.DefaultRequestHeaders.Add("ContentType", "application/json");

                    var authDataBytes = Encoding.UTF8.GetBytes("USER:PAROLA");
                    string val = Convert.ToBase64String(authDataBytes);
                    httpClient.DefaultRequestHeaders.Add("Authorization", "Basic " + val);
                    request.Content = new ByteArrayContent(postData);


                    HttpResponseMessage response = await httpClient.SendAsync(request);

                    richTextBoxResponse.Text = await response.Content.ReadAsStringAsync();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Eroare");
            }
        }

        private async Task UpdateEmagFormUrlEncoded()
        {
            try
            {
                List<OfferUpdate> offers = new List<OfferUpdate>();
                var offer = new OfferUpdate
                {
                    id = 2,
                    status = 1,
                    sale_price = 63,
                    vat_id = 1
                };
                offers.Add(offer);

                var keyValueList = new List<KeyValuePair<string, string>>();
                keyValueList.Add(new KeyValuePair<string, string>("data", JsonConvert.SerializeObject(offers)));

                var postData = new FormUrlEncodedContent(keyValueList);


                using (HttpClient httpClient = new HttpClient())
                {
                    var request = new HttpRequestMessage(HttpMethod.Post, "https://marketplace-api.emag.ro/api-3/product_offer/save");
                    httpClient.DefaultRequestHeaders.Add("ContentType", "application/x-www-form-urlencoded");
                    var authDataBytes = Encoding.UTF8.GetBytes("USER:PAROLA");
                    string val = Convert.ToBase64String(authDataBytes);
                    httpClient.DefaultRequestHeaders.Add("Authorization", "Basic " + val);

                    request.Content = postData;


                    HttpResponseMessage response = await httpClient.SendAsync(request);

                    richTextBoxResponse.Text = await response.Content.ReadAsStringAsync();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Eroare");
            }
        }

        private async Task UpdateEmagMultipartFomrData()
        {
            try
            {
                List<OfferUpdate> offers = new List<OfferUpdate>();
                var offer = new OfferUpdate
                {
                    id = 2,
                    status = 1,
                    sale_price = 63,
                    vat_id = 1
                };
                offers.Add(offer);

                var keyValueList = new List<KeyValuePair<string, string>>();
                keyValueList.Add(new KeyValuePair<string, string>("data", JsonConvert.SerializeObject(offers)));

                var postData = new FormUrlEncodedContent(keyValueList);


                using (HttpClient httpClient = new HttpClient())
                {
                    var request = new HttpRequestMessage(HttpMethod.Post, "https://marketplace-api.emag.ro/api-3/product_offer/save");
                    httpClient.DefaultRequestHeaders.Add("ContentType", "multipart/form-data");
                    var authDataBytes = Encoding.UTF8.GetBytes("USER:PAROLA");
                    string val = Convert.ToBase64String(authDataBytes);
                    httpClient.DefaultRequestHeaders.Add("Authorization", "Basic " + val);

                    request.Content = postData;


                    HttpResponseMessage response = await httpClient.SendAsync(request);

                    richTextBoxResponse.Text = await response.Content.ReadAsStringAsync();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Eroare");
            }
        }
    }
}
