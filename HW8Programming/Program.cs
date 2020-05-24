using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace PatternsTask
{
    class Program
    {
        public static Distributor CreateSystem()
        {
            EndUser user0 = new EndUser(1500, 1520, "u0");
            EndUser user1 = new EndUser(1500, 1540, "u1");
            EndUser user2 = new EndUser(1500, 1560, "u2");
            EndUser user3 = new EndUser(1500, 1510, "u3");
            EndUser user4 = new EndUser(1600, 1710, "u4");
            EndUser user5 = new EndUser(1600, 1800, "u5");
            EndUser user6 = new EndUser(1500, 1511, "u6");
            EndUser user7 = new EndUser(1500, 1510, "u7");
            EndUser user8 = new EndUser(1500, 1510, "u8");
            EndUser user9 = new EndUser(1600, 1630, "u9");
            Distributor distributor0 = new Distributor("d0");
            Distributor distributor1 = new Distributor("d1");
            Distributor distributor2 = new Distributor("d2");
            Distributor distributor3 = new Distributor("d3");
            Distributor distributor4 = new Distributor("d4");
            Distributor distributor5 = new Distributor("d5");
            Distributor distributor6 = new Distributor("d6");
            distributor0.AddDevice(user0);
            distributor0.AddDevice(distributor1);
            distributor1.AddDevice(user1);
            distributor1.AddDevice(user2);
            distributor1.AddDevice(user3);
            distributor1.AddDevice(distributor2);
            distributor2.AddDevice(user4);
            distributor2.AddDevice(distributor3);
            distributor2.AddDevice(distributor4);
            distributor3.AddDevice(user5);
            distributor3.AddDevice(distributor5);
            distributor4.AddDevice(user6);
            distributor4.AddDevice(user7);
            distributor5.AddDevice(user8);
            distributor5.AddDevice(user9);

            return distributor0;
        }


        static void Main(string[] args)
        {
            try
            {
                Distributor counter4 = CreateSystem();
                counter4.Display();

                var electricity = new GetElectricity();
                counter4.Accept(electricity);
                Console.WriteLine($"ELECTRICITY: {electricity.result}");
                List<ICounter> res = new List<ICounter>();

                IEnumerable<ICounter> users = counter4.GetEndUsers(res);
                Console.WriteLine($"END USERS:");

                var endUsers =
                   from device in users
                   orderby device ascending
                   select device;

                foreach (var i in endUsers)
                {
                    i.Display();
                }


                WriteObject("DataContractSerializer.xml", counter4);
                //deserealization
                //ReadObject("DataContractSerializer.xml");
            }
            catch(ArgumentException agExc)
            {
                Console.WriteLine(agExc.Message);
            }
            catch (SerializationException serExc)
            {
                Console.WriteLine("Serialization Failed");
                Console.WriteLine(serExc.Message);
            }
            catch (Exception exc)
            {
                Console.WriteLine(
                "Operation failed: {0} StackTrace: {1}",
                exc.Message, exc.StackTrace);
            }

            finally
            {
                Console.WriteLine("Press <Enter> to exit....");
                Console.ReadLine();
            }
        }

        public static void WriteObject(string fileName, Distributor distributor)
        {
            Console.WriteLine(
                "Serializing the object.");
            FileStream writer = new FileStream(fileName, FileMode.Create);
            DataContractSerializer ser =
                new DataContractSerializer(typeof(ICounter), new List<Type> { typeof(Distributor), typeof(EndUser) });
            ser.WriteObject(writer, distributor);
            writer.Close();
        }

        public static void ReadObject(string fileName)
        {
            Console.WriteLine("Deserializing an instance of the object.");
            FileStream fs = new FileStream(fileName,
            FileMode.Open);
            XmlDictionaryReader reader =
                XmlDictionaryReader.CreateTextReader(fs, new XmlDictionaryReaderQuotas());
            DataContractSerializer ser = new DataContractSerializer(typeof(ICounter), new List<Type> { typeof(Distributor), typeof(EndUser) });

            // Deserialize the data and read it from the instance.
            Distributor deserialized =
                (Distributor)ser.ReadObject(reader, true);
            reader.Close();
            fs.Close();
            Console.WriteLine(String.Format("Distributor. ID : {0}",
            deserialized.ID));
        }
    }
}
