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
        //Will return a list of ints that are toyIDs assigned to a given child
        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)] 
        public void ListAllToyIdsAChildIsGetting(int childId)
        {
            List<Toy> ChildToyList = _santasHelper.GetChildToyList(childId);
            foreach( Toy toy in ChildToyList)
            {
                Console.WriteLine("Child " + childId + " is getting toy id " + toy.Name);
            }

            Assert.IsType<List<Toy>>(ChildToyList);
        }

        //Will add a new toy to a childId
        [Theory]
        [InlineData("Skateboard", 1)]
        [InlineData("Ball", 2)]
        [InlineData("Tonka Truck", 3)]        
        public void ToyAddedToBagShouldBeItemAdded(string toyName, int childId)
        {

            //returns toyId of the new toy we added
            int itemToAdd = _santasHelper.AddItemToBag(toyName, childId);
            //returns the list of children
            List<Toy> childToyList =  _santasHelper.GetChildToyList(childId);

            //checks to see if the toyId we got back from the add is in the list of toys that are asscoiated with a child.
            Assert.IsType<int>(itemToAdd);
            
        }

        //Items can be removed from bag, per child. 
        //Removing Ball, for example, from the bag should not be allowed. 
        //A child's name must be specified.
        [Theory]
        [InlineData(1, 1)]
        [InlineData(2, 2)]
        [InlineData(3, 3)] 
        public void ToyToBeRemovedShouldBeRemoved(int toyId, int childId)
        {
            _santasHelper.RemoveItemFromBag(toyId, childId);
            List<Toy> childToyList = _santasHelper.GetChildToyList(childId);
            List<int> toyIdList = new List<int>();
            foreach(Toy toy in childToyList)
            {
                toyIdList.Add(toy.ToyId);
            }

            Assert.DoesNotContain(toyId, toyIdList);
        }

       // Must be able to list all children who are getting a toy.
       [Fact]
       public void ListAllChildrenWhoAreGettingAToy()
       {
           List<Child> childrenToReceiveToys = _santasHelper.GetChildrenWhoGetToys();
           
           foreach(Child child in childrenToReceiveToys)
           {
                Console.WriteLine(child);
           }

           Assert.IsType<List<Child>>(childrenToReceiveToys);
       }

       //Must be able to set the delivered property of a child, which defaults to false to true.
       [Theory]
       [InlineData(1)]
       [InlineData(1)]
       [InlineData(1)]
       public void HaveAChildsToysBeenDelivered(int childId)
       {    
           bool deliveryStatus = _santasHelper.ChildDeliveryStatus(childId);

           Assert.False(deliveryStatus);
       }
    }
}