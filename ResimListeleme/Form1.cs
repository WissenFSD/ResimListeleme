using System.Data.SqlClient;

namespace ResimListeleme
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("data source=.;initial catalog=AdventureWorks2019;integrated security=true");
            SqlCommand cmd = new SqlCommand("select p.Name, p.ProductID,pp.LargePhoto  from Production.ProductPhoto pp inner join Production.ProductProductPhoto ppp on ppp.ProductPhotoId = pp.ProductPhotoId inner join Production.Product p on p.ProductId=ppp.ProductId", con);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                // bu aþamada dinamik olarak picturebox oluþturuyorum.



                byte[] imageByte = (byte[])dr["LargePhoto"];
                PictureBox picture = new PictureBox();
                picture.Size=new Size(200,200);

                MemoryStream stream = new MemoryStream(imageByte);
                picture.Image = Image.FromStream(stream);

                // picturebox ekranda gözüksün diye

                flowLayoutPanel1.Controls.Add(picture);

            }
            dr.Close();
            con.Close();
        }
    }
}