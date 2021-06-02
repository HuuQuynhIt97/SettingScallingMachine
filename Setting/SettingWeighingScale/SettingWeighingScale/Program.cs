using System;
using System.IO;
using System.Linq;
namespace SettingWeighingScale
{
    class Program
    {
        static void Main(string[] args)
        {
           
            string big_scale_folder = @"BigScale\";
            string small_scale_folder = @"SmallScale\";
            string file_default = "appsettings.json";
            while (true)
            {
                string license_key_default = "SHC";
                Console.Write("License key: ");
                var license_key = Console.ReadLine();
                string root_default = @"F:\Angular\SYSTEM\Digital Mixing Room\26052021\DRM\";
                string[] root = Directory.GetFiles(root_default);

                //var root_big_scale = root[BigScale];
                if (license_key_default == license_key)
                {

                    Console.WriteLine("Config COM port for Scaling Machine ");
                    Console.Write("Big Scaling COM port: ");
                    var big_scale = Console.ReadLine();
                    string json_big = System.IO.File.ReadAllText(root_default + big_scale_folder + file_default);
                    dynamic jsonObj_big = Newtonsoft.Json.JsonConvert.DeserializeObject(json_big);
                    var _AppSettings_Big = jsonObj_big.AppSettings;
                    _AppSettings_Big["PortName"] = "COM" + big_scale;
                    string output_big = Newtonsoft.Json.JsonConvert.SerializeObject(jsonObj_big, Newtonsoft.Json.Formatting.Indented);
                    System.IO.File.WriteAllText(root_default + big_scale_folder + file_default, output_big);


                    Console.Write("Small Scaling COM port: ");
                    var small_scale = Console.ReadLine();
                    string json_small = System.IO.File.ReadAllText(root_default + small_scale_folder + file_default);
                    dynamic jsonObj_small = Newtonsoft.Json.JsonConvert.DeserializeObject(json_small);
                    var _AppSettings_Small = jsonObj_small.AppSettings;
                    _AppSettings_Small["PortName"] = "COM" + small_scale;
                    string output_small = Newtonsoft.Json.JsonConvert.SerializeObject(jsonObj_small, Newtonsoft.Json.Formatting.Indented);
                    System.IO.File.WriteAllText(root_default + small_scale_folder + file_default, output_small);

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Setting Successfully");
                    Console.Write($"{Environment.NewLine}All Setting alredy Save , Press any key to exit...");
                    Console.ReadKey(true);
                    break;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("License key invalid ! Enter again");
                }

            }


        }
    }
}
