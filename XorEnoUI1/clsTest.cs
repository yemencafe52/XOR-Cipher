//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace XorEnoUI1
//{
//    class clsTest
//    {
//        static void Main()
//        {
//            byte[] data = new byte[] { 97, 98, 99 };
//            byte[] pass = new byte[] { 49, 50, 51 };

//            //Encryption
//            byte[] res = Xor.XorM(data, pass);
//            Console.Write(Encoding.UTF8.GetString( res));

//            //Decryption
//            res = Xor.XorM(res, pass);
//            Console.Write(Encoding.UTF8.GetString(res));

//            Console.Read();

//        }
//    }
//}
