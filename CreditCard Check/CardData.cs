using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace CreditCard_Check
{

    public class CardData
    {
        private static Dictionary<string,string> bankData = new Dictionary<string,string>();

        public CardData(string fileName)
        {
            //TEST DATA:
            //
            //bankData.Add("465943", "HSBC Bank (UK) Visa Debit, NO Cheque Guarantee ");
            //bankData.Add("465945", "HSBC(UK) Plus Visa Debit Card");
            //bankData.Add("4779", "Sainbury's Bank");
            //bankData.Add("477915", "Polish Bank");
            //bankData.Add("512025", "Orchard Bank Credit Card issued by HSBC");
            //bankData.Add("5122", "First Gulf Mastercard");
            //bankData.Add("123456", "First Bank of Harpole");

            // Read the file and place it into the Dictionary
            // File format is "NNNNNN Bank Info"

            string line;
            StreamReader data = new StreamReader(fileName);
            while ((line = data.ReadLine()) != null)
            {
                string BIN = line.Substring(0, 6).Trim();
                string bank = line.Substring(7, line.Length - 7).Trim();
                if (!bankData.ContainsKey(BIN))
                {
                    bankData.Add(BIN, bank);
                }
            }

            data.Close();
        }

        public static string BankInfo(string cardNumber)
        {
            string BIN = cardNumber.Substring(0, 1); //Bank Identity Number
            string output = "";
            if (BIN == "4")
            {
                output = "(VISA) ";
            }
            else if (BIN == "5")
            {
                output = "(Mastercard) ";
            }
            else
            {
                output = "(Unknown) ";
            }
            BIN = cardNumber.Substring(0, 6);
            if (bankData.ContainsKey(BIN))
            {
                output += bankData[BIN];
            }
            else
            {
                BIN = cardNumber.Substring(0, 4);
                if (bankData.ContainsKey(BIN))
                {
                    output += bankData[BIN];
                }
                else
                {
                    output += "Unknown bank";
                }

            }
            return output;
        }
    }
}
