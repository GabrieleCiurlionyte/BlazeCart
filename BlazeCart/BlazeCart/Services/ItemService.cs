﻿using BlazeCart.Models;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Collections.ObjectModel;
namespace BlazeCart.Services;

public class ItemService
{
    //Retrives a whole item list
    ObservableCollection<Item> itemList = new();

    public async Task<ObservableCollection<Item>> GetItems()
    {

        //If list already exists:
        if (itemList.Count > 0) {
            return itemList;
        }

        using var stream = await FileSystem.OpenAppPackageFileAsync("shopItems.json");
        using (StreamReader r = new StreamReader(stream))
        {
            string json = r.ReadToEnd();
            var jobj = JObject.Parse(json);
            itemList = JsonConvert.DeserializeObject<ObservableCollection<Item>>(jobj["shopItems"].ToString());
            return itemList;
        }

    }

        /*DATA GETTING FROM REMOTE SOURCE:
        HttpClient httpClient;
        string source_link = null;

        public ItemService()
        { 
            this.httpClient = new HttpClient();
        }

        public async Task<List<Item>> GetItems(){
            if (itemList.Count > 0)
                return itemList;

            var response = await httpClient.GetAsync(source_link);

            if (response.IsSuccessStatusCode)
            {
                itemList = await response.Content.ReadFromJsonAsync<List<Item>>();
            }
    
        }
        */

}