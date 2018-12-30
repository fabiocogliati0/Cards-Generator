using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Cards_Generator
{
    class GeneratorManager
    {


        public static GeneratorManager GetInstance()
        {
            if(_Instance == null)
            {
                _Instance = new GeneratorManager();
            }

            return _Instance;
        }

        public bool LoadData()
        {

            bool status = true;

            // Load all data
            try
            {
                using (StreamReader reader = new StreamReader(Paths.EnchantmentsDataPath))
                {
                    string json = reader.ReadToEnd();
                    _enchantments = JsonConvert.DeserializeObject<List<Enchantment>>(json);

                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                status = false;
            }

            return status;
        }





        private static GeneratorManager _Instance = null;


        private List<Enchantment> _enchantments;

    }
}
