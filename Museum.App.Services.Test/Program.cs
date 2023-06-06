
using Museum.App.Services;
using Museum.App.Services.Abstractions;
using Museum.Models.TableModels;

namespace Museum.App.Services.Tests
{
    public static class Program
    {
        public static void Main()
        {
            //ModelReflectionHelperTests.RunTests();

            string? query = "Data Source=DESKTOP-LRB1JFC;Initial Catalog=LouvreDatabase;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

            BaseRepository<Collections> repository = new (query);

            //var a = repository.GetParentChild<Collections, CollectionParts>();

        }
    }
}