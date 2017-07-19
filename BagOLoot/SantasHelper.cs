using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Data.Sqlite;

namespace BagOLoot
{
    public class SantasHelper
    {
        //method will add an item to a childs toy list
        public int AddItemToBag(string toyName, int childId)
        {   
            //when toy is created and added to child bag, return toyId
            int toyId = 5;
            return toyId;
        }

        public void RemoveItemFromBag(int toyId, int childId)
        {
            
        }

        //method will return a list of toyIds in a given childs list
        public List<int> GetChildToyList(int childId)
        {
            return new List<int>(){5, 6, 7, 8}; 
        }

        //will return a list of strings children who are going to receive toys
        public List<string> GetChildrenWhoGetToys()
        {
            return new List<string>(){"Steve", "Chaz", "AARON"};
        }

        //given a childId, will return if that childs toys have been delivered.
        public bool ChildDeliveryStatus(int childId)
        {
            return true;
        }

        
    
    }
}