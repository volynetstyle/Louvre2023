using AutoMapper;
using System;
using System.Collections.Generic;
using Newtonsoft.Json;

public class Image
{
    public string urlImage { get; set; }
    public string urlThumbnail { get; set; }
    public string copyright { get; set; }
    public string type { get; set; }
    public int position { get; set; }
}

public class Images
{
    public int Image_ID { get; set; }
    public string Image_Loc { get; set; }
    public string Photographer { get; set; }
    public DateTime Date_Taken { get; set; }
    public string Additional_Info { get; set; }
    public int Object_ID { get; set; }
}

public class ImageData
{
    public List<Image> Images { get; set; }
}

public class Program
{
    public static void Main()
    {
        // JSON data
        string json = @"
        {
            ""Images"": [
                {
                    ""urlImage"": ""https://collections.louvre.fr/media/cache/large/0000000021/0000277627/0000625031_OG.JPG"",
                    ""urlThumbnail"": ""https://collections.louvre.fr/media/cache/small/0000000021/0000277627/0000625031_OG.JPG"",
                    ""copyright"": ""\u00a9 2011 Mus\u00e9e du Louvre / Thierry Ollivier"",
                    ""type"": ""trois quarts"",
                    ""position"": 0
                },
                {
                    ""urlImage"": ""https://collections.louvre.fr/media/cache/large/0000000021/0000277627/0000625032_OG.JPG"",
                    ""urlThumbnail"": ""https://collections.louvre.fr/media/cache/small/0000000021/0000277627/0000625032_OG.JPG"",
                    ""copyright"": ""\u00a9 2011 Mus\u00e9e du Louvre / Thierry Ollivier"",
                    ""type"": ""d\u00e9tail"",
                    ""position"": 1
                },
                {
                    ""urlImage"": ""https://collections.louvre.fr/media/cache/large/0000000021/0000277627/0000625130_OG.JPG"",
                    ""urlThumbnail"": ""https://collections.louvre.fr/media/cache/small/0000000021/0000277627/0000625130_OG.JPG"",
                    ""copyright"": ""\u00a9 2011 Mus\u00e9e du Louvre / Thierry Ollivier"",
                    ""type"": ""d\u00e9tail"",
                    ""position"": 2
                },
                {
                    ""urlImage"": ""https://collections.louvre.fr/media/cache/large/0000000021/0000277627/0000625132_OG.JPG"",
                    ""urlThumbnail"": ""https://collections.louvre.fr/media/cache/small/0000000021/0000277627/0000625132_OG.JPG"",
                    ""copyright"": ""\u00a9 2011 Mus\u00e9e du Louvre / Thierry Ollivier"",
                    ""type"": ""d\u00e9tail"",
                    ""position"": 3
                }
            ]
        }";

        // Configure AutoMapper mapping
        var config = new MapperConfiguration(cfg => {
            cfg.CreateMap<dynamic, Images>()
        .ForMember(dest => dest.Image_ID, opt => opt.MapFrom(src => src.position))
        .ForMember(dest => dest.Image_Loc, opt => opt.MapFrom(src => src.urlImage))
        .ForMember(dest => dest.Photographer, opt => opt.MapFrom(src => src.copyright))
        .ForMember(dest => dest.Date_Taken, opt => opt.MapFrom(src => DateTime.Now))
        .ForMember(dest => dest.Additional_Info, opt => opt.Ignore())
        .ForMember(dest => dest.Object_ID, opt => opt.Ignore());
        });

        IMapper mapper = config.CreateMapper();

        // Deserialize JSON
        ImageData imageData = JsonConvert.DeserializeObject<ImageData>(json);

        // Perform mapping
        var imagesList = mapper.Map<List<Ima>(imageData.Images);

        // Output mapped data
        foreach (Images image in imagesList)
        {
            Console.WriteLine($"Image ID: {image.Image_ID}");
            Console.WriteLine($"Image Location: {image.Image_Loc}");
            Console.WriteLine($"Photographer: {image.Photographer}");
            Console.WriteLine($"Date Taken: {image.Date_Taken}");
            Console.WriteLine($"Additional Info: {image.Additional_Info}");
            Console.WriteLine($"Object ID: {image.Object_ID}");
            Console.WriteLine();
        }
    }
}
