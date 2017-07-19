using System;
using System.Collections.Generic;
using Xunit;

namespace BagOLoot.Tests
{
    public class SantasHelperShould
    {
        private SantasHelper _santasHelper;
        public SantasHelperShould()
        {
            _santasHelper = new SantasHelper();
        }

        //Must be able to list all toys for a given child's name.
        [Fact]
        public void ListAllToyIdsAChildIsGetting()
        {
            int childId = 715;
            List<int> ChildToyList = _santasHelper.GetChildToyList(childId);

            Assert.IsType<List<int>>(ChildToyList);
        }

        [Fact]
        public void ToyAddedToBagShouldBeItemAdded()
        {
            //Name of toy to add
            string toyName = "Skateboard";
            //id of child to add toy to
            int childId = 715;
            //returns toyId of the new toy we added
            int itemToAdd = _santasHelper.AddItemToBag(toyName, childId);
            //returns the list of children
            List<int> childToyList =  _santasHelper.GetChildToyList(childId);

            //checks to see if the toyId we got back from the add is in the list of toys that are asscoiated with a child.
            Assert.Contains(itemToAdd, childToyList);
            
        }

        //Items can be removed from bag, per child. 
        //Removing Ball, for example, from the bag should not be allowed. 
        //A child's name must be specified.
        [Fact]
        public void ToyToBeRemovedShouldBeRemoved()
        {
            int toyId = 9;
            int childId = 715;
            _santasHelper.RemoveItemFromBag(toyId, childId);
            List<int> childToyList = _santasHelper.GetChildToyList(childId);

            Assert.DoesNotContain(toyId, childToyList);
        }

       // Must be able to list all children who are getting a toy.
       public void ListAllChildrenWhoAreGettingAToy()
       {
           List<string> childrenToReceiveToys = _santasHelper.GetChildrenWhoGetToys();

           Assert.IsType<List<string>>(childrenToReceiveToys);
       }

       //Must be able to set the delivered property of a child, which defaults to false to true.
       [Fact]
       public void HaveAChildsToysBeenDelivered()
       {    
           int childId = 715;
           bool deliveryStatus = _santasHelper.ChildDeliveryStatus(childId);

           Assert.True(deliveryStatus);
       }
    }
}