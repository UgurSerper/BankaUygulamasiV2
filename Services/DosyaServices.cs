using System.Runtime.CompilerServices;
using System.Security;
using System.Text.Json;

namespace Banka
{
    public class DosyaServices{

        private static readonly string calismaDizini = AppDomain.CurrentDomain.BaseDirectory;
        private static readonly string VarsayilanDosyaYolu = Path.Combine(calismaDizini,"islemler.json");

        private static readonly JsonSerializerOptions ayarlar = new JsonSerializerOptions
        {
            WriteIndented =true
        };
        
        public static async Task Kaydet<T>( T data, string? dosyayolu = null)
        {
            string yol = dosyayolu?? VarsayilanDosyaYolu;

            Console.WriteLine(Path.GetFullPath(VarsayilanDosyaYolu));

            try
            {
                using FileStream createStream = File.Create(yol);
                await JsonSerializer.SerializeAsync(createStream , data, ayarlar);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }         
        }
        public static async Task<T?> Yukle<T>(string? dosyayolu = null)
        {
            string yol = dosyayolu?? VarsayilanDosyaYolu;

            try
            {
                using FileStream openStream = File.OpenRead(yol);
                T? veri = await JsonSerializer.DeserializeAsync<T>(openStream,ayarlar);
                return veri;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return default;
            }
        }

    }

}