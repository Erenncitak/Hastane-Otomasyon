using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
namespace Proje_Hastane
{
    class sqlbaglantisi
    {
        public SqlConnection baglanti()
        {
            SqlConnection baglan = new SqlConnection("Data Source=localhost;Initial Catalog=HastaneProje;User ID=sa;Encrypt=False;password=1");
            baglan.Open();
            return baglan;
        }
    }
}
