using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection;

namespace Museum.App.Services.Test.ModelReflectionHelperTests
{
    public class Collections
    {
        [Key]
        public int Collections_Id { get; set; }

        public string Name { get; set; }
    }

    public class Item
    {
        [Key]
        public int Item_Id { get; set; }

        [ForeignKey("Collections")]
        public int Collection_Id { get; set; }

        [ForeignKey("TestClass")]
        public int TestClass_Id { get; set; }

        public string Name { get; set; }
    }

    public class TestClass
    {
        [Key]
        public int TestClass_Id { get; set; }

        public string Name { get; set; }
    }

    public static class ModelReflectionHelperTests
    {
        public static void RunTests()
        {
            TestIsKeyExist();
            TestIsForeignKeyKeyExist();
            TestGetKeyProperties();
            TestGetForeignKeyProperties();
        }

        public static void TestIsKeyExist()
        {
            Console.WriteLine("--- Testing IsKeyExist ---");

            bool collectionsHasKey = ModelReflectionHelper.IsKeyExist(typeof(Collections));
            Console.WriteLine($"Collections has key: {collectionsHasKey}");

            bool itemHasKey = ModelReflectionHelper.IsKeyExist(typeof(Item));
            Console.WriteLine($"Item has key: {itemHasKey}");

            bool testClassHasKey = ModelReflectionHelper.IsKeyExist(typeof(TestClass));
            Console.WriteLine($"TestClass has key: {testClassHasKey}");

            Console.WriteLine();
        }

        public static void TestIsForeignKeyKeyExist()
        {
            Console.WriteLine("--- Testing IsForeignKeyKeyExist ---");

            bool collectionsForeignKeyExist = ModelReflectionHelper.IsForeignKeyKeyExist(typeof(Collections), "Collections");
            Console.WriteLine($"Collections has foreign key 'Collections': {collectionsForeignKeyExist}");

            bool itemCollectionsForeignKeyExist = ModelReflectionHelper.IsForeignKeyKeyExist(typeof(Item), "Collections");
            Console.WriteLine($"Item has foreign key 'Collections': {itemCollectionsForeignKeyExist}");

            bool itemTestClassForeignKeyExist = ModelReflectionHelper.IsForeignKeyKeyExist(typeof(Item), "TestClass");
            Console.WriteLine($"Item has foreign key 'TestClass': {itemTestClassForeignKeyExist}");

            Console.WriteLine();
        }

        public static void TestGetKeyProperties()
        {
            Console.WriteLine("--- Testing GetKeyProperties ---");

            PropertyInfo[] collectionsKeyProperties = ModelReflectionHelper.GetKeyProperties<Collections>();
            Console.WriteLine($"Collections key properties: {string.Join(", ", collectionsKeyProperties.Select(p => p.Name))}");

            PropertyInfo[] itemKeyProperties = ModelReflectionHelper.GetKeyProperties<Item>();
            Console.WriteLine($"Item key properties: {string.Join(", ", itemKeyProperties.Select(p => p.Name))}");

            PropertyInfo[] testClassKeyProperties = ModelReflectionHelper.GetKeyProperties<TestClass>();
            Console.WriteLine($"TestClass key properties: {string.Join(", ", testClassKeyProperties.Select(p => p.Name))}");

            Console.WriteLine();
        }

        public static void TestGetForeignKeyProperties()
        {
            Console.WriteLine("--- Testing GetForeignKeyProperties ---");

            PropertyInfo[] collectionsForeignKeyProperties = ModelReflectionHelper.GetForeignKeyProperties<Collections>("Collections");
            Console.WriteLine($"Collections foreign key 'Collections' properties: {string.Join(", ", collectionsForeignKeyProperties.Select(p => p.Name))}");

            PropertyInfo[] itemCollectionsForeignKeyProperties = ModelReflectionHelper.GetForeignKeyProperties<Item>("Collections");
            Console.WriteLine($"Item foreign key 'Collections' properties: {string.Join(", ", itemCollectionsForeignKeyProperties.Select(p => p.Name))}");

            PropertyInfo[] itemTestClassForeignKeyProperties = ModelReflectionHelper.GetForeignKeyProperties<Item>("Item");
            Console.WriteLine($"Item foreign key 'TestClass' properties: {string.Join(", ", itemTestClassForeignKeyProperties.Select(p => p.Name))}");

            Console.WriteLine();
        }
    }
}
