using Microsoft.Data.SqlClient;
using Museum.App.Services.Abstractions;
using Museum.App.Services.Adapters;
using Museum.Models.Enums;
using Museum.Models.TableModels;
using static Dommel.DommelMapper;

namespace MuseumLouvre.Services.Test
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string s = "Data Source=DESKTOP-LRB1JFC;Initial Catalog=LouvreDatabase;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

            BaseRepository<Collections> baseRepository = new (s);


            foreach (var item in baseRepository.Find(x => x.Collection_ID <= 8))
            {
                Console.WriteLine($"{item.Collection_ID} {item.Department} {item.PeriodStart} {item.PeriodEnd}");
            }
        }
    }
}