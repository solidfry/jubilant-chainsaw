using System;
using ScriptableObjects.Ingredients;
using UnityEngine;

namespace Recipe
{
    [Serializable]
    public struct RecipeItem
    {
        public IngredientType ingredientType;
        public int requirement;
//        [SerializeField][ReadOnly]
//        private int count;
//        public bool complete;
//
//    public int Count
//    {
//        get => count;
//        set
//        {
//            count = value;
//            _ = count >= requirement ? complete = true : complete = false;
//        }
//    } 
//            
//    public void SetLevelComplete()
//    {
//        _ = Count >= requirement && complete;
//    }
//
//    public void ReduceCount()
//    {
//        Count--;
//    }
//
//    public void IncreaseCount()
//    {
//        Count++;
//    }
//
//    public void ResetEntry()
//    {
//        Count = 0;
//        complete = false;
//    }
    }
}